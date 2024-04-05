using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
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

namespace VilasLab.Pages
{
    public partial class TargetSettingPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        string strID = "";
        public TargetSettingPage()
        {
            InitializeComponent();
           
        }
        private void GetDataGrid()
        {
            DataTable dataSource = GetDataSource();
            gridControl1.DataSource = dataSource;
            //gridView1.Columns[0].Visible = false;
        }
        public DataTable GetDataSource()
        {
            DataTable result = _db.Fill("stor_GetDataTarget");
            return result;
        }

        public void UpdateTargetID(string oldTar,string newTar)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("oldTarget", oldTar));
            parameters.Add(new SqlParameter("newTarget", newTar));
            var rs = _db.Execute("Update_TargetID",parameters);
        }
        private void FactorySettingPage_Load(object sender, EventArgs e)
        {
            GetDataGrid();
        }
        private void SaveData()
        {
            try
            {
                if (checkValidate())
                {
                    BeanTargetTest bean = new BeanTargetTest();
                    if (!string.IsNullOrEmpty(strID))
                    {
                        bean = bean.SelectByID(strID);
                        bean.name = txtName.Text;
                        bean.timeLine = Convert.ToInt32(nm_Timeline.Value);
                        bean.standard = txtStandard.Text;
                        bean.Update(bean);
                        if (strID != txt_ID.Text)
                        {
                            UpdateTargetID(strID, txt_ID.Text);
                            strID = bean.id;
                        }  
                    }
                    else
                    {
                        bean.id = txt_ID.Text;
                        bean.name = txtName.Text;
                        bean.timeLine = Convert.ToInt32(nm_Timeline.Value);
                        bean.standard = txtStandard.Text;
                        bean.Insert(bean);
                        strID = bean.id;
                    }
                    MessageBox.Show("Thành công!");
                }
                else
                    MessageBox.Show("Vui lòng nhập đủ thông tin cần thiết!");
            }
            catch (Exception ex)
            {
                function.TrackingError("TargetSettingPage - SaveData", ex.ToString());
            }
        }
        private bool checkValidate()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtName.Text))
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
            BeanTargetTest bean = new BeanTargetTest();
            if (!string.IsNullOrEmpty(strID))
            {
                bean = bean.SelectByID(strID);
                txt_ID.Text = bean.id;
                txtName.Text = bean.name;
                nm_Timeline.Value = bean.timeLine != null ? Convert.ToInt32(bean.timeLine) : 0;
                txtStandard.Text = bean.standard;
            }
        }
        private void refreshData()
        {
            txt_ID.Text = "";
            txtName.Text = "";
            nm_Timeline.Value =  0;
            txtStandard.Text = "";
            strID = "";
            txt_ID.Enabled = true;
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
                        BeanTargetTest bean = new BeanTargetTest();
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
            strID = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[0] + string.Empty;
            selectData();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            refreshData();
        }

        private void btn_ShowRequirement_ItemClick(object sender, ItemClickEventArgs e)
        {
            RequirementSettingPage page = new RequirementSettingPage();
            page.currUser = currUser;
            if(!string.IsNullOrEmpty(strID))
                page.idTarget = strID;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }
    }
}
