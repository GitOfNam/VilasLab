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

namespace VilasLab.Pages
{
    public partial class MachineSettingPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        public string idFactory { get; set; } = "";
        int strID = 0;
        public MachineSettingPage()
        {
            InitializeComponent();
        }
        private void GetDataGrid()
        {
            DataTable dataSource = GetDataSource();
            gridControl1.DataSource = dataSource;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[3].Visible = false;
        }
        public DataTable GetDataSource()
        {
            DataTable result = _db.Fill("stor_GetDataMachine");
            return result;
        }
        private void FactorySettingPage_Load(object sender, EventArgs e)
        {
            GetDataGrid();
            SetDbCombobox();
        }
        private void SetDbCombobox()
        {
            BeanFactory beanFactory = new BeanFactory();
            cb_Factory.DisplayMember = "name";
            cb_Factory.ValueMember = "id";
            cb_Factory.DataSource = beanFactory.SelectAll();
            if (!string.IsNullOrEmpty(idFactory))
                cb_Factory.SelectedValue = Guid.Parse(idFactory);
            else
                cb_Factory.SelectedIndex = -1;
        }
        private void SaveData()
        {
            BeanMachine bean = new BeanMachine();
            if (strID != 0)
            {
                bean = bean.SelectByID(strID);
                bean.name = txt_Name.Text;
                bean.idFactory = Guid.Parse(cb_Factory.SelectedValue + string.Empty);
                bean.Update(bean);

            }
            else
            {
                bean.name = txt_Name.Text;
                bean.idFactory = Guid.Parse(cb_Factory.SelectedValue + string.Empty);
                bean.Insert(bean);
                strID = bean.id;
            }
            MessageBox.Show("Thành công!");
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            gridView1.UnselectRow(0);
        }
        private void selectData()
        {
            BeanMachine bean = new BeanMachine();
            if (strID != 0)
            {
                bean = bean.SelectByID(strID);
                txt_Name.Text = bean.name;
                cb_Factory.SelectedValue = bean.idFactory;
            }
        }
        private void refreshData()
        {
            txt_Name.Text = "";
            cb_Factory.SelectedIndex = -1;
            strID = 0;
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
            GetDataGrid();
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
                        BeanMachine bean = new BeanMachine();
                        bean = bean.SelectByID(strID);
                        bean.Delete(bean);
                        GetDataGrid();
                        refreshData();
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
            GetDataGrid();
            refreshData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            strID = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[0] + string.Empty);
            selectData();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            refreshData();
        }

        private void bbiSaveAndClose_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            SaveData();
            this.Close();
        }
    }
}
