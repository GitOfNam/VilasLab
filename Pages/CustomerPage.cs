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
    public partial class CustomerPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public BeanCustomer currUser { get; set; }
        public CustomerPage()
        {
            InitializeComponent();
        }
        
        private void CustomerPage_Load(object sender, EventArgs e)
        {
            btnDel.Visibility = BarItemVisibility.Never;
            btnEdit.Visibility = BarItemVisibility.Never;
            GetData();
        }
        private void GetData()
        {
            dataGridView1.DataSource = GetDataSource();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[4].Width = 200;
        }
        public DataTable GetDataSource()
        {
            DataTable result = _db.Fill("GetAllUser");
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
                        BeanCustomer cus = new BeanCustomer();
                        cus.SelectByID(Guid.Parse(dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty));
                        if (cus.id != Guid.Empty)
                        {
                            cus.Delete(cus);
                            GetData();
                            MessageBox.Show("Xóa tài khoản thành công!");
                        }
                        else
                            MessageBox.Show("Không tìm thấy thông tin tài khoản!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản!");
                }
            }
            catch(Exception ex)
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
                    Customer_InsUpdPage page = new Customer_InsUpdPage();
                    page.idUser = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
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
                Customer_InsUpdPage page = new Customer_InsUpdPage();
                page.idUser = "";
                page.currUser = currUser;
                page.StartPosition = FormStartPosition.CenterScreen;
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
    }
}
