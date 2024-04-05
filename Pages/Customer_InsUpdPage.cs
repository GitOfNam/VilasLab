using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VilasLab.Base;
using VilasLab.Models;

namespace VilasLab.Pages
{
    public partial class Customer_InsUpdPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        public string idUser { get; set; } = "";

        byte[] imageKySo = null;
        int level = 1;
        public Customer_InsUpdPage()
        {
            InitializeComponent();
        }
        public static Image convertImage(byte[] imageBinary)
        {
            using (MemoryStream ms = new MemoryStream(imageBinary))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
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
            if (level <= 2)
            {
                label8.Visible = false;
                cb_Permission.Visible = false;
            }

        }
        private void SetDbCombobox()
        {
            BeanPermission beanPermission = new BeanPermission();
            cb_Permission.DisplayMember = "name";
            cb_Permission.ValueMember = "id";
            cb_Permission.DataSource = beanPermission.SelectAll().OrderBy(s=>s.level).ToList();
        }
        private void Customer_InsUpdPage_Load(object sender, EventArgs e)
        {
            checkPermission();
            SetDbCombobox();
            SetData();
        }

        private void SetData()
        {
            try
            {
                BeanCustomer customer = new BeanCustomer();
                if (!string.IsNullOrEmpty(idUser))
                {
                    customer = customer.SelectByID(Guid.Parse(idUser));
                    txt_fullName.Text = customer.fullName;
                    txtAccountName.Text = customer.accountName;
                    txtAddress.Text = !string.IsNullOrEmpty(customer.address) ? customer.address: "";
                    txtEmail.Text = customer.email;
                    dt_BirthDay.Value = customer.birthDay != null ? Convert.ToDateTime(customer.birthDay): DateTime.Now;
                    txtPosition.Text = customer.position;
                    cb_Permission.SelectedValue = customer.idPermission;
                    cbGender.Checked = customer.gender;
                    if(customer.imageSignaturePath != null)
                    {
                        using (MemoryStream ms = new MemoryStream(customer.imageSignaturePath))
                        {
                            Image image = Image.FromStream(ms, true);
                            pic_anhkynhay.Image = image;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                function.TrackingError("Customer_InsUpdPage - SetData", ex.ToString());
            }
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    byte[] LogoByte = File.ReadAllBytes(openFileDialog.FileName);
                    using (MemoryStream ms = new MemoryStream(LogoByte))
                    {
                        
                        Image image = Image.FromStream(ms, true);
                        imageKySo = ms.ToArray();
                        pic_anhkynhay.Image = image;
                    }
                }
            }
        }
        private void SaveData()
        {
            PublicFunction function = new PublicFunction();
            try
            {
                if (!string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txt_fullName.Text))
                {
                    BeanCustomer customer = new BeanCustomer();
                    BeanCustomer customerUpdate = new BeanCustomer();
                    if (!string.IsNullOrEmpty(idUser))
                    {
                        customer.id = Guid.Parse(idUser);
                        customerUpdate = customer.SelectByID(Guid.Parse(idUser));
                        customer.fullName = txt_fullName.Text;
                        customer.password = customerUpdate.password;
                        customer.accountName = txtAccountName.Text;
                        customer.address = txtAddress.Text;
                        customer.email = txtEmail.Text;
                        if (dt_BirthDay.Value != null)
                        {
                            customer.birthDay = dt_BirthDay.Value;
                        }
                        customer.position = txtPosition.Text;
                        customer.idPermission = Guid.Parse(cb_Permission.SelectedValue + ""); ;
                        customer.gender = cbGender.Checked;
                        customer.status = true;
                        customer.isDeleted = false;
                        if(imageKySo != null)
                        {
                            customer.imageSignaturePath = imageKySo;
                        }
                        else
                            customer.imageSignaturePath = customerUpdate.imageSignaturePath;
                        customer.Update(customer);
                    }
                    else
                    {
                        customer.id = Guid.NewGuid();
                        customer.password = function.EncryptString("123");
                        customer.fullName = txt_fullName.Text;
                        customer.accountName = txtAccountName.Text;
                        customer.address = txtAddress.Text;
                        customer.email = txtEmail.Text;
                        if (dt_BirthDay.Value != null)
                        {
                            customer.birthDay = dt_BirthDay.Value;
                        }
                        customer.position = txtPosition.Text;
                        customer.idPermission = Guid.Parse(cb_Permission.SelectedValue + ""); ;
                        customer.gender = cbGender.Checked;
                        customer.status = true;
                        customer.isDeleted = false;
                        if (imageKySo != null)
                        {
                            customer.imageSignaturePath = imageKySo;
                        }
                        customer.Insert(customer);
                    }
                    MessageBox.Show("Thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập các thông tin bắt buộc!");
                }
            }
            catch (Exception ex)
            {
                function.TrackingError("Customer_InsUpdPage - SaveData", ex.ToString());
            }
        }
        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            this.Hide();
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            idUser = "";
            imageKySo = null;
            txt_fullName.Text = "";
            txtAccountName.Text = "";
            txtAddress.Text =  "";
            txtEmail.Text = "";
            txtPosition.Text = "";
            cb_Permission.SelectedValue = cb_Permission.Items[0];
            dt_BirthDay.Value = DateTime.Now;
            cbGender.Checked = false;
            pic_anhkynhay.Image = null;
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
        }
    }
}
