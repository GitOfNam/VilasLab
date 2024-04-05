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
    public partial class ChangePassPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        public BeanCustomer currUser { get; set; }
        public ChangePassPage()
        {
            InitializeComponent();
            
        }
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PublicFunction pbFunction = new PublicFunction();
            if (txt_mkCu.Text != "")
            {
                string strOldPass = pbFunction.EncryptString(txt_mkCu.Text);
               
                if (strOldPass == currUser.password)
                {
                    if (txt_mkmoi.Text != "" || txt_xacnhan.Text != "")
                    {
                        string strNewPass = pbFunction.EncryptString(txt_mkmoi.Text);
                        string strNewPassAgain = pbFunction.EncryptString(txt_xacnhan.Text);
                        if (strNewPass == strNewPassAgain)
                        {
                            var result = UpdateChangePass(currUser.id, strNewPass);
                            if(result == 1)
                            {
                                MessageBox.Show("Đổi mật khẩu thành công!");
                                this.Close();
                                
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("Xác nhận mật khẩu mới không trùng khớp!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập những trường bắt buộc!");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không trùng khớp!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!");
            }
        }
        public int UpdateChangePass(Guid UserID, string newPass)
        {
            int result = 0;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("UserID", UserID));
                parameters.Add(new SqlParameter("NewPass", newPass));
                result = _db.Execute("UpdatePassWord", parameters);

            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
