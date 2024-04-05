using Aspose.Pdf;
using Aspose.Words;
using Aspose.Words.Replacing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VilasLab.Base;
using VilasLab.Models;
using Rectangle = iTextSharp.text.Rectangle;
using Document = Aspose.Words.Document;
using Color = System.Drawing.Color;
using Image = iTextSharp.text.Image;
using iTextSharp.text.pdf;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;

namespace VilasLab.Pages
{
    public partial class EditDocumentSample : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        public bool RequestChanged { get; set; } = false;
        public string IDSample { get; set; } = "";
        public string IDResult { get; set; } = "";
        public string IDDoc { get; set; } = "";
        private BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
        string fileSignName = "";
        public int IDTemplate { get; set; } = 1;
        private List<ParamDocSigner> lstbeanDocSigner = new List<ParamDocSigner>();
        public EditDocumentSample()
        {
            InitializeComponent();
        }
        private DataTable getDataSample()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("SampleID", IDSample));
            DataTable result = _db.Fill("Select_SampleInfo", parameters);
            return result;
            
        }
        private void loadData()
        {
            ribbonPageGroup1.Visible = false;
            ribbonPageGroup2.Visible = false;
            if (IDDoc != "")
            {
                BeanDocument beanDocument = new BeanDocument();
                beanDocument = beanDocument.SelectByID(IDDoc);
                BeanCustomer beanCustomer = new BeanCustomer();
                BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
                List<BeanDocumentSigner> lst = new List<BeanDocumentSigner>();
                lst = beanDocumentSigner.SelectAll().Where(s => s.idDocument == IDDoc).ToList();
                if (lst.Count > 0)
                {
                    foreach (BeanDocumentSigner item in lst)
                    {
                        ParamDocSigner beanParamDoc = new ParamDocSigner();
                        beanParamDoc.id = item.idUser;
                        beanCustomer = beanCustomer.SelectByID(item.idUser);
                        beanParamDoc.name = beanCustomer.fullName;
                        if (item.status == true)
                        {
                            beanParamDoc.status = "Đã ký";
                        }
                        lstbeanDocSigner.Add(beanParamDoc);
                        setDataGrid(lstbeanDocSigner);
                        if (beanDocument.status == 1 && item.idUser == currUser.id)
                        {
                            ribbonPageGroup1.Visible = true;
                        }
                        if (beanDocument.status == 1)
                        {
                            ribbonPageGroup2.Visible = true;
                        }

                    }
                }
                if (beanDocument.status >= 1)
                {
                    btnSaveFile.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btn_SendDoc.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    grb_SignInfo.Visible = false;
                    ribbonPageGroup2.Visible = true;
                }
                   
            }
        }
        private void EditDocumentSample_Load(object sender, EventArgs e)
        {
            CheckLicenseAspose();
            grid_UserSigned.DataSource = lstbeanDocSigner;
            grid_UserSigned.Columns[0].HeaderText = "Mã";
            grid_UserSigned.Columns[1].HeaderText = "Tên nhân viên";
            grid_UserSigned.Columns[2].HeaderText = "Trạng thái";
            grid_UserSigned.Columns[1].Width = 400;
            grid_UserSigned.Columns[2].Width = 400;
            grid_UserSigned.Columns[0].Visible = false;
            grid_UserSigned.Columns[3].Visible = false;
            loadData();
            SetDbCombobox();
            MappingDataToTemp();
        }
        private void setDataEditor(Document doc)
        {
            //FileStream file = new FileStream(url, FileMode.Open);
            //Document doc = new Document(file);
            MemoryStream tream = new MemoryStream();
            doc.Save(tream, Aspose.Words.SaveFormat.Doc);
            richEditControl1.DocBytes = tream.ToArray();
        }

        private string selectCountSample()
        {
            string strCount = "001";
            BeanDocument beanDocument = new BeanDocument();
            strCount = (beanDocument.SelectAll().Where(s => Convert.ToDateTime(s.Created).Month == DateTime.Now.Month && Convert.ToDateTime(s.Created).Year == DateTime.Now.Year).Count() + 1).ToString("000");
            return strCount;
        }

        private void MappingDataToTemp()
        {
            try
            {
                DataTable dataTable = getDataSample();
                BeanTemplate beanTemplate = new BeanTemplate();
                BeanField beanField = new BeanField();
                List<BeanField> lstBeanField = new List<BeanField>();
                if (IDDoc == "")
                {
                    IDDoc = DateTime.Now.ToString("ddMMyy") + "/" + selectCountSample();
                    beanTemplate = beanTemplate.SelectByID(IDTemplate);
                    if (beanTemplate.arrFileDoc != null)
                    {
                        if (dataTable.Rows.Count > 0)
                        {
                            MemoryStream sm = new MemoryStream(beanTemplate.arrFileDoc);
                            Document doc = new Document(sm);
                            DataRow itemRow = dataTable.Rows[0];
                            lstBeanField = beanField.SelectAll().Where(s => s.idTemplate == beanTemplate.id).ToList();
                            foreach (BeanField itemField in lstBeanField)
                            {
                                if (!itemField.isHTML)
                                {
                                    if (!string.IsNullOrEmpty(itemField.value))
                                    {
                                        if (itemField.defaultText == "ToDay")
                                            doc.Range.Replace(itemField.name, DateTime.Now.ToString("dd/MM/yyyy"), true, false);
                                        else if (itemField.defaultText == "ToDayString")
                                        {
                                            string todate = "ngày " + DateTime.Now.Day.ToString("00") + " tháng " + DateTime.Now.Month.ToString("00") + " năm " + DateTime.Now.Year;
                                            doc.Range.Replace(itemField.name, todate, true, false);
                                        }
                                        else if (itemField.value == "FromDate" || itemField.value == "ToDate")
                                        {
                                            if(!string.IsNullOrEmpty(itemRow[itemField.value] + string.Empty))
                                                doc.Range.Replace(itemField.name, Convert.ToDateTime(itemRow[itemField.value] + string.Empty).ToString("dd/MM/yyyy"), true, false);

                                        }
                                        else if (itemField.value == "NgayNhanMau" )
                                        {
                                            BeanResult result = new BeanResult();
                                            var rs = result.SelectAll().Where(s => s.idSample == IDSample).FirstOrDefault();
                                            if(rs != null)
                                                doc.Range.Replace(itemField.name, rs.testDate.ToString("dd/MM/yyyy"), true, false);
                                            else
                                                doc.Range.Replace(itemField.name, DateTime.Now.ToString("dd/MM/yyyy"), true, false);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (!string.IsNullOrEmpty(itemRow[itemField.value] + string.Empty))
                                                {
                                                    doc.Range.Replace(itemField.name, itemRow[itemField.value] + string.Empty, true, false);
                                                }
                                            }
                                            catch
                                            {
                                                doc.Range.Replace(itemField.name, itemField.defaultText, true, false);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    List<ParamDoc> data = setData(itemField);
                                    foreach (ParamDoc item in data)
                                    {
                                        MoveToMatchNode ObjReplacingCallback = new MoveToMatchNode
                                        {
                                            InsertHtml = item.strHTML
                                        };
                                        FindReplaceOptions options = new FindReplaceOptions
                                        {
                                            ReplacingCallback = ObjReplacingCallback,
                                            FindWholeWordsOnly = true
                                        };
                                        options.ApplyFont.HighlightColor = Color.Yellow;
                                        doc.Range.Replace(item.FieldName, "", options);
                                    }
                                }
                            }
                            //File.WriteAllBytes(urlNameSave, strByte);
                            setDataEditor(doc);
                        }
                    }
                }
                else
                {
                    BeanDocument beanDocument = new BeanDocument();
                    beanDocument = beanDocument.SelectByID(IDDoc);
                    if (beanDocument.arrFileDocSigned != null)
                    {
                        MemoryStream sm = new MemoryStream(beanDocument.arrFileDocSigned);
                        Document doc = new Document(sm);
                        setDataEditor(doc);
                    }
                }  
            }
            catch (Exception ex)
            {
                function.TrackingError("EditDocumentSample - MappingDataToTemp", ex.ToString());
            }
        }
        public string ReplaceKeyToSpace(Aspose.Pdf.Text.Font timesFont, double width, float fontSize)
        {
            string res = string.Empty;
            try
            {
                Aspose.Pdf.Text.TextState ts = new Aspose.Pdf.Text.TextState
                {
                    Font = timesFont,
                    FontSize = fontSize
                };
                char c = 'i';
                double tsMeasure2 = timesFont.MeasureString(c.ToString(), fontSize);
                double Count = width / tsMeasure2;
                if (double.IsInfinity(Count))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        res += " ";
                    }
                }
                else
                {
                    for (int i = 0; i < (int)Count; i++)
                    {
                        res += " ";
                    }
                }

            }
            catch
            { }
            return res;
        }
        private void convertToPdf(Aspose.Words.Document doc, string urlNameSavePDF, string fileName, byte[] arrDoc)
        {
            try
            {
                delDocSigner();
                BeanCustomer beanCustomer = new BeanCustomer();
                int stt = 1;
                byte[] strBytePDF = null;
                using (MemoryStream outStream = new MemoryStream())
                {
                    doc.Save(outStream, Aspose.Words.SaveFormat.Pdf);
                    Aspose.Pdf.Document docPdf = new Aspose.Pdf.Document(outStream);
                    foreach(ParamDocSigner item in lstbeanDocSigner)
                    {
                        #region Xử lý vị trí ký số
                        beanCustomer = beanCustomer.SelectByID(item.id);
                        string KeySign = beanCustomer.accountName.Trim() + "_sign";
                        Aspose.Pdf.Text.TextFragmentAbsorber FrameAbsKyNoiDung = new Aspose.Pdf.Text.TextFragmentAbsorber(KeySign); // set text search option to specify regular expression usage
                        Aspose.Pdf.Text.TextSearchOptions SearchOptionsKyNoiDung = new Aspose.Pdf.Text.TextSearchOptions(true);
                        FrameAbsKyNoiDung.TextSearchOptions = SearchOptionsKyNoiDung;
                        docPdf.Pages.Accept(FrameAbsKyNoiDung);
                        Aspose.Pdf.Text.TextFragmentCollection FragmentCollectionKyNoiDung = FrameAbsKyNoiDung.TextFragments;
                        if (FragmentCollectionKyNoiDung != null && FragmentCollectionKyNoiDung.Count > 0)
                        {
                            for (int i = 1; i <= FragmentCollectionKyNoiDung.Count(); i++)
                            {
                                Aspose.Pdf.Text.TextFragment textFragment = FragmentCollectionKyNoiDung[i];
                                textFragment.TextState.ForegroundColor = Aspose.Pdf.Color.Blue;

                                int LLX = (int)textFragment.Rectangle.LLX;
                                int LLY = (int)textFragment.Rectangle.LLY;
                                int URX = (int)textFragment.Rectangle.URX;
                                int URY = (int)textFragment.Rectangle.URY;
                                int NumPage = textFragment.Page.Number;

                                var pos = new PosSign
                                {
                                    LLX = LLX,
                                    LLY = LLY,
                                    URX = URX,
                                    URY = URY,
                                    NumPage = NumPage,
                                    KeyKySo = KeySign
                                };
                                item.position = JsonConvert.SerializeObject(pos);
                                textFragment.Text = ReplaceKeyToSpace(textFragment.TextState.Font, textFragment.Rectangle.Width, textFragment.TextState.FontSize);
                            }
                        }
                        #endregion
                    }
                    docPdf.Save(outStream);
                    strBytePDF = outStream.ToArray();
                }
                File.WriteAllBytes(urlNameSavePDF, strBytePDF);
                SaveDocSample(strBytePDF, arrDoc, "Send");
            }
            catch (Exception ex)
            {
                function.TrackingError("EditDocumentSample - convertToPdf", ex.ToString());
            }
        }
        private void delDocSigner()
        {
            BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
            List<BeanDocumentSigner> lst = new List<BeanDocumentSigner>();
            lst = beanDocumentSigner.SelectAll().Where(s => s.idDocument == IDDoc).ToList();
            if(lst.Count > 0)
            {
                foreach(BeanDocumentSigner item in lst)
                {
                    item.Delete(item);
                }
            }
        }
        private void CheckLicenseAspose()
        {
            try
            {
                string LData = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxMaWNlbnNlPg0KICAgIDxEYXRhPg0KICAgICAgICA8TGljZW5zZWRUbz5pckRldmVsb3BlcnMuY29tPC9MaWNlbnNlZFRvPg0KICAgICAgICA8RW1haWxUbz5pbmZvQGlyRGV2ZWxvcGVycy5jb208L0VtYWlsVG8+DQogICAgICAgIDxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlVHlwZT4NCiAgICAgICAgPExpY2Vuc2VOb3RlPkxpbWl0ZWQgdG8gMTAwMCBkZXZlbG9wZXIsIHVubGltaXRlZCBwaHlzaWNhbCBsb2NhdGlvbnM8L0xpY2Vuc2VOb3RlPg0KICAgICAgICA8T3JkZXJJRD43ODQzMzY0Nzc4NTwvT3JkZXJJRD4NCiAgICAgICAgPFVzZXJJRD4xMTk0NDkyNDM3OTwvVXNlcklEPg0KICAgICAgICA8T0VNPlRoaXMgaXMgYSByZWRpc3RyaWJ1dGFibGUgbGljZW5zZTwvT0VNPg0KICAgICAgICA8UHJvZHVjdHM+DQogICAgICAgICAgICA8UHJvZHVjdD5Bc3Bvc2UuVG90YWwgUHJvZHVjdCBGYW1pbHk8L1Byb2R1Y3Q+DQogICAgICAgIDwvUHJvZHVjdHM+DQogICAgICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl0aW9uVHlwZT4NCiAgICAgICAgPFNlcmlhbE51bWJlcj57RjJCOTcwNDUtMUIyOS00QjNGLUJENTMtNjAxRUZGQTE1QUE5fTwvU2VyaWFsTnVtYmVyPg0KICAgICAgICA8U3Vic2NyaXB0aW9uRXhwaXJ5PjIwOTkxMjMxPC9TdWJzY3JpcHRpb25FeHBpcnk+DQogICAgICAgIDxMaWNlbnNlVmVyc2lvbj4zLjA8L0xpY2Vuc2VWZXJzaW9uPg0KICAgIDwvRGF0YT4NCiAgICA8U2lnbmF0dXJlPlFYTndiM05sTGxSdmRHRnNMb1B5YjJSMVkzUWdSbUZ0YVd4NTwvU2lnbmF0dXJlPg0KPC9MaWNlbnNlPg==";

                Stream stream = new MemoryStream(Convert.FromBase64String(LData));
                stream.Seek(0, SeekOrigin.Begin);
                new Aspose.Words.License().SetLicense(stream);

                stream = new MemoryStream(Convert.FromBase64String(LData));
                stream.Seek(0, SeekOrigin.Begin);
                new Aspose.Pdf.License().SetLicense(stream);
            }
            catch (Exception)
            {
                Environment.Exit(1);
            }
        }
        private void KyNhay()
        {
            try
            {
                
                if (IDDoc != "")
                {

                    beanDocumentSigner = beanDocumentSigner.SelectAll().Where(s => s.idDocument == IDDoc && s.idUser == currUser.id).FirstOrDefault();

                }
                var lstPosionSign = new
                {
                    LLX = 0,
                    LLY = 0,
                    URX = 0,
                    URY = 0,
                    NumPage = 1,
                    KeyKySo = ""
                };
                if (!string.IsNullOrEmpty(beanDocumentSigner.signaturePosition))
                {
                    lstPosionSign = JsonConvert.DeserializeAnonymousType(beanDocumentSigner.signaturePosition, lstPosionSign);
                }
                BeanDocument beanDocument = new BeanDocument();
                beanDocument = beanDocument.SelectByID(IDDoc);
                byte[] strByte = null;
                using (MemoryStream newStream = new MemoryStream())
                {
                    PdfReader pdfReader = new PdfReader(beanDocument.arrFileSigned);
                    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, newStream))
                    {
                        Rectangle pRectangle1 = new Rectangle(lstPosionSign.LLX, lstPosionSign.LLY, lstPosionSign.URX, lstPosionSign.URY);//
                        Rectangle pageRectangle = pdfReader.GetPageSizeWithRotation(lstPosionSign.NumPage);
                        float x = pRectangle1.Left - Convert.ToInt32(40);
                        float y = pRectangle1.Bottom - Convert.ToInt32(60);
                        float ScaledWidth = Convert.ToInt32(200);
                        float ScaledHeight = Convert.ToInt32(100);
                        #region Lay thong tin hinh anh ky so
                        // string TempPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\DocTemp\\anhkynhay.png";
                        byte[] LogoByte = currUser.imageSignaturePath;
                        using (MemoryStream streamimg = new MemoryStream(LogoByte))
                        {
                            Image imageLogo = Image.GetInstance(streamimg);
                            #region chen thông tin header 
                            PdfContentByte pdfData = pdfStamper.GetOverContent(lstPosionSign.NumPage);
                            imageLogo.SetAbsolutePosition(x, y);
                            imageLogo.ScaleAbsolute(ScaledWidth, ScaledHeight);
                            pdfData.AddImage(imageLogo);
                            #endregion
                            pdfStamper.Close();
                        }
                        #endregion
                    }
                    pdfReader.Close();
                    strByte = newStream.ToArray();
                    newStream.Close();
                }

                updateKySo(strByte);
                MessageBox.Show("Phê duyệt ký thành công!");
                #region saveFile
                string linkfiledownload = ConfigurationManager.AppSettings["UrlSaveFile"];
                string fileSignName = Path.GetFileNameWithoutExtension(beanDocument.fileName);

                if (!Directory.Exists(linkfiledownload + "\\" + fileSignName))
                {
                    Directory.CreateDirectory(linkfiledownload + "\\" + fileSignName);
                }
                string filePath = linkfiledownload + "\\" + fileSignName + "\\" + beanDocument.fileNameSigned;
                if (File.Exists(filePath))
                {
                    FileInfo fi2 = new FileInfo(filePath);
                    fi2.Delete();
                }
                File.WriteAllBytes(filePath, strByte);
                System.Diagnostics.Process.Start(filePath);
                #endregion
                BeanNotify noti = new BeanNotify();
                noti = noti.SelectAll().Where(s => s.RelatedID == IDDoc && s.AssignTo == currUser.id).FirstOrDefault();
                if (noti != null)
                {
                    noti.Modified = DateTime.Now;
                    noti.Status = 1;
                    noti.Update(noti);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                function.TrackingError("EditDocumentSample - KyNhay", ex.ToString());
            }
        }
        private void updateKySo(byte[] arrFile)
        {
            try
            {
                BeanDocumentSigner signer = new BeanDocumentSigner();
                #region update nguoi ky
                beanDocumentSigner.status = true;
                beanDocumentSigner.Modified = DateTime.Now;
                beanDocumentSigner.ModifiedBy = currUser.id;
                beanDocumentSigner.Update(beanDocumentSigner);
                #endregion
                #region update ho so
                BeanDocument beanDocument = new BeanDocument();
                beanDocument = beanDocument.SelectByID(IDDoc);
                beanDocument.arrFileSigned = arrFile;
                signer = signer.SelectAll().Where(s => s.idDocument == IDDoc && s.status == false).FirstOrDefault();
                if (signer == null)
                {
                    beanDocument.status = 2;
                }
                beanDocument.Modified = DateTime.Now;
                beanDocument.ModifiedBy = currUser.id;
                beanDocument.Update(beanDocument);
                #endregion


            }
            catch (Exception ex)
            {
                function.TrackingError("EditDocumentSample - updateKySo", ex.ToString());
            }
        }
        private class MoveToMatchNode : IReplacingCallback
        {
            public string InsertHtml { get; set; }
            ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
            {
                DocumentBuilder builder = new DocumentBuilder((Document)e.MatchNode.Document);
                builder.MoveTo(e.MatchNode);
                builder.InsertHtml(InsertHtml);
                builder.CurrentParagraph.Remove();
                return ReplaceAction.Replace;
            }
        }
        public DataTable GetDataSource()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", IDSample));
            DataTable result = _db.Fill("stor_GetResultSampleByID", parameters);
            return result;
        }
        public void UpdateCompleteDate(bool status)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("sampleID", IDSample));
                parameters.Add(new SqlParameter("status", status));
                DataTable result = _db.Fill("UpdateStatus", parameters);
            }
            catch (Exception ex)
            {
                function.TrackingError("EditDocumentSample - UpdateCompleteDate", ex.ToString());
            }
        }
        private List<ParamDoc> setData(BeanField field)
        {
            BeanSample sample = new BeanSample();
            sample = sample.SelectByID(IDSample);
            List<ParamDoc> result = new List<ParamDoc>();
            string strStyle = "width: 100%; border: 1px solid black; border-collapse: collapse;";
            string strHeader = "font-style: italic; border: 1px solid black; border-collapse: collapse;";
            string strBorder = " border: 1px solid black; border-collapse: collapse;";
            string strHTMl = "";

            if (field.value == "Result")
            {
                DataTable lstResult = GetDataSource();
                ParamDoc param = new ParamDoc();
                param.FieldName = field.name;
                int stt = 1;
                foreach (DataRow item in lstResult.Rows)
                {
                    strHTMl += @"<tr style='" + strBorder + @"'>
<td style='" + strBorder + @";text-align:center'>"+ stt + @"</th>
<td style='" + strBorder + @"'>" + item["Tiêu đề"] + @"</th>
<td style='" + strBorder + @"'>" + sample.name + @"</th>
<td style='" + strBorder + @"'>" + item["Đơn vị"] + @"</th>
<td style='" + strBorder + @"'>" + item["Kết quả mong đợi"] + @"</th>
<td style='" + strBorder + @"'>" + item["Kết luận"] + @"</th>
</tr>";
                    stt++;
                }





                param.strHTML = @"<table style='" + strStyle + @"'>
<tr style='" + strBorder + @"'>
<th style='" + strHeader + @"'><p>STT</p><i>NO</i></th>
<th style='" + strHeader + @"'><p>Tên chỉ tiêu</p><i>Specifications</i></th>
<th style='" + strHeader + @"'><p>Phương pháp thử nghiệm</p><i>Test methods</i></th>
<th style='" + strHeader + @"'><p>Đơn vị</p><i>Unit</i></th>
<th style='" + strHeader + @"'><p>Giá trị cho phép</p><i>Allowed values</i></th>
<th style='" + strHeader + @"'><p>Kết quả</p><i>Result</i></th>
</tr>
                                " + strHTMl + @"
</table>";
                result.Add(param);
            }
            return result;
        }
        private void saveFile(string active)
        {
            try
            {
                BeanTemplate beanTemplate = new BeanTemplate();
                beanTemplate = beanTemplate.SelectByID(IDTemplate);
                //string str = winFormHtmlEditor1.DocumentHtml;
                MemoryStream stre = new MemoryStream(richEditControl1.DocBytes);
                fileSignName = IDDoc.Replace("/", "_");
                MemoryStream ms = new MemoryStream();
                string urlNameSavePDF = Path.GetDirectoryName(Application.ExecutablePath) + "\\fileout\\" + fileSignName + "\\" + fileSignName + ".pdf";
                if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\fileout\\" + fileSignName + "\\"))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + "\\fileout\\" + fileSignName + "\\");
                }
                if (File.Exists(urlNameSavePDF))
                {
                    FileInfo fi2 = new FileInfo(urlNameSavePDF);
                    fi2.Delete();
                }

                //Aspose.Pdf.Document doc = new Aspose.Pdf.Document();
                //Page page = doc.Pages.Add();
                //HtmlFragment htmlFragment = new HtmlFragment(str);
                //page.Paragraphs.Add(htmlFragment);
                //doc.Save(urlNameSavePDF);

                Aspose.Words.Document doDoc = new Aspose.Words.Document(stre);
                if (Path.GetExtension(beanTemplate.fileName).ToLower().Equals(".doc"))
                    doDoc.Save(ms, Aspose.Words.SaveFormat.Doc);
                else
                    doDoc.Save(ms, Aspose.Words.SaveFormat.Docx);
                if (active == "Send")
                    convertToPdf(doDoc, urlNameSavePDF, fileSignName, ms.ToArray());
                else
                    SaveDocSample(null,ms.ToArray(),active);
            }
            catch (Exception ex)
            {
                function.TrackingError("EditDocumentSample - saveFile", ex.ToString());
            }
        }
        private void SaveDocSample(byte[] arrPDF, byte[] arrDoc, string active)
        {
            try
            {
                BeanDocument bean = new BeanDocument();
                try
                {
                    bean = bean.SelectByID(IDDoc);
                    if(bean != null)
                    {
                        bean.name = "Hồ sơ số: " + IDDoc;
                        bean.fileName = fileSignName + ".pdf";
                        bean.fileNameSigned = fileSignName + "_signed.pdf";
                        bean.idSample = IDSample;
                        bean.idTemplate = IDTemplate;
                        bean.ModifiedBy = currUser.id;
                        bean.Modified = DateTime.Now;
                        if (active == "Save")
                        {
                            bean.arrFileDocSigned = arrDoc;
                            bean.status = 0;
                            bean.Update(bean);
                            delDocSigner();
                            BeanCustomer beanCustomer = new BeanCustomer();
                            BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
                            int stt = 1;
                            foreach (ParamDocSigner item in lstbeanDocSigner)
                            {
                                beanCustomer = beanCustomer.SelectByID(item.id);
                                beanDocumentSigner.idUser = item.id;
                                beanDocumentSigner.idDocument = IDDoc;
                                beanDocumentSigner.index = stt;
                                beanDocumentSigner.status = false;
                                beanDocumentSigner.ModifiedBy = beanDocumentSigner.CreatedBy = currUser.id;
                                beanDocumentSigner.Modified = beanDocumentSigner.Created = DateTime.Now;
                                beanDocumentSigner.Insert(beanDocumentSigner);
                                stt++;
                            }
                           
                        }
                        else
                        {
                            bean.arrFileDocSigned = arrDoc;
                            bean.arrFilePDF = arrPDF;
                            bean.arrFileSigned = arrPDF;
                            bean.status = 1;
                            bean.Update(bean);
                            delDocSigner();
                            BeanCustomer beanCustomer = new BeanCustomer();
                            BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
                            int stt = 1;
                            foreach (ParamDocSigner item in lstbeanDocSigner)
                            {
                                beanCustomer = beanCustomer.SelectByID(item.id);
                                beanDocumentSigner.idUser = item.id;
                                beanDocumentSigner.idDocument = IDDoc;
                                beanDocumentSigner.signaturePosition = item.position;
                                beanDocumentSigner.index = stt;
                                beanDocumentSigner.status = false;
                                beanDocumentSigner.ModifiedBy = beanDocumentSigner.CreatedBy = currUser.id;
                                beanDocumentSigner.Modified = beanDocumentSigner.Created = DateTime.Now;
                                beanDocumentSigner.Insert(beanDocumentSigner);
                                stt++;
                            }
                           
                        }
                       
                       
                    }
                    else
                    {
                        bean = new BeanDocument();
                        bean.id = IDDoc;
                        bean.name = "Hồ sơ số: " + IDDoc;
                        bean.fileName = fileSignName + ".pdf";
                        bean.fileNameSigned = fileSignName + "_signed.pdf";
                        bean.idSample = IDSample;
                        bean.idTemplate = IDTemplate;
                        bean.ModifiedBy = bean.CreatedBy = currUser.id;
                        bean.Modified = bean.Created = DateTime.Now;
                        if (active == "Save")
                        {
                            bean.arrFileDocSigned = arrDoc;
                            bean.status = 0;
                            bean.Insert(bean);
                            delDocSigner();
                            BeanCustomer beanCustomer = new BeanCustomer();
                            BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
                            int stt = 1;
                            foreach (ParamDocSigner item in lstbeanDocSigner)
                            {
                                beanCustomer = beanCustomer.SelectByID(item.id);
                                beanDocumentSigner.idUser = item.id;
                                beanDocumentSigner.idDocument = IDDoc;
                                beanDocumentSigner.index = stt;
                                beanDocumentSigner.status = false;
                                beanDocumentSigner.ModifiedBy = beanDocumentSigner.CreatedBy = currUser.id;
                                beanDocumentSigner.Modified = beanDocumentSigner.Created = DateTime.Now;
                                beanDocumentSigner.Insert(beanDocumentSigner);
                                stt++;
                            }
                           
                        }
                        else
                        {
                            bean.arrFileDocSigned = arrDoc;
                            bean.arrFilePDF = arrPDF;
                            bean.arrFileSigned = arrPDF;
                            bean.status = 1;
                            bean.Insert(bean);
                            delDocSigner();
                            BeanCustomer beanCustomer = new BeanCustomer();
                            BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
                            int stt = 1;
                            foreach (ParamDocSigner item in lstbeanDocSigner)
                            {
                                beanCustomer = beanCustomer.SelectByID(item.id);
                                beanDocumentSigner.idUser = item.id;
                                beanDocumentSigner.idDocument = IDDoc;
                                beanDocumentSigner.signaturePosition = item.position;
                                beanDocumentSigner.index = stt;
                                beanDocumentSigner.status = false;
                                beanDocumentSigner.ModifiedBy = beanDocumentSigner.CreatedBy = currUser.id;
                                beanDocumentSigner.Modified = beanDocumentSigner.Created = DateTime.Now;
                                beanDocumentSigner.Insert(beanDocumentSigner);
                                stt++;
                            }
                        }
                       
                       
                    }
                    UpdateCompleteDate(true);
                }
                catch(Exception ex1)
                {
                    bean = new BeanDocument();
                    bean.id = IDDoc;
                    bean.name = "Hồ sơ số: " + IDDoc;
                    bean.fileName = fileSignName + ".pdf";
                    bean.fileNameSigned = fileSignName + "_signed.pdf";
                    bean.idSample = IDSample;
                    bean.idTemplate = IDTemplate;
                    bean.ModifiedBy = bean.CreatedBy = currUser.id;
                    bean.Modified = bean.Created = DateTime.Now;
                    if (active == "Save")
                    {
                        bean.arrFileDocSigned = arrDoc;
                        bean.status = 0;
                        bean.Insert(bean);
                        delDocSigner();
                        BeanCustomer beanCustomer = new BeanCustomer();
                        BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
                        int stt = 1;
                        foreach (ParamDocSigner item in lstbeanDocSigner)
                        {
                            beanCustomer = beanCustomer.SelectByID(item.id);
                            beanDocumentSigner.idUser = item.id;
                            beanDocumentSigner.idDocument = IDDoc;
                            beanDocumentSigner.index = stt;
                            beanDocumentSigner.status = false;
                            beanDocumentSigner.ModifiedBy = beanDocumentSigner.CreatedBy = currUser.id;
                            beanDocumentSigner.Modified = beanDocumentSigner.Created = DateTime.Now;
                            beanDocumentSigner.Insert(beanDocumentSigner);
                            stt++;
                        }
                       
                    }
                    else
                    {
                        bean.arrFileDocSigned = arrDoc;
                        bean.arrFilePDF = arrPDF;
                        bean.arrFileSigned = arrPDF;
                        bean.status = 1;
                        bean.Insert(bean);
                        delDocSigner();
                        BeanCustomer beanCustomer = new BeanCustomer();
                        BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
                        int stt = 1;
                        foreach (ParamDocSigner item in lstbeanDocSigner)
                        {
                            beanCustomer = beanCustomer.SelectByID(item.id);
                            beanDocumentSigner.idUser = item.id;
                            beanDocumentSigner.idDocument = IDDoc;
                            beanDocumentSigner.signaturePosition = item.position;
                            beanDocumentSigner.index = stt;
                            beanDocumentSigner.status = false;
                            beanDocumentSigner.ModifiedBy = beanDocumentSigner.CreatedBy = currUser.id;
                            beanDocumentSigner.Modified = beanDocumentSigner.Created = DateTime.Now;
                            beanDocumentSigner.Insert(beanDocumentSigner);
                            stt++;
                        }
                    }
                    UpdateCompleteDate(true);
                }
                if (RequestChanged)
                {
                    CompletedNotify(currUser.id, IDDoc);
                }
            }
            catch (Exception ex)
            {
                function.TrackingError("EditDocumentSample - SaveDocSample", ex.ToString());
            }
        }
        private void btnSaveFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFile("Save");
            MessageBox.Show("Lưu thành công!");
        }
        private void SetNotify(Guid NgKiemThu, string idDocument)
        {
            BeanNotify ModelNotify = new BeanNotify();
            ModelNotify.RelatedID = idDocument;
            ModelNotify.Status = 0;
            ModelNotify.Title = "Bạn có yêu cầu ký số mới: " + idDocument;
            ModelNotify.Category = "Document";
            ModelNotify.AssignTo = NgKiemThu;
            ModelNotify.Created = DateTime.Now;
            ModelNotify.CreatedBy = currUser.id;
            ModelNotify.Insert(ModelNotify);
        }
        private void DelNotify(Guid NgKiemThu, string idDocument)
        {
            BeanNotify ModelNotify = new BeanNotify();
            ModelNotify = ModelNotify.SelectAll().Where(s => s.AssignTo == NgKiemThu && s.RelatedID == idDocument && s.Category == "Document").FirstOrDefault();
            if (ModelNotify != null)
            {
                ModelNotify.Delete(ModelNotify);
            }
        }
        private void CompletedNotify(Guid NgKiemThu, string idDoc)
        {
            BeanNotify ModelNotify = new BeanNotify();
            ModelNotify = ModelNotify.SelectAll().Where(s => s.AssignTo == NgKiemThu && s.RelatedID == idDoc && s.Status == 0 && s.Category.Contains("Yêu cầu điều chỉnh")).FirstOrDefault();
            if (ModelNotify != null)
            {
                ModelNotify.Status = 1;
                ModelNotify.Modified = DateTime.Now;
                ModelNotify.Update(ModelNotify);
            }
        }
        private void btn_sign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KyNhay();
        }

        private void SetDbCombobox()
        {
            BeanCustomer beanCustomer = new BeanCustomer();
            cb_DocSigner.DisplayMember = "fullName";
            cb_DocSigner.ValueMember = "id";
            cb_DocSigner.DataSource = beanCustomer.SelectAll();
            cb_DocSigner.SelectedIndex = -1;
        }
        private void btn_AddSigner_Click(object sender, EventArgs e)
        {
            //BeanDocumentSigner beanDocument = new BeanDocumentSigner();
            //if(cb_DocSigner.SelectedValue != null)
            //{
            //    beanDocument.idUser = Guid.Parse(cb_DocSigner.SelectedValue + "");
            //    beanDocument.idDocument = IDDoc;
            //    beanDocument.status = false;
            //    beanDocument.index = lstbeanDocSigner.Count + 1;
            //    lstbeanDocSigner.Add(beanDocument);
            //    setDataGrid(lstbeanDocSigner);
            //}
            ParamDocSigner beanParamDoc = new ParamDocSigner();
            if (cb_DocSigner.SelectedValue != null)
            {

                if (lstbeanDocSigner.Count == 0)
                {
                    beanParamDoc.id = Guid.Parse(cb_DocSigner.SelectedValue + "");
                    beanParamDoc.name = cb_DocSigner.Text;
                    lstbeanDocSigner.Add(beanParamDoc);
                    setDataGrid(lstbeanDocSigner);
                }
                else
                {
                    var check = lstbeanDocSigner.Where(s => s.id == Guid.Parse(cb_DocSigner.SelectedValue + "")).FirstOrDefault();
                    if (check == null)
                    {
                        beanParamDoc.id = Guid.Parse(cb_DocSigner.SelectedValue + "");
                        beanParamDoc.name = cb_DocSigner.Text;
                        lstbeanDocSigner.Add(beanParamDoc);
                        setDataGrid(lstbeanDocSigner);
                    }
                }

            }
            
        }
        private void setDataGrid(List<ParamDocSigner> data)
        {
            BindingSource bSource = new BindingSource();
            bSource.DataSource = data;
            grid_UserSigned.DataSource = bSource;
            grid_UserSigned.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(grid_UserSigned.SelectedRows[0].Cells[0].Value + ""))
            {
                lstbeanDocSigner = lstbeanDocSigner.Where(s => s.id != Guid.Parse(grid_UserSigned.SelectedRows[0].Cells[0].Value + "")).ToList();
                setDataGrid(lstbeanDocSigner);
            }
        }

        private void btn_SendDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveFile("Send");
            foreach(ParamDocSigner item in lstbeanDocSigner)
            {
                DelNotify(item.id, IDDoc);
                SetNotify(item.id, IDDoc);
            }
            MessageBox.Show("Gửi thành công!");
            this.Close();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_AddSigner_Click_1(object sender, EventArgs e)
        {
            ParamDocSigner beanParamDoc = new ParamDocSigner();
            if (cb_DocSigner.SelectedValue != null)
            {

                if (lstbeanDocSigner.Count == 0)
                {
                    beanParamDoc.id = Guid.Parse(cb_DocSigner.SelectedValue + "");
                    beanParamDoc.name = cb_DocSigner.Text;
                    lstbeanDocSigner.Add(beanParamDoc);
                    setDataGrid(lstbeanDocSigner);
                }
                else
                {
                    var check = lstbeanDocSigner.Where(s => s.id == Guid.Parse(cb_DocSigner.SelectedValue + "")).FirstOrDefault();
                    if (check == null)
                    {
                        beanParamDoc.id = Guid.Parse(cb_DocSigner.SelectedValue + "");
                        beanParamDoc.name = cb_DocSigner.Text;
                        lstbeanDocSigner.Add(beanParamDoc);
                        setDataGrid(lstbeanDocSigner);
                    }
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(grid_UserSigned.SelectedRows[0].Cells[0].Value + ""))
            {
                lstbeanDocSigner = lstbeanDocSigner.Where(s => s.id != Guid.Parse(grid_UserSigned.SelectedRows[0].Cells[0].Value + "")).ToList();
                setDataGrid(lstbeanDocSigner);
            }
        }

        private void btnDownLoadPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UrlPageSave page = new UrlPageSave();
            page.strTitle = "ExportPDF";
            page.StartPosition = FormStartPosition.CenterScreen;
            page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
            page.ShowDialog();
           
        }
        private void Form1_FormClosing(Object sender, FormClosedEventArgs e)
        {
            try
            {
                BeanUrlSave bean = new BeanUrlSave();
                bean = bean.SelectByID("ExportPDF");
                if (!string.IsNullOrEmpty(bean.urlLink))
                {
                    BeanDocument beanDocument = new BeanDocument();
                    beanDocument = beanDocument.SelectByID(IDDoc);
                    try
                    {
                        File.WriteAllBytes(bean.urlLink + beanDocument.fileName, beanDocument.arrFilePDF);

                    }
                    catch
                    {
                        File.WriteAllBytes(bean.urlLink + "\\"+beanDocument.fileName, beanDocument.arrFilePDF);
                    }
                    DialogResult dialogResult = MessageBox.Show("Tải xuống thành công! Bạn có muốn mở file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(bean.urlLink + beanDocument.fileName);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn đường dẫn lưu file!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy đường dẫn lưu file!");
                function.TrackingError("EditDocumentSample - Form1_FormClosing", "Không tìm thấy đường dẫn lưu file!");
            }
        }

        private void btnSavePDFSigned_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UrlPageSave page = new UrlPageSave();
            page.strTitle = "ExportPDF";
            page.StartPosition = FormStartPosition.CenterScreen;
            page.FormClosed += new FormClosedEventHandler(ExportPDFSigned_FormClosing);
            page.ShowDialog();
        }
        private void ExportPDFSigned_FormClosing(Object sender, FormClosedEventArgs e)
        {
            try
            {
                BeanUrlSave bean = new BeanUrlSave();
                bean = bean.SelectByID("ExportPDF");
                if (!string.IsNullOrEmpty(bean.urlLink))
                {
                    BeanDocument beanDocument = new BeanDocument();
                    beanDocument = beanDocument.SelectByID(IDDoc);
                    try
                    {
                        File.WriteAllBytes(bean.urlLink + beanDocument.fileNameSigned, beanDocument.arrFileSigned);

                    }
                    catch
                    {
                        File.WriteAllBytes(bean.urlLink + "\\" + beanDocument.fileNameSigned, beanDocument.arrFileSigned);
                    }
                    DialogResult dialogResult = MessageBox.Show("Tải xuống thành công! Bạn có muốn mở file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(bean.urlLink + beanDocument.fileNameSigned);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn đường dẫn lưu file!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy đường dẫn lưu file!");
                function.TrackingError("EditDocumentSample - Form1_FormClosing", "Không tìm thấy đường dẫn lưu file!");
            }
        }
    }

    public class ParamDoc
    {
        public string strHTML { get; set; }
        public string FieldName { get; set; }
       
    }
    public class ParamDocSigner
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string status { get; set; } = "Chưa ký";
        public string position { get; set; } 

    }
}
