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
    public partial class RequirementSettingPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public BeanCustomer currUser { get; set; }
        public string idTarget { get; set; } = "";
        string strID = "";
        public RequirementSettingPage()
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
            DataTable result = _db.Fill("stor_GetDataRequirement");
            return result;
        }
        private void FactorySettingPage_Load(object sender, EventArgs e)
        {
            GetDataGrid();
            SetDbCombobox();
        }
        private void SetDbCombobox()
        {
            BeanTargetTest beanTarget = new BeanTargetTest();
            cb_Target.DisplayMember = "name";
            cb_Target.ValueMember = "id";
            cb_Target.DataSource = beanTarget.SelectAll();
            if(!string.IsNullOrEmpty(idTarget))
                cb_Target.SelectedValue = idTarget;
            else
                cb_Target.SelectedIndex = -1;
        }
        private bool SaveData()
        {
            if (checkValidate())
            {
                BeanRequirement bean = new BeanRequirement();
                if (!string.IsNullOrEmpty(strID))
                {
                    bean = bean.SelectByID(Guid.Parse(strID));
                    bean.name = txt_Name.Text;
                    bean.idTarget = cb_Target.SelectedValue + string.Empty;
                    bean.Update(bean);

                }
                else
                {
                    bean.id = Guid.NewGuid();
                    bean.name = txt_Name.Text;
                    bean.idTarget = cb_Target.SelectedValue + string.Empty;
                    bean.Insert(bean);
                    strID = bean.id + string.Empty;
                }
                MessageBox.Show("Thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin cần thiết!");
                return false;
            }
            return true;
        }
        private bool checkValidate()
        {
            bool result = true;
            if (string.IsNullOrEmpty(cb_Target.SelectedValue + "") || string.IsNullOrEmpty(txt_Name.Text))
            {
                result = false;
            }
            return result;
        }
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            gridView1.UnselectRow(0);
        }
        private void selectData()
        {
            BeanRequirement bean = new BeanRequirement();
            if (!string.IsNullOrEmpty(strID))
            {
                bean = bean.SelectByID(Guid.Parse(strID));
                txt_Name.Text = bean.name;
                cb_Target.SelectedValue = bean.idTarget;
            }
        }
        private void refreshData()
        {
            txt_Name.Text = "";
            cb_Target.SelectedIndex = -1;
            strID = "";
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
                if (!string.IsNullOrEmpty(strID))
                {
                    var mes = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mes == DialogResult.Yes)
                    {
                        BeanRequirement bean = new BeanRequirement();
                        bean = bean.SelectByID(Guid.Parse(strID));
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
            if (SaveData())
            {
                this.Close();
            }
        }

        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SaveData())
            {
                GetDataGrid();
                refreshData();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            strID = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[0] + string.Empty;
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
