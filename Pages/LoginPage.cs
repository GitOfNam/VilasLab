using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class LoginPage : Form
    {
        PublicFunction publicFunction = new PublicFunction();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            this.txt_pass.AutoSize = false;
            this.txt_pass.Size = new System.Drawing.Size(226, 30);
            StreamReader sr = new StreamReader("conf.ini");
            var conf2 = new INIHelper(sr);
            sr.Close();
            var isSave = conf2.GetValue("isSave");
            if (isSave == "yes")
            {
                txt_user.Text = conf2.GetValue("username");
                txt_pass.Text = publicFunction.DecryptString(conf2.GetValue("password"));
                ckb_luutk.Checked = true;
            }
            ckb_hienmk.Enabled = false;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                ActionLogin();
            }
            catch (Exception ex) {
                
            }
        }

        private void ActionLogin()
        {
            try
            {
                if (txt_user.Text == "" || txt_pass.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Tài khoản/Mật khẩu");
                }
                else
                {
                    BeanCustomer beanCustomer = new BeanCustomer();
                    string passEnscript = publicFunction.EncryptString(txt_pass.Text);
                    beanCustomer = beanCustomer.SelectAll().Where(s => s.accountName == txt_user.Text && s.password == passEnscript).FirstOrDefault();
                    bool ischeck = beanCustomer != null;
                    if (ischeck)
                    {
                        saveFileConfig(passEnscript);
                        DashboardPage page = new DashboardPage();
                        page.currUser = beanCustomer;
                        page.FormClosed += new FormClosedEventHandler(OpenLogin_FormClosing);
                        page.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không trùng khớp", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void saveFileConfig(string Pass)
        {
            var conf = new INIHelper();
            conf.SetValue("username", txt_user.Text);
            conf.SetValue("password", Pass);
            if (ckb_luutk.Checked)
            {
                conf.SetValue("isSave", "yes");
            }
            else
            {
                conf.SetValue("isSave", "no");
            }
            StreamWriter sw = new StreamWriter("conf.ini");
            conf.Save(sw);
            sw.Close();
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            var mes = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (mes == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ckb_hienmk_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_hienmk.Checked)
            {
                txt_pass.UseSystemPasswordChar = false;
            }
            else
            {
                txt_pass.UseSystemPasswordChar = true;
            }
        }

        private void txt_pass_TextChanged_1(object sender, EventArgs e)
        {
            ckb_hienmk.Enabled = true;
        }
        private void OpenLogin_FormClosing(Object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void LoginPage_Enter(object sender, EventArgs e)
        {
            
        }

        private void txt_user_Enter(object sender, EventArgs e)
        {
           
        }

        private void txt_pass_Enter(object sender, EventArgs e)
        {
           
        }

        private void txt_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ActionLogin();
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ActionLogin();
        }

        private void LoginPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ActionLogin();
        }
    }
}
