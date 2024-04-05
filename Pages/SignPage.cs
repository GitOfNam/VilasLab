using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VilasLab.Base;
using VilasLab.Models;
using Rectangle = iTextSharp.text.Rectangle;
using Document = Aspose.Words.Document;
using Color = System.Drawing.Color;
using Image = iTextSharp.text.Image;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

namespace VilasLab.Pages
{
    public partial class SignPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public BeanCustomer currUser { get; set; }
        public string IDSample { get; set; } = "";
        public string IDResult { get; set; } = "";
        public string IDDoc { get; set; } = "";
        string urlSave = "";
        private BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
        public SignPage()
        {
            InitializeComponent();
        }

        private void btn_Signed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KyNhay();
        }
        private void KyNhay()
        {
            try
            {
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
                FileStream file = new FileStream(urlSave, FileMode.Open);
                string fileName = Path.GetFileNameWithoutExtension(file.Name);
                string fileExt = Path.GetExtension(file.Name);
                string urlNameSave = "\\fileout\\" + IDDoc + "\\" + IDDoc + "_signed.pdf";
                byte[] strByte = null;
                using (MemoryStream newStream = new MemoryStream())
                {
                    PdfReader pdfReader = new PdfReader(file);
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
                            PdfContentByte pdfData = pdfStamper.GetOverContent(1);
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
                File.WriteAllBytes(urlNameSave, strByte);
                updateKySo(strByte);
                MessageBox.Show("Phê duyệt ký thành công!");
                BeanNotify noti = new BeanNotify();
                noti = noti.SelectAll().Where(s => s.RelatedID == IDDoc).FirstOrDefault();
                if(noti != null)
                {
                    noti.Modified = DateTime.Now;
                    noti.Status = 1;
                    noti.Update(noti);
                }
                this.Close();
            }
            catch (Exception ex)
            {
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
                signer = signer.SelectAll().Where(s => s.idDocument == IDDoc && s.idUser == currUser.id && s.status == false).FirstOrDefault();
                if(signer == null)
                {
                    beanDocument.status = 2;
                }
                beanDocument.Modified = DateTime.Now;
                beanDocument.ModifiedBy = currUser.id;
                beanDocument.Update(beanDocument);
                #endregion


            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi : " + ex.ToString());
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
        private void SignPage_Load(object sender, EventArgs e)
        {
            CheckLicenseAspose();
            loadData();
            CheckFile();
            ShowData();

        }
        private void loadData()
        {
            if (IDDoc != "")
            {
               
                beanDocumentSigner = beanDocumentSigner.SelectAll().Where(s => s.idDocument == IDDoc && s.idUser == currUser.id).FirstOrDefault();
                
            }
        }
        private void CheckFile()
        {
            
            try
            {
                string urlFolder = Path.GetDirectoryName(Application.ExecutablePath) + "\\fileout\\" + IDDoc + "\\";
                if (!Directory.Exists(urlFolder))
                {
                    Directory.CreateDirectory(urlFolder);
                }
                urlSave = urlFolder + IDDoc + "_signed.pdf";
                
                if (File.Exists(urlSave))
                {
                    FileInfo fi3 = new FileInfo(urlSave);
                    fi3.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: CheckFile - SignPage" + ex.ToString());

            }
            
        }
        private void ShowData()
        {
            BeanDocument beanDocument = new BeanDocument();
            beanDocument = beanDocument.SelectByID(IDDoc);
            MemoryStream ms = new MemoryStream(beanDocument.arrFileSigned);
            Document doc = new Document(ms);
            doc.Save(ms, Aspose.Words.SaveFormat.Docx);
            var options2 = new Aspose.Words.Saving.HtmlSaveOptions(Aspose.Words.SaveFormat.Html)
            {

            };
            string html = doc.FirstSection.Body.ToString(options2);
            //winFormHtmlEditor1.DocumentHtml = html;
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnResign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommentPage page = new CommentPage();
            page.currUser = currUser;
            page.IDDoc = IDDoc;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }
    }
    
}
