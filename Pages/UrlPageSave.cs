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

namespace VilasLab.Pages
{
    public partial class UrlPageSave : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public string strTitle = "";
        public UrlPageSave()
        {
            InitializeComponent();
        }
        
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                BeanUrlSave bean = new BeanUrlSave();
                bean = bean.SelectByID(txtTitle.Text);
                if (bean != null)
                {
                    bean.urlLink = txtURL.Text;
                    bean.isRemember = cbRemember.Checked;
                    bean.Update(bean);
                }
                else
                {
                    bean = new BeanUrlSave();
                    bean.title = txtTitle.Text;
                    bean.urlLink = txtURL.Text;
                    bean.isRemember = cbRemember.Checked;
                    bean.Insert(bean);
                }
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void UrlPageSave_Load(object sender, EventArgs e)
        {
            bbiClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            BeanUrlSave bean = new BeanUrlSave();
            if (!string.IsNullOrEmpty(strTitle))
            {
                bean = bean.SelectByID(strTitle);
                if(bean != null)
                {
                    txtTitle.Text = bean.title;
                    if (bean.isRemember)
                    {
                        txtURL.Text = bean.urlLink;
                        cbRemember.Checked = bean.isRemember;
                    }
                }
                else
                {
                    txtTitle.Text = strTitle;
                    bbiClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                    
            }
            GetDataGrid();
        }
        private void GetDataGrid()
        {
            var dataSource = GetDataSource();
            gridControl1.DataSource = dataSource;
            gridView1.Columns[0].Caption = "Tiêu đề";
            gridView1.Columns[1].Caption = "Đường dẫn";
            gridView1.Columns[2].Caption = "Lưu mặc định";
        }
        public DataTable GetDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tiêu đề");
            dt.Columns.Add("Đường dẫn");
            dt.Columns.Add("Lưu mặc định");
            BeanUrlSave bean = new BeanUrlSave();
            List<BeanUrlSave> lst = bean.SelectAll();
            if(lst != null && lst.Count > 0)
            {
                foreach(BeanUrlSave item in lst)
                {
                    DataRow row = dt.NewRow();
                    row[0] = item.title;
                    row[1] = item.urlLink;
                    row[2] = item.isRemember;
                    dt.Rows.Add(row);
                }
               
            }
            return dt;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            strTitle = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[0] + string.Empty;
            selectData();
        }
        private void selectData()
        {
            BeanUrlSave bean = new BeanUrlSave();
            if (!string.IsNullOrEmpty(strTitle))
            {
                bean = bean.SelectByID(strTitle);
                if (bean != null)
                {
                    txtTitle.Text = bean.title;
                    txtURL.Text = bean.urlLink;
                    cbRemember.Checked = bean.isRemember;

                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtURL.Text = openFileDialog.SelectedPath;
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void gridView1_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            strTitle = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[0] + string.Empty;
            selectData();
        }
    }
}
