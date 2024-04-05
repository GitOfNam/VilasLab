using Aspose.Words;
using DevExpress.XtraBars;
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
using Document = Aspose.Words.Document;

namespace VilasLab.Pages
{
    public partial class TemplateSettingPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public BeanCustomer currUser { get; set; }
        public int strID = 0;
        byte[] arrFile = null;
        public TemplateSettingPage()
        {
            InitializeComponent();

        }
        private void FactorySettingPage_Load(object sender, EventArgs e)
        {
            CheckLicenseAspose();
            txtFileName.Enabled = false;
            PrepareData();
        }
        private void PrepareData()
        {
            BeanTemplate bean = new BeanTemplate();
            if (strID != 0)
            {
                bean = bean.SelectByID(strID);
                txt_Name.Text = bean.name;
                txtFileName.Text = bean.fileName;
                if (bean.arrFileDoc != null)
                {
                    arrFile = bean.arrFileDoc;
                    MemoryStream newStream = new MemoryStream(bean.arrFileDoc);
                    richEditControl1.DocBytes = newStream.ToArray();
                }
            }
            else
            {
                ribbonPageGroup1.Visible = false;
            }
        }
        private void SaveData()
        {
            BeanTemplate bean = new BeanTemplate();
            saveFile();
            if (arrFile != null && !string.IsNullOrEmpty(txt_Name.Text))
            {
                if (strID != 0)
                {
                    bean = bean.SelectByID(strID);
                    bean.name = txt_Name.Text;
                    bean.fileName = txtFileName.Text;
                    bean.arrFileDoc = arrFile;
                    bean.ModifiedBy = currUser.id;
                    bean.Modified = DateTime.Now;
                    bean.Update(bean);

                }
                else
                {
                    bean.name = txt_Name.Text;
                    bean.fileName = txtFileName.Text;
                    bean.arrFileDoc = arrFile;
                    bean.ModifiedBy = bean.CreatedBy = currUser.id;
                    bean.Modified = bean.Created = DateTime.Now;
                    bean.Insert(bean);
                    strID = bean.id;
                }
                MessageBox.Show("Thành công!");
                ribbonPageGroup1.Visible = true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            }
        }

        private void refreshData()
        {
            txt_Name.Text = "";
            txtFileName.Text = "";
            richEditControl1.Text = "";
            strID = 0;
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (strID != 0)
                {
                    var mes = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mes == DialogResult.Yes)
                    {
                        BeanTemplate bean = new BeanTemplate();
                        bean = bean.SelectByID(strID);
                        bean.Delete(bean);
                        MessageBox.Show("Thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nội dung cần xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
            this.Close();
        }

        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
            refreshData();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            refreshData();
        }
        private void saveFile()
        {
            try
            {
                MemoryStream ms = new MemoryStream(richEditControl1.DocBytes);
                Aspose.Words.Document doDoc = new Aspose.Words.Document(ms);
                if (Path.GetExtension(txtFileName.Text).ToLower().Equals(".doc"))
                    doDoc.Save(ms, Aspose.Words.SaveFormat.Doc);
                else
                    doDoc.Save(ms, Aspose.Words.SaveFormat.Docx);
                arrFile = ms.ToArray();
            }
            catch (Exception ex)
            {

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
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Word File (.docx ,.doc)|*.docx;*.doc;";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    arrFile = File.ReadAllBytes(openFileDialog.FileName);
                    txtFileName.Text = openFileDialog.SafeFileName;
                    FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open);
                    Document doc = new Document(file);
                    MemoryStream newStream = new MemoryStream();
                    if (Path.GetExtension(txtFileName.Text).ToLower().Equals(".doc"))
                        doc.Save(newStream, Aspose.Words.SaveFormat.Doc);
                    else
                        doc.Save(newStream, Aspose.Words.SaveFormat.Docx);
                    richEditControl1.DocBytes = newStream.ToArray();
                    file.Close();
                }
            }
        }

        private void btnShowFieldSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(strID != 0)
            {
                AllFieldSetting page = new AllFieldSetting();
                page.currUser = currUser;
                page.TempID = strID;
                page.StartPosition = FormStartPosition.CenterScreen;
                page.ShowDialog();
            }
        }
    }
}
