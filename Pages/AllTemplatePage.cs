using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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

namespace VilasLab.Pages
{
    public partial class AllTemplatePage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public BeanCustomer currUser { get; set; }
        public AllTemplatePage()
        {
            InitializeComponent();
        }
        private void CustomerPage_Load(object sender, EventArgs e)
        {
            btnDel.Visibility = BarItemVisibility.Never;
            btnEdit.Visibility = BarItemVisibility.Never;
            ribbonPageGroup2.Visible = false;
            GetData();
            CheckLicenseAspose();
        }
        private void GetData()
        {
            dataGridView1.DataSource = GetDataSource();
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[3].Width = 200;
        }
        public List<BeanTemplate> GetDataSource()
        {
            BeanTemplate beanTemplate = new BeanTemplate();
            List<BeanTemplate> result = beanTemplate.SelectAll();
            return result;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDel.Visibility = BarItemVisibility.Always;
            btnEdit.Visibility = BarItemVisibility.Always;
            ribbonPageGroup2.Visible = true;
        }

        private void btnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty))
                {
                    var mes = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mes == DialogResult.Yes)
                    {
                        BeanTemplate cus = new BeanTemplate();
                        cus.SelectByID(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty));
                        if (cus.id != 0)
                        {
                            cus.Delete(cus);
                            GetData();
                            MessageBox.Show("Xóa thành công!");
                        }
                        else
                            MessageBox.Show("Không tìm thấy thông tin cần xóa!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin cần xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty))
                {
                    TemplateSettingPage page = new TemplateSettingPage();
                    page.strID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty);
                    page.currUser = currUser;
                    page.StartPosition = FormStartPosition.CenterScreen;
                    page.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                TemplateSettingPage page = new TemplateSettingPage();
                page.currUser = currUser;
                page.StartPosition = FormStartPosition.CenterScreen;
                page.WindowState = FormWindowState.Maximized;
                page.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
        }

        private void btnShowFieldSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            AllFieldSetting page = new AllFieldSetting();
            page.currUser = currUser;
            page.TempID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty);
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btnDownloadTemplate_ItemClick(object sender, ItemClickEventArgs e)
        {
            UrlPageSave page = new UrlPageSave();
            page.strTitle = "TemplateURL";
            page.StartPosition = FormStartPosition.CenterScreen;
            page.FormClosed += new FormClosedEventHandler(SaveTemplate);
            page.ShowDialog();
        }
        private void SaveTemplate(Object sender, FormClosedEventArgs e)
        {
            try
            {
                BeanUrlSave bean = new BeanUrlSave();
                bean = bean.SelectByID("TemplateURL");
                int IDTemp = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty);
                BeanTemplate temp = new BeanTemplate();
                temp = temp.SelectByID(IDTemp);
                if (!string.IsNullOrEmpty(bean.urlLink))
                {
                    try
                    {
                        File.WriteAllBytes(bean.urlLink + temp.fileName, temp.arrFileDoc);
                    }
                    catch
                    {
                        File.WriteAllBytes(bean.urlLink + "\\" + temp.fileName, temp.arrFileDoc);
                    }
                    MessageBox.Show("Lưu mẫu thành công!");
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn đường dẫn lưu file!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy đường dẫn lưu file!");
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
    }
}