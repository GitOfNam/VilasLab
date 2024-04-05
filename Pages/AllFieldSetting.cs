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
    public partial class AllFieldSetting : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public BeanCustomer currUser { get; set; }
        public int TempID = 0;
        int strID = 0;
        public AllFieldSetting()
        {
            InitializeComponent();
          
        }
        private void GetDataGrid()
        {
            dataGridView1.DataSource = GetDataSource();
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
        }
        public List<BeanField> GetDataSource()
        {
            BeanField beanField = new BeanField();
            List<BeanField> result = beanField.SelectAll().Where(s => s.idTemplate == TempID).ToList(); 
            return result;
        }
        private void SetDbCombobox()
        {
            BeanTemplate beanTemplate = new BeanTemplate();
            List<BeanTemplate> lstBeanTemplate = new List<BeanTemplate>();
            lstBeanTemplate.Add(new BeanTemplate() { id = 0, name = "" });
            lstBeanTemplate.AddRange(beanTemplate.SelectAll());
            cb_IdTemp.DisplayMember = "name";
            cb_IdTemp.ValueMember = "id";
            cb_IdTemp.DataSource = lstBeanTemplate;
            cb_IdTemp.SelectedIndex = -1;
            if (TempID != 0)
                cb_IdTemp.SelectedValue = TempID;
        }
        private void FactorySettingPage_Load(object sender, EventArgs e)
        {
            GetDataGrid();
            SetDbCombobox();
        }
        private void SaveData()
        {
            BeanField bean = new BeanField();
            if (strID != 0)
            {
                bean = bean.SelectByID(strID);
                bean.name = txt_Name.Text;
                bean.idTemplate = Convert.ToInt32(cb_IdTemp.SelectedValue);
                bean.value = txt_Value.Text;
                bean.defaultText = txt_defaultText.Text;
                bean.isHTML = cb_isHTML.Checked;
                bean.ModifiedBy = currUser.id;
                bean.Modified = DateTime.Now;
                bean.Update(bean);

            }
            else
            {
                bean.name = txt_Name.Text;
                bean.idTemplate = Convert.ToInt32(cb_IdTemp.SelectedValue);
                bean.value = txt_Value.Text;
                bean.defaultText = txt_defaultText.Text;
                bean.isHTML = cb_isHTML.Checked;
                bean.ModifiedBy = bean.CreatedBy = currUser.id;
                bean.Modified = bean.Created = DateTime.Now;
                bean.Insert(bean);
                strID = bean.id;
            }
            MessageBox.Show("Thành công!");
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }
        private void selectData()
        {
            try
            {
                
                BeanField bean = new BeanField();
                if (strID != 0)
                {

                    bean = bean.SelectByID(strID);
                    txt_Name.Text = bean.name;
                    txt_Value.Text = bean.value;
                    txt_defaultText.Text = bean.defaultText;
                    cb_isHTML.Checked = bean.isHTML;
                    cb_IdTemp.SelectedValue = bean.idTemplate;
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void refreshData()
        {
            txt_Name.Text = "";
            txt_Value.Text = "";
            txt_defaultText.Text = "";
            cb_isHTML.Checked = false;
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
                        BeanField bean = new BeanField();
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
           
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            refreshData();
        }

        private void btnShowFieldSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            strID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty);
            selectData();
        }
    }
}
