
namespace VilasLab.Pages
{
    partial class Sample_Ins_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sample_Ins_Update));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.btn_EnterResult = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_descript = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbMachine = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dt_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dt_overDue = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.nmb_Pressure = new System.Windows.Forms.NumericUpDown();
            this.nmb_Diameter = new System.Windows.Forms.NumericUpDown();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.cb_NguoiKiemThu = new System.Windows.Forms.ComboBox();
            this.cb_Species = new System.Windows.Forms.ComboBox();
            this.cb_Ingredient = new System.Windows.Forms.ComboBox();
            this.cb_Target = new System.Windows.Forms.ComboBox();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.cb_Factory = new System.Windows.Forms.ComboBox();
            this.nmrSampleNumber = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmb_Pressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmb_Diameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSampleNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.mainRibbonControl.SearchEditItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.btn_EnterResult,
            this.bbiDelete,
            this.bbiClose});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 10;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(1322, 158);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.mainRibbonControl.Click += new System.EventHandler(this.mainRibbonControl_Click);
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
            // btn_EnterResult
            // 
            this.btn_EnterResult.Caption = "Nhập kết quả thử nghiệm";
            this.btn_EnterResult.Id = 5;
            this.btn_EnterResult.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_EnterResult.ImageOptions.Image")));
            this.btn_EnterResult.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_EnterResult.ImageOptions.LargeImage")));
            this.btn_EnterResult.Name = "btn_EnterResult";
            this.btn_EnterResult.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_EnterResult_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_EnterResult);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Hành động";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(117, 41);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(287, 23);
            this.txtID.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_descript);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cbMachine);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dt_StartDate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dt_overDue);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.nmb_Pressure);
            this.groupBox1.Controls.Add(this.nmb_Diameter);
            this.groupBox1.Controls.Add(this.cbClient);
            this.groupBox1.Controls.Add(this.cb_NguoiKiemThu);
            this.groupBox1.Controls.Add(this.cb_Species);
            this.groupBox1.Controls.Add(this.cb_Ingredient);
            this.groupBox1.Controls.Add(this.cb_Target);
            this.groupBox1.Controls.Add(this.cb_type);
            this.groupBox1.Controls.Add(this.cb_Factory);
            this.groupBox1.Controls.Add(this.nmrSampleNumber);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1306, 347);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu thử";
            // 
            // rtb_descript
            // 
            this.rtb_descript.Location = new System.Drawing.Point(945, 120);
            this.rtb_descript.Name = "rtb_descript";
            this.rtb_descript.Size = new System.Drawing.Size(327, 165);
            this.rtb_descript.TabIndex = 47;
            this.rtb_descript.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(942, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 16);
            this.label16.TabIndex = 46;
            this.label16.Text = "Ghi chú";
            // 
            // cbMachine
            // 
            this.cbMachine.FormattingEnabled = true;
            this.cbMachine.Location = new System.Drawing.Point(1042, 38);
            this.cbMachine.Name = "cbMachine";
            this.cbMachine.Size = new System.Drawing.Size(230, 24);
            this.cbMachine.TabIndex = 45;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(942, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 16);
            this.label15.TabIndex = 44;
            this.label15.Text = "Máy sản xuất";
            // 
            // dt_StartDate
            // 
            this.dt_StartDate.CustomFormat = "dd-MM-yyyy";
            this.dt_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartDate.Location = new System.Drawing.Point(118, 308);
            this.dt_StartDate.Name = "dt_StartDate";
            this.dt_StartDate.Size = new System.Drawing.Size(286, 23);
            this.dt_StartDate.TabIndex = 43;
            this.dt_StartDate.ValueChanged += new System.EventHandler(this.dt_StartDate_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 315);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 16);
            this.label14.TabIndex = 42;
            this.label14.Text = "Ngày bắt đầu";
            // 
            // dt_overDue
            // 
            this.dt_overDue.CustomFormat = "dd-MM-yyyy";
            this.dt_overDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_overDue.Location = new System.Drawing.Point(606, 306);
            this.dt_overDue.Name = "dt_overDue";
            this.dt_overDue.Size = new System.Drawing.Size(274, 23);
            this.dt_overDue.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(458, 310);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 16);
            this.label13.TabIndex = 40;
            this.label13.Text = "Hạn hoàn tất";
            // 
            // nmb_Pressure
            // 
            this.nmb_Pressure.Location = new System.Drawing.Point(117, 266);
            this.nmb_Pressure.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.nmb_Pressure.Name = "nmb_Pressure";
            this.nmb_Pressure.Size = new System.Drawing.Size(287, 23);
            this.nmb_Pressure.TabIndex = 39;
            // 
            // nmb_Diameter
            // 
            this.nmb_Diameter.Location = new System.Drawing.Point(117, 225);
            this.nmb_Diameter.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.nmb_Diameter.Name = "nmb_Diameter";
            this.nmb_Diameter.Size = new System.Drawing.Size(287, 23);
            this.nmb_Diameter.TabIndex = 38;
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(606, 219);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(275, 24);
            this.cbClient.TabIndex = 37;
            // 
            // cb_NguoiKiemThu
            // 
            this.cb_NguoiKiemThu.FormattingEnabled = true;
            this.cb_NguoiKiemThu.Location = new System.Drawing.Point(606, 178);
            this.cb_NguoiKiemThu.Name = "cb_NguoiKiemThu";
            this.cb_NguoiKiemThu.Size = new System.Drawing.Size(275, 24);
            this.cb_NguoiKiemThu.TabIndex = 36;
            // 
            // cb_Species
            // 
            this.cb_Species.FormattingEnabled = true;
            this.cb_Species.Location = new System.Drawing.Point(606, 134);
            this.cb_Species.Name = "cb_Species";
            this.cb_Species.Size = new System.Drawing.Size(275, 24);
            this.cb_Species.TabIndex = 35;
            // 
            // cb_Ingredient
            // 
            this.cb_Ingredient.FormattingEnabled = true;
            this.cb_Ingredient.Location = new System.Drawing.Point(606, 89);
            this.cb_Ingredient.Name = "cb_Ingredient";
            this.cb_Ingredient.Size = new System.Drawing.Size(275, 24);
            this.cb_Ingredient.TabIndex = 34;
            // 
            // cb_Target
            // 
            this.cb_Target.FormattingEnabled = true;
            this.cb_Target.Location = new System.Drawing.Point(117, 178);
            this.cb_Target.Name = "cb_Target";
            this.cb_Target.Size = new System.Drawing.Size(287, 24);
            this.cb_Target.TabIndex = 33;
            this.cb_Target.SelectedIndexChanged += new System.EventHandler(this.cb_Target_SelectedIndexChanged);
            // 
            // cb_type
            // 
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(117, 134);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(287, 24);
            this.cb_type.TabIndex = 32;
            // 
            // cb_Factory
            // 
            this.cb_Factory.FormattingEnabled = true;
            this.cb_Factory.Location = new System.Drawing.Point(117, 89);
            this.cb_Factory.Name = "cb_Factory";
            this.cb_Factory.Size = new System.Drawing.Size(287, 24);
            this.cb_Factory.TabIndex = 31;
            this.cb_Factory.SelectedIndexChanged += new System.EventHandler(this.cb_Factory_SelectedIndexChanged);
            this.cb_Factory.DisplayMemberChanged += new System.EventHandler(this.cb_Factory_DisplayMemberChanged);
            this.cb_Factory.ValueMemberChanged += new System.EventHandler(this.cb_Factory_ValueMemberChanged);
            // 
            // nmrSampleNumber
            // 
            this.nmrSampleNumber.Location = new System.Drawing.Point(606, 262);
            this.nmrSampleNumber.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.nmrSampleNumber.Name = "nmrSampleNumber";
            this.nmrSampleNumber.Size = new System.Drawing.Size(275, 23);
            this.nmrSampleNumber.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(458, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Khách hàng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "PN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(456, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Số lượng mẫu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Đường kính";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(456, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Người thử nghiệm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tiêu chí";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Chủng loại SP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Loại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nguyên liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nhà máy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(456, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ca sản xuất";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(606, 41);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(275, 23);
            this.txtTitle.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã phiếu";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 518);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.mainRibbonControl;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1306, 200);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            // 
            // Sample_Ins_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1322, 723);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "Sample_Ins_Update";
            this.Ribbon = this.mainRibbonControl;
            this.Text = "Chi tiết mẫu thử";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sample_Ins_Update_Load);
            this.Shown += new System.EventHandler(this.Sample_Ins_Update_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmb_Pressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmb_Diameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSampleNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btn_EnterResult;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nmrSampleNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.ComboBox cb_NguoiKiemThu;
        private System.Windows.Forms.ComboBox cb_Species;
        private System.Windows.Forms.ComboBox cb_Ingredient;
        private System.Windows.Forms.ComboBox cb_Target;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.ComboBox cb_Factory;
        private System.Windows.Forms.NumericUpDown nmb_Pressure;
        private System.Windows.Forms.NumericUpDown nmb_Diameter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.DateTimePicker dt_overDue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dt_StartDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox rtb_descript;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbMachine;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}