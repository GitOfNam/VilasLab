
namespace VilasLab.Pages
{
    partial class PageSignDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageSignDoc));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_Signed = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnResign = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.mainRibbonControl.SearchEditItem,
            this.btn_Signed,
            this.bbiClose,
            this.btnResign});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 128;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(1221, 158);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btn_Signed
            // 
            this.btn_Signed.Caption = "Ký số";
            this.btn_Signed.Id = 2;
            this.btn_Signed.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Signed.ImageOptions.Image")));
            this.btn_Signed.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Signed.ImageOptions.LargeImage")));
            this.btn_Signed.Name = "btn_Signed";
            this.btn_Signed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Signed_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Thoát";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // btnResign
            // 
            this.btnResign.Caption = "Không đồng ý";
            this.btnResign.Id = 11;
            this.btnResign.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnResign.ImageOptions.Image")));
            this.btnResign.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnResign.ImageOptions.LargeImage")));
            this.btnResign.Name = "btnResign";
            this.btnResign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResign_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "Home";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.btn_Signed);
            this.mainRibbonPageGroup.ItemLinks.Add(this.btnResign);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiClose);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Tasks";
            // 
            // richEditControl1
            // 
            this.richEditControl1.Location = new System.Drawing.Point(0, 164);
            this.richEditControl1.MenuManager = this.mainRibbonControl;
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(1220, 569);
            this.richEditControl1.TabIndex = 5;
            // 
            // PageSignDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1221, 737);
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "PageSignDoc";
            this.Ribbon = this.mainRibbonControl;
            this.Load += new System.EventHandler(this.PageSignDoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem btn_Signed;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarButtonItem btnResign;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
    }
}