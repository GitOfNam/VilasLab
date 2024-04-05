using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VilasLab.Base;
using VilasLab.Models;
using DataTable = System.Data.DataTable;
using excel = Microsoft.Office.Interop.Excel;

namespace VilasLab.Pages
{
    public partial class AllResultPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        public string IDSample { get; set; } = "";
        public string IDResult = "";
        int level = 1;
        public AllResultPage()
        {
            InitializeComponent();
            
        }
        private void checkPermission()
        {
            BeanCustomer customer = new BeanCustomer();
            BeanPermission permission = new BeanPermission();
            customer = customer.SelectByID(currUser.id);
            if (customer.idPermission != null)
            {
                level = permission.SelectByID(customer.idPermission).level;
            }

            if (level == 1)
            {
                btnExportDoc.Visibility = BarItemVisibility.Never;
            }

        }
        public DataTable GetDataSource()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", IDSample));
            DataTable result = _db.Fill("stor_GetResultSampleByID",parameters);
            return result;
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            ResultSample page = new ResultSample();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.ShowDialog();
        }

        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if(level != 1)
            {
                bbiDelete.Visibility = BarItemVisibility.Always;
                bbiEdit.Visibility = BarItemVisibility.Always;
            }
            IDResult = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[0] + string.Empty;
            if (!string.IsNullOrEmpty(IDSample))
            {
                BeanDocument document = new BeanDocument();
                var checkTemplate1 = document.SelectAll().Where(s => s.idSample == IDSample && s.status != 0 && s.idTemplate == 1).FirstOrDefault();
                if(checkTemplate1 != null)
                {
                    btnExportDoc.Visibility = BarItemVisibility.Never;
                }
                else
                {
                    btnExportDoc.Visibility = BarItemVisibility.Always;
                }
                var checkTemplate2 = document.SelectAll().Where(s => s.idSample == IDSample && s.status != 0 && s.idTemplate == 2).FirstOrDefault();
                if (checkTemplate2 != null)
                {
                    btnExportTest.Visibility = BarItemVisibility.Never;
                }
                else
                {
                    btnExportTest.Visibility = BarItemVisibility.Always;
                }
            }
        }

        private void AllResultPage_Load(object sender, EventArgs e)
        {
            btnExportExcel.Visibility = BarItemVisibility.Never;
            this.Text = "Tất cả kết quả của mẫu " + IDSample;
            checkPermission();
            bbiDelete.Visibility = BarItemVisibility.Never;
            bbiEdit.Visibility = BarItemVisibility.Never;
            GetData();

        }
        private void GetData() {

            DataTable dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            gridView.Columns[0].Visible = false;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.Rows.Count;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            IDResult = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[0] + string.Empty;
            ResultSample page = new ResultSample();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.IDResult = IDResult;
            page.ShowDialog();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetData();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                IDResult = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[0] + string.Empty;
                if (!string.IsNullOrEmpty(IDResult))
                {
                    var mes = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mes == DialogResult.Yes)
                    {
                        BeanResult result = new BeanResult();
                        result = result.SelectByID(Guid.Parse(IDResult)); 
                        result.Delete(result);
                        GetData();
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

        private void btnExportDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditDocumentSample page = new EditDocumentSample();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.IDResult = IDResult;
            page.WindowState = FormWindowState.Maximized;
            page.ShowDialog();
            this.Hide();
        }

        private void btnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            UrlPageSave page = new UrlPageSave();
            page.strTitle = "ExportExcel";
            page.StartPosition = FormStartPosition.CenterScreen;
            page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
            page.ShowDialog();
        }
        private void Form1_FormClosing(Object sender, FormClosedEventArgs e)
        {
            try
            {
                BeanUrlSave bean = new BeanUrlSave();
                bean = bean.SelectByID("ExportExcel");
                if (!string.IsNullOrEmpty(bean.urlLink))
                {
                    //function.exportExcelResult(bean.urlLink, IDSample);
                    
                }
                else
                {
                    string urlFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                    //function.exportExcelResult(urlFolder, IDSample);
                }
                MessageBox.Show("Thành công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không tìm thấy đường dẫn lưu file!");
            }
        }

        private void btnExportTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditDocumentSample page = new EditDocumentSample();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.IDResult = IDResult;
            page.IDTemplate = 2;
            page.WindowState = FormWindowState.Maximized;
            page.ShowDialog();
            this.Hide();
        }
    }
}