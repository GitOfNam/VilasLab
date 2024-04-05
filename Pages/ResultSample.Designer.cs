
namespace VilasLab.Pages
{
    partial class ResultSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultSample));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ExportFile = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_requirement = new System.Windows.Forms.ComboBox();
            this.cb_Target = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dt_TestDate = new System.Windows.Forms.DateTimePicker();
            this.dt_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_conclusion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActualResult = new System.Windows.Forms.TextBox();
            this.dtCompleteDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDocTest = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.btn_ExportFile,
            this.bbiDelete,
            this.bbiClose,
            this.btnDocTest});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 12;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(798, 158);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Save And Close";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            this.bbiSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndClose_ItemClick);
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Save And New";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            this.bbiSaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndNew_ItemClick);
            // 
            // btn_ExportFile
            // 
            this.btn_ExportFile.Caption = "Xuất biên bản thử nghiệm";
            this.btn_ExportFile.Id = 5;
            this.btn_ExportFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ExportFile.ImageOptions.Image")));
            this.btn_ExportFile.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_ExportFile.ImageOptions.LargeImage")));
            this.btn_ExportFile.Name = "btn_ExportFile";
            this.btn_ExportFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ExportFile_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup,
            this.ribbonPageGroup1});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "Home";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndClose);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndNew);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiDelete);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiClose);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Tasks";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_ExportFile);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDocTest);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Phê duyệt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtCompleteDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cb_requirement);
            this.groupBox1.Controls.Add(this.cb_Target);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dt_TestDate);
            this.groupBox1.Controls.Add(this.dt_StartDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_conclusion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUnit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtActualResult);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 230);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả thử nghiệm";
            // 
            // cb_requirement
            // 
            this.cb_requirement.FormattingEnabled = true;
            this.cb_requirement.Location = new System.Drawing.Point(515, 34);
            this.cb_requirement.Name = "cb_requirement";
            this.cb_requirement.Size = new System.Drawing.Size(230, 24);
            this.cb_requirement.TabIndex = 35;
            // 
            // cb_Target
            // 
            this.cb_Target.FormattingEnabled = true;
            this.cb_Target.Location = new System.Drawing.Point(131, 37);
            this.cb_Target.Name = "cb_Target";
            this.cb_Target.Size = new System.Drawing.Size(230, 24);
            this.cb_Target.TabIndex = 34;
            this.cb_Target.SelectedIndexChanged += new System.EventHandler(this.cb_Target_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tên chỉ tiêu";
            // 
            // dt_TestDate
            // 
            this.dt_TestDate.CustomFormat = "dd-MM-yyyy";
            this.dt_TestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_TestDate.Location = new System.Drawing.Point(132, 138);
            this.dt_TestDate.Name = "dt_TestDate";
            this.dt_TestDate.Size = new System.Drawing.Size(229, 23);
            this.dt_TestDate.TabIndex = 19;
            this.dt_TestDate.ValueChanged += new System.EventHandler(this.dt_TestDate_ValueChanged);
            // 
            // dt_StartDate
            // 
            this.dt_StartDate.CustomFormat = "dd-MM-yyyy";
            this.dt_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartDate.Location = new System.Drawing.Point(132, 179);
            this.dt_StartDate.Name = "dt_StartDate";
            this.dt_StartDate.Size = new System.Drawing.Size(229, 23);
            this.dt_StartDate.TabIndex = 18;
            this.dt_StartDate.ValueChanged += new System.EventHandler(this.dt_StartDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Từ ngày";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ngày nhận mẫu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kết luận";
            // 
            // txt_conclusion
            // 
            this.txt_conclusion.Location = new System.Drawing.Point(515, 138);
            this.txt_conclusion.Name = "txt_conclusion";
            this.txt_conclusion.Size = new System.Drawing.Size(230, 23);
            this.txt_conclusion.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Đơn vị tính";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(131, 88);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(230, 23);
            this.txtUnit.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Yêu cầu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Giá trị đo được";
            // 
            // txtActualResult
            // 
            this.txtActualResult.Location = new System.Drawing.Point(515, 91);
            this.txtActualResult.Name = "txtActualResult";
            this.txtActualResult.Size = new System.Drawing.Size(230, 23);
            this.txtActualResult.TabIndex = 6;
            // 
            // dtCompleteDate
            // 
            this.dtCompleteDate.CustomFormat = "dd-MM-yyyy";
            this.dtCompleteDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCompleteDate.Location = new System.Drawing.Point(515, 181);
            this.dtCompleteDate.Name = "dtCompleteDate";
            this.dtCompleteDate.Size = new System.Drawing.Size(229, 23);
            this.dtCompleteDate.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "Đến ngày";
            // 
            // btnDocTest
            // 
            this.btnDocTest.Caption = "Xuất phiếu kiểm tra";
            this.btnDocTest.Id = 10;
            this.btnDocTest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btnDocTest.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.btnDocTest.Name = "btnDocTest";
            this.btnDocTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocTest_ItemClick);
            // 
            // ResultSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(798, 406);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "ResultSample";
            this.Ribbon = this.mainRibbonControl;
            this.Text = "Chi tiết kết quả";
            this.Load += new System.EventHandler(this.ResultSample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem btn_ExportFile;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActualResult;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_conclusion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.DateTimePicker dt_TestDate;
        private System.Windows.Forms.DateTimePicker dt_StartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_Target;
        private System.Windows.Forms.ComboBox cb_requirement;
        private System.Windows.Forms.DateTimePicker dtCompleteDate;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraBars.BarButtonItem btnDocTest;
    }
}