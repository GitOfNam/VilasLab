using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VilasLab.Base;
using VilasLab.Models;

namespace VilasLab.Pages
{
    public partial class AllDocumentPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public BeanCustomer currUser { get; set; }
        string idSample = "",idDoc="";
        int idTemp = 1;
        public AllDocumentPage()
        {
            InitializeComponent();
           
        }
        private void reloadDataGrid()
        {
            DataTable dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            gridView.Columns[3].Visible = false;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.Rows.Count;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public DataTable GetDataSource()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("UserID", currUser.id));
            parameters.Add(new SqlParameter("FromDate",dt_FromDate.DateTime));
            parameters.Add(new SqlParameter("ToDate", dt_ToDate.DateTime));
            DataTable result = _db.Fill("stor_GetDataDoc", parameters);
            return result;
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            reloadDataGrid();
        }

        private void AllDocumentPage_Load(object sender, EventArgs e)
        {
            bbiDelete.Visibility = BarItemVisibility.Never;
            bbiEdit.Visibility = BarItemVisibility.Never;
            bbiNew.Visibility = BarItemVisibility.Never;
            dt_FromDate.DateTime = DateTime.Now.AddDays(-30);
            dt_ToDate.DateTime = DateTime.Now;
            reloadDataGrid();
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                idDoc = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
                idSample = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[3] + string.Empty;
                idTemp = Convert.ToInt32(gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[4] + string.Empty);
                bbiNew.Visibility = BarItemVisibility.Always;
                if (gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[5] + string.Empty == "Đang lưu")
                {
                    bbiDelete.Visibility = BarItemVisibility.Always;
                    bbiEdit.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    bbiDelete.Visibility = BarItemVisibility.Never;
                    bbiEdit.Visibility = BarItemVisibility.Never;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditDocumentSample page = new EditDocumentSample();
            page.currUser = currUser;
            page.IDDoc = idDoc;
            page.IDSample = idSample;
            page.WindowState = FormWindowState.Maximized;
            page.ShowDialog();

        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditDocumentSample page = new EditDocumentSample();
            page.currUser = currUser;
            page.IDDoc = idDoc;
            page.IDSample = idSample;
            page.WindowState = FormWindowState.Maximized;
            page.ShowDialog();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(idDoc))
                {
                    var mes = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mes == DialogResult.Yes)
                    {
                        BeanDocument bean = new BeanDocument();
                        bean = bean.SelectByID(idDoc);
                        delDocSigner();
                        bean.Delete(bean);
                        reloadDataGrid();
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
        private void delDocSigner()
        {
            BeanDocumentSigner beanDocumentSigner = new BeanDocumentSigner();
            List<BeanDocumentSigner> lst = new List<BeanDocumentSigner>();
            lst = beanDocumentSigner.SelectAll().Where(s => s.idDocument == idDoc).ToList();
            if (lst.Count > 0)
            {
                foreach (BeanDocumentSigner item in lst)
                {
                    item.Delete(item);
                }
            }
        }

        private void btnSearchDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            reloadDataGrid();
        }

        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }
    }
}