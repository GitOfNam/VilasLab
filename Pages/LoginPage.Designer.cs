
namespace VilasLab.Pages
{
    partial class LoginPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_user = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.ckb_luutk = new System.Windows.Forms.CheckBox();
            this.ckb_hienmk = new System.Windows.Forms.CheckBox();
            this.btn_login = new DevExpress.XtraEditors.SimpleButton();
            this.btn_exit = new DevExpress.XtraEditors.SimpleButton();
            this.txt_pass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(319, 36);
            this.txt_user.Name = "txt_user";
            this.txt_user.Properties.AutoHeight = false;
            this.txt_user.Size = new System.Drawing.Size(226, 30);
            this.txt_user.TabIndex = 0;
            this.txt_user.Enter += new System.EventHandler(this.txt_user_Enter);
            this.txt_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_user_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(240, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tài khoản:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(240, 94);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mật khẩu: ";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureEdit1.EditValue = global::VilasLab.Properties.Resources._269_2697881_computer_icons_user_clip_art_transparent_png_icon;
            this.pictureEdit1.Location = new System.Drawing.Point(21, 33);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(192, 195);
            this.pictureEdit1.TabIndex = 4;
            // 
            // ckb_luutk
            // 
            this.ckb_luutk.AutoSize = true;
            this.ckb_luutk.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_luutk.ForeColor = System.Drawing.Color.Crimson;
            this.ckb_luutk.Location = new System.Drawing.Point(319, 151);
            this.ckb_luutk.Name = "ckb_luutk";
            this.ckb_luutk.Size = new System.Drawing.Size(142, 21);
            this.ckb_luutk.TabIndex = 5;
            this.ckb_luutk.Text = "Ghi nhớ tài khoản";
            this.ckb_luutk.UseVisualStyleBackColor = true;
            // 
            // ckb_hienmk
            // 
            this.ckb_hienmk.AutoSize = true;
            this.ckb_hienmk.Enabled = false;
            this.ckb_hienmk.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_hienmk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ckb_hienmk.Location = new System.Drawing.Point(319, 128);
            this.ckb_hienmk.Name = "ckb_hienmk";
            this.ckb_hienmk.Size = new System.Drawing.Size(139, 21);
            this.ckb_hienmk.TabIndex = 4;
            this.ckb_hienmk.Text = "Hiện thị mật khẩu";
            this.ckb_hienmk.UseVisualStyleBackColor = true;
            this.ckb_hienmk.CheckedChanged += new System.EventHandler(this.ckb_hienmk_CheckedChanged);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(319, 189);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(91, 38);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "Đăng nhập";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(445, 189);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(100, 38);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(319, 86);
            this.txt_pass.MaxLength = 50;
            this.txt_pass.MinimumSize = new System.Drawing.Size(4, 30);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(226, 20);
            this.txt_pass.TabIndex = 2;
            this.txt_pass.UseSystemPasswordChar = true;
            this.txt_pass.TextChanged += new System.EventHandler(this.txt_pass_TextChanged_1);
            this.txt_pass.Enter += new System.EventHandler(this.txt_pass_Enter);
            this.txt_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pass_KeyDown);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 270);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.ckb_luutk);
            this.Controls.Add(this.ckb_hienmk);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_user);
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.Enter += new System.EventHandler(this.LoginPage_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginPage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_user;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.CheckBox ckb_luutk;
        private System.Windows.Forms.CheckBox ckb_hienmk;
        private DevExpress.XtraEditors.SimpleButton btn_login;
        private DevExpress.XtraEditors.SimpleButton btn_exit;
        private System.Windows.Forms.TextBox txt_pass;
    }
}