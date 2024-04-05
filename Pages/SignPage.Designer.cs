
namespace VilasLab.Pages
{
    partial class SignPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignPage));
            SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo dictionaryFileInfo1 = new SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_Signed = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnResign = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.winFormHtmlEditor1 = new SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            this.winFormHtmlEditor1.Toolbar1.SuspendLayout();
            this.winFormHtmlEditor1.Toolbar2.SuspendLayout();
            this.winFormHtmlEditor1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.btn_Signed,
            this.bbiClose,
            this.btnResign,
            this.mainRibbonControl.SearchEditItem});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 11;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(1384, 158);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btn_Signed
            // 
            this.btn_Signed.Caption = "Ký số";
            this.btn_Signed.Id = 2;
            this.btn_Signed.ImageOptions.ImageUri.Uri = "richedit/pencolor";
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
            this.btnResign.Id = 10;
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
            // winFormHtmlEditor1
            // 
            this.winFormHtmlEditor1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.winFormHtmlEditor1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.winFormHtmlEditor1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            // 
            // winFormHtmlEditor1.BtnAlignCenter
            // 
            this.winFormHtmlEditor1.BtnAlignCenter.AccessibleName = "_factoryBtnAlignCenter";
            this.winFormHtmlEditor1.BtnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnAlignCenter.Image")));
            this.winFormHtmlEditor1.BtnAlignCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnAlignCenter.Name = "_factoryBtnAlignCenter";
            this.winFormHtmlEditor1.BtnAlignCenter.Size = new System.Drawing.Size(26, 26);
            this.winFormHtmlEditor1.BtnAlignCenter.Text = "Align Centre";
            // 
            // winFormHtmlEditor1.BtnAlignLeft
            // 
            this.winFormHtmlEditor1.BtnAlignLeft.AccessibleName = "_factoryBtnAlignLeft";
            this.winFormHtmlEditor1.BtnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnAlignLeft.Image")));
            this.winFormHtmlEditor1.BtnAlignLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnAlignLeft.Name = "_factoryBtnAlignLeft";
            this.winFormHtmlEditor1.BtnAlignLeft.Size = new System.Drawing.Size(26, 26);
            this.winFormHtmlEditor1.BtnAlignLeft.Text = "Align Left";
            // 
            // winFormHtmlEditor1.BtnAlignRight
            // 
            this.winFormHtmlEditor1.BtnAlignRight.AccessibleName = "_factoryBtnAlignRight";
            this.winFormHtmlEditor1.BtnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnAlignRight.Image")));
            this.winFormHtmlEditor1.BtnAlignRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnAlignRight.Name = "_factoryBtnAlignRight";
            this.winFormHtmlEditor1.BtnAlignRight.Size = new System.Drawing.Size(26, 26);
            this.winFormHtmlEditor1.BtnAlignRight.Text = "Align Right";
            // 
            // winFormHtmlEditor1.BtnBodyStyle
            // 
            this.winFormHtmlEditor1.BtnBodyStyle.AccessibleName = "_factoryBtnBodyStyle";
            this.winFormHtmlEditor1.BtnBodyStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnBodyStyle.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnBodyStyle.Image")));
            this.winFormHtmlEditor1.BtnBodyStyle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnBodyStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnBodyStyle.Name = "_factoryBtnBodyStyle";
            this.winFormHtmlEditor1.BtnBodyStyle.Size = new System.Drawing.Size(27, 26);
            this.winFormHtmlEditor1.BtnBodyStyle.Text = "Document Style ";
            // 
            // winFormHtmlEditor1.BtnBold
            // 
            this.winFormHtmlEditor1.BtnBold.AccessibleName = "_factoryBtnBold";
            this.winFormHtmlEditor1.BtnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnBold.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnBold.Image")));
            this.winFormHtmlEditor1.BtnBold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnBold.Name = "_factoryBtnBold";
            this.winFormHtmlEditor1.BtnBold.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnBold.Text = "Bold";
            // 
            // winFormHtmlEditor1.BtnCopy
            // 
            this.winFormHtmlEditor1.BtnCopy.AccessibleName = "_factoryBtnCopy";
            this.winFormHtmlEditor1.BtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnCopy.Image")));
            this.winFormHtmlEditor1.BtnCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnCopy.Name = "_factoryBtnCopy";
            this.winFormHtmlEditor1.BtnCopy.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnCopy.Text = "Copy";
            // 
            // winFormHtmlEditor1.BtnCut
            // 
            this.winFormHtmlEditor1.BtnCut.AccessibleName = "_factoryBtnCut";
            this.winFormHtmlEditor1.BtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnCut.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnCut.Image")));
            this.winFormHtmlEditor1.BtnCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnCut.Name = "_factoryBtnCut";
            this.winFormHtmlEditor1.BtnCut.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnCut.Text = "Cut";
            // 
            // winFormHtmlEditor1.BtnFontColor
            // 
            this.winFormHtmlEditor1.BtnFontColor.AccessibleName = "_factoryBtnFontColor";
            this.winFormHtmlEditor1.BtnFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnFontColor.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnFontColor.Image")));
            this.winFormHtmlEditor1.BtnFontColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnFontColor.Name = "_factoryBtnFontColor";
            this.winFormHtmlEditor1.BtnFontColor.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnFontColor.Text = "Apply Font Color";
            // 
            // winFormHtmlEditor1.BtnFormatRedo
            // 
            this.winFormHtmlEditor1.BtnFormatRedo.AccessibleName = "_factoryBtnRedo";
            this.winFormHtmlEditor1.BtnFormatRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnFormatRedo.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnFormatRedo.Image")));
            this.winFormHtmlEditor1.BtnFormatRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnFormatRedo.Name = "_factoryBtnRedo";
            this.winFormHtmlEditor1.BtnFormatRedo.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnFormatRedo.Text = "Redo";
            // 
            // winFormHtmlEditor1.BtnFormatReset
            // 
            this.winFormHtmlEditor1.BtnFormatReset.AccessibleName = "_factoryBtnFormatReset";
            this.winFormHtmlEditor1.BtnFormatReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnFormatReset.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnFormatReset.Image")));
            this.winFormHtmlEditor1.BtnFormatReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnFormatReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnFormatReset.Name = "_factoryBtnFormatReset";
            this.winFormHtmlEditor1.BtnFormatReset.Size = new System.Drawing.Size(34, 26);
            this.winFormHtmlEditor1.BtnFormatReset.Text = "Remove Format";
            // 
            // winFormHtmlEditor1.BtnFormatUndo
            // 
            this.winFormHtmlEditor1.BtnFormatUndo.AccessibleName = "_factoryBtnUndo";
            this.winFormHtmlEditor1.BtnFormatUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnFormatUndo.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnFormatUndo.Image")));
            this.winFormHtmlEditor1.BtnFormatUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnFormatUndo.Name = "_factoryBtnUndo";
            this.winFormHtmlEditor1.BtnFormatUndo.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnFormatUndo.Text = "Undo";
            // 
            // winFormHtmlEditor1.BtnHighlightColor
            // 
            this.winFormHtmlEditor1.BtnHighlightColor.AccessibleName = "_factoryBtnHighlightColor";
            this.winFormHtmlEditor1.BtnHighlightColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnHighlightColor.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnHighlightColor.Image")));
            this.winFormHtmlEditor1.BtnHighlightColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnHighlightColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnHighlightColor.Name = "_factoryBtnHighlightColor";
            this.winFormHtmlEditor1.BtnHighlightColor.Size = new System.Drawing.Size(27, 26);
            this.winFormHtmlEditor1.BtnHighlightColor.Text = "Apply Highlight Color";
            // 
            // winFormHtmlEditor1.BtnHorizontalRule
            // 
            this.winFormHtmlEditor1.BtnHorizontalRule.AccessibleName = "_factoryBtnHorizontalRule";
            this.winFormHtmlEditor1.BtnHorizontalRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnHorizontalRule.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnHorizontalRule.Image")));
            this.winFormHtmlEditor1.BtnHorizontalRule.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnHorizontalRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnHorizontalRule.Name = "_factoryBtnHorizontalRule";
            this.winFormHtmlEditor1.BtnHorizontalRule.Size = new System.Drawing.Size(24, 26);
            this.winFormHtmlEditor1.BtnHorizontalRule.Text = "Insert Horizontal Rule";
            // 
            // winFormHtmlEditor1.BtnHyperlink
            // 
            this.winFormHtmlEditor1.BtnHyperlink.AccessibleName = "_factoryBtnHyperlink";
            this.winFormHtmlEditor1.BtnHyperlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnHyperlink.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnHyperlink.Image")));
            this.winFormHtmlEditor1.BtnHyperlink.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnHyperlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnHyperlink.Name = "_factoryBtnHyperlink";
            this.winFormHtmlEditor1.BtnHyperlink.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnHyperlink.Text = "Hyperlink";
            // 
            // winFormHtmlEditor1.BtnImage
            // 
            this.winFormHtmlEditor1.BtnImage.AccessibleName = "_factoryBtnImage";
            this.winFormHtmlEditor1.BtnImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnImage.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnImage.Image")));
            this.winFormHtmlEditor1.BtnImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnImage.Name = "_factoryBtnImage";
            this.winFormHtmlEditor1.BtnImage.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnImage.Text = "Image";
            // 
            // winFormHtmlEditor1.BtnIndent
            // 
            this.winFormHtmlEditor1.BtnIndent.AccessibleName = "_factoryBtnIndent";
            this.winFormHtmlEditor1.BtnIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnIndent.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnIndent.Image")));
            this.winFormHtmlEditor1.BtnIndent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnIndent.Name = "_factoryBtnIndent";
            this.winFormHtmlEditor1.BtnIndent.Size = new System.Drawing.Size(27, 26);
            this.winFormHtmlEditor1.BtnIndent.Text = "Indent";
            // 
            // winFormHtmlEditor1.BtnInsertYouTubeVideo
            // 
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo.AccessibleName = "_factoryBtnInsertYouTubeVideo";
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnInsertYouTubeVideo.Image")));
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo.Name = "_factoryBtnInsertYouTubeVideo";
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo.Text = "Insert YouTube Video";
            // 
            // winFormHtmlEditor1.BtnItalic
            // 
            this.winFormHtmlEditor1.BtnItalic.AccessibleName = "_factoryBtnItalic";
            this.winFormHtmlEditor1.BtnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnItalic.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnItalic.Image")));
            this.winFormHtmlEditor1.BtnItalic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnItalic.Name = "_factoryBtnItalic";
            this.winFormHtmlEditor1.BtnItalic.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnItalic.Text = "Italic";
            // 
            // winFormHtmlEditor1.BtnNew
            // 
            this.winFormHtmlEditor1.BtnNew.AccessibleName = "_factoryBtnNew";
            this.winFormHtmlEditor1.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnNew.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnNew.Image")));
            this.winFormHtmlEditor1.BtnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnNew.Name = "_factoryBtnNew";
            this.winFormHtmlEditor1.BtnNew.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnNew.Text = "New";
            // 
            // winFormHtmlEditor1.BtnOpen
            // 
            this.winFormHtmlEditor1.BtnOpen.AccessibleName = "_factoryBtnOpen";
            this.winFormHtmlEditor1.BtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnOpen.Image")));
            this.winFormHtmlEditor1.BtnOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnOpen.Name = "_factoryBtnOpen";
            this.winFormHtmlEditor1.BtnOpen.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnOpen.Text = "Open";
            // 
            // winFormHtmlEditor1.BtnOrderedList
            // 
            this.winFormHtmlEditor1.BtnOrderedList.AccessibleName = "_factoryBtnOrderedList";
            this.winFormHtmlEditor1.BtnOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnOrderedList.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnOrderedList.Image")));
            this.winFormHtmlEditor1.BtnOrderedList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnOrderedList.Name = "_factoryBtnOrderedList";
            this.winFormHtmlEditor1.BtnOrderedList.Size = new System.Drawing.Size(24, 26);
            this.winFormHtmlEditor1.BtnOrderedList.Text = "Numbered List";
            // 
            // winFormHtmlEditor1.BtnOutdent
            // 
            this.winFormHtmlEditor1.BtnOutdent.AccessibleName = "_factoryBtnOutdent";
            this.winFormHtmlEditor1.BtnOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnOutdent.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnOutdent.Image")));
            this.winFormHtmlEditor1.BtnOutdent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnOutdent.Name = "_factoryBtnOutdent";
            this.winFormHtmlEditor1.BtnOutdent.Size = new System.Drawing.Size(27, 26);
            this.winFormHtmlEditor1.BtnOutdent.Text = "Outdent";
            // 
            // winFormHtmlEditor1.BtnPaste
            // 
            this.winFormHtmlEditor1.BtnPaste.AccessibleName = "_factoryBtnPaste";
            this.winFormHtmlEditor1.BtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnPaste.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnPaste.Image")));
            this.winFormHtmlEditor1.BtnPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnPaste.Name = "_factoryBtnPaste";
            this.winFormHtmlEditor1.BtnPaste.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnPaste.Text = "Paste";
            // 
            // winFormHtmlEditor1.BtnPasteFromMSWord
            // 
            this.winFormHtmlEditor1.BtnPasteFromMSWord.AccessibleName = "_factoryBtnPasteFromMSWord";
            this.winFormHtmlEditor1.BtnPasteFromMSWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnPasteFromMSWord.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnPasteFromMSWord.Image")));
            this.winFormHtmlEditor1.BtnPasteFromMSWord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnPasteFromMSWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnPasteFromMSWord.Name = "_factoryBtnPasteFromMSWord";
            this.winFormHtmlEditor1.BtnPasteFromMSWord.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnPasteFromMSWord.Text = "Paste the Content that you Copied from MS Word";
            // 
            // winFormHtmlEditor1.BtnPrint
            // 
            this.winFormHtmlEditor1.BtnPrint.AccessibleName = "_factoryBtnPrint";
            this.winFormHtmlEditor1.BtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnPrint.Image")));
            this.winFormHtmlEditor1.BtnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnPrint.Name = "_factoryBtnPrint";
            this.winFormHtmlEditor1.BtnPrint.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnPrint.Text = "Print";
            // 
            // winFormHtmlEditor1.BtnSave
            // 
            this.winFormHtmlEditor1.BtnSave.AccessibleName = "_factoryBtnSave";
            this.winFormHtmlEditor1.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnSave.Image")));
            this.winFormHtmlEditor1.BtnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnSave.Name = "_factoryBtnSave";
            this.winFormHtmlEditor1.BtnSave.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnSave.Text = "Save";
            // 
            // winFormHtmlEditor1.BtnSearch
            // 
            this.winFormHtmlEditor1.BtnSearch.AccessibleName = "_factoryBtnSearch";
            this.winFormHtmlEditor1.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnSearch.Image")));
            this.winFormHtmlEditor1.BtnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnSearch.Name = "_factoryBtnSearch";
            this.winFormHtmlEditor1.BtnSearch.Size = new System.Drawing.Size(24, 26);
            this.winFormHtmlEditor1.BtnSearch.Text = "Search";
            // 
            // winFormHtmlEditor1.BtnSpellCheck
            // 
            this.winFormHtmlEditor1.BtnSpellCheck.AccessibleName = "_factoryBtnSpellCheck";
            this.winFormHtmlEditor1.BtnSpellCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnSpellCheck.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnSpellCheck.Image")));
            this.winFormHtmlEditor1.BtnSpellCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnSpellCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnSpellCheck.Name = "_factoryBtnSpellCheck";
            this.winFormHtmlEditor1.BtnSpellCheck.Size = new System.Drawing.Size(26, 26);
            this.winFormHtmlEditor1.BtnSpellCheck.Text = "Check Spelling";
            // 
            // winFormHtmlEditor1.BtnStrikeThrough
            // 
            this.winFormHtmlEditor1.BtnStrikeThrough.AccessibleName = "_factoryBtnStrikeThrough";
            this.winFormHtmlEditor1.BtnStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnStrikeThrough.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnStrikeThrough.Image")));
            this.winFormHtmlEditor1.BtnStrikeThrough.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnStrikeThrough.Name = "_factoryBtnStrikeThrough";
            this.winFormHtmlEditor1.BtnStrikeThrough.Size = new System.Drawing.Size(24, 26);
            this.winFormHtmlEditor1.BtnStrikeThrough.Text = "Strike Thru";
            // 
            // winFormHtmlEditor1.BtnSubscript
            // 
            this.winFormHtmlEditor1.BtnSubscript.AccessibleName = "_factoryBtnSubscript";
            this.winFormHtmlEditor1.BtnSubscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnSubscript.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnSubscript.Image")));
            this.winFormHtmlEditor1.BtnSubscript.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnSubscript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnSubscript.Name = "_factoryBtnSubscript";
            this.winFormHtmlEditor1.BtnSubscript.Size = new System.Drawing.Size(27, 26);
            this.winFormHtmlEditor1.BtnSubscript.Text = "Subscript";
            // 
            // winFormHtmlEditor1.BtnSuperScript
            // 
            this.winFormHtmlEditor1.BtnSuperScript.AccessibleName = "_factoryBtnSuperScript";
            this.winFormHtmlEditor1.BtnSuperScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnSuperScript.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnSuperScript.Image")));
            this.winFormHtmlEditor1.BtnSuperScript.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnSuperScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnSuperScript.Name = "_factoryBtnSuperScript";
            this.winFormHtmlEditor1.BtnSuperScript.Size = new System.Drawing.Size(27, 26);
            this.winFormHtmlEditor1.BtnSuperScript.Text = "Superscript";
            // 
            // winFormHtmlEditor1.BtnSymbol
            // 
            this.winFormHtmlEditor1.BtnSymbol.AccessibleName = "_factoryBtnSymbol";
            this.winFormHtmlEditor1.BtnSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnSymbol.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnSymbol.Image")));
            this.winFormHtmlEditor1.BtnSymbol.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnSymbol.Name = "_factoryBtnSymbol";
            this.winFormHtmlEditor1.BtnSymbol.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnSymbol.Text = "Insert Symbols";
            // 
            // winFormHtmlEditor1.BtnTable
            // 
            this.winFormHtmlEditor1.BtnTable.AccessibleName = "_factoryBtnTable";
            this.winFormHtmlEditor1.BtnTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnTable.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnTable.Image")));
            this.winFormHtmlEditor1.BtnTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnTable.Name = "_factoryBtnTable";
            this.winFormHtmlEditor1.BtnTable.Size = new System.Drawing.Size(24, 26);
            this.winFormHtmlEditor1.BtnTable.Text = "Table";
            // 
            // winFormHtmlEditor1.BtnUnderline
            // 
            this.winFormHtmlEditor1.BtnUnderline.AccessibleName = "_factoryBtnUnderline";
            this.winFormHtmlEditor1.BtnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnUnderline.Image")));
            this.winFormHtmlEditor1.BtnUnderline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnUnderline.Name = "_factoryBtnUnderline";
            this.winFormHtmlEditor1.BtnUnderline.Size = new System.Drawing.Size(23, 26);
            this.winFormHtmlEditor1.BtnUnderline.Text = "Underline";
            // 
            // winFormHtmlEditor1.BtnUnOrderedList
            // 
            this.winFormHtmlEditor1.BtnUnOrderedList.AccessibleName = "_factoryBtnUnOrderedList";
            this.winFormHtmlEditor1.BtnUnOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.winFormHtmlEditor1.BtnUnOrderedList.Image = ((System.Drawing.Image)(resources.GetObject("winFormHtmlEditor1.BtnUnOrderedList.Image")));
            this.winFormHtmlEditor1.BtnUnOrderedList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.winFormHtmlEditor1.BtnUnOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.winFormHtmlEditor1.BtnUnOrderedList.Name = "_factoryBtnUnOrderedList";
            this.winFormHtmlEditor1.BtnUnOrderedList.Size = new System.Drawing.Size(24, 26);
            this.winFormHtmlEditor1.BtnUnOrderedList.Text = "Bullet List";
            this.winFormHtmlEditor1.Charset = "utf-8";
            // 
            // winFormHtmlEditor1.CmbFontName
            // 
            this.winFormHtmlEditor1.CmbFontName.AddSystemFonts = true;
            this.winFormHtmlEditor1.CmbFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.winFormHtmlEditor1.CmbFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.winFormHtmlEditor1.CmbFontName.MaxDropDownItems = 17;
            this.winFormHtmlEditor1.CmbFontName.Name = "_factoryCmbFontName";
            this.winFormHtmlEditor1.CmbFontName.Size = new System.Drawing.Size(125, 29);
            // 
            // winFormHtmlEditor1.CmbFontSize
            // 
            this.winFormHtmlEditor1.CmbFontSize.Name = "_factoryCmbFontSize";
            this.winFormHtmlEditor1.CmbFontSize.Size = new System.Drawing.Size(75, 29);
            this.winFormHtmlEditor1.CmbFontSize.Text = "12pt";
            // 
            // winFormHtmlEditor1.CmbTitleInsert
            // 
            this.winFormHtmlEditor1.CmbTitleInsert.Name = "_factoryCmbTitleInsert";
            this.winFormHtmlEditor1.CmbTitleInsert.Size = new System.Drawing.Size(100, 29);
            this.winFormHtmlEditor1.DocumentHtml = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">\r\n<html><head>\r\n<me" +
    "ta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\" />\r\n</head>\r\n<bo" +
    "dy></body></html>";
            this.winFormHtmlEditor1.EditorContextMenuStrip = null;
            this.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview;
            this.winFormHtmlEditor1.HeaderStyleContentElementID = "page_style";
            this.winFormHtmlEditor1.HorizontalScroll = null;
            this.winFormHtmlEditor1.Location = new System.Drawing.Point(0, 467);
            this.winFormHtmlEditor1.Name = "winFormHtmlEditor1";
            this.winFormHtmlEditor1.Options.ContinueSameStyleAfterEnterKey = true;
            this.winFormHtmlEditor1.Options.ConvertFileUrlsToLocalPaths = true;
            this.winFormHtmlEditor1.Options.CustomDOCTYPE = null;
            this.winFormHtmlEditor1.Options.FooterTagNavigatorFont = null;
            this.winFormHtmlEditor1.Options.FooterTagNavigatorTextColor = System.Drawing.Color.Teal;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.ConnectionMode = SpiceLogic.HtmlEditorControl.Domain.BOs.UserOptions.FTPSettings.ConnectionModes.Active;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Host = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Password = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Port = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.RemoteFolderPath = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Timeout = 4000;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.UrlOfTheRemoteFolderPath = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.UserName = null;
            this.winFormHtmlEditor1.Options.PasteImageFromClipboardBehavior = SpiceLogic.HtmlEditorControl.Domain.BOs.UserOptions.UserOption.ImageStorage.Base64;
            this.winFormHtmlEditor1.Size = new System.Drawing.Size(1359, 135);
            this.winFormHtmlEditor1.SpellCheckOptions.CurlyUnderlineImageFilePath = null;
            dictionaryFileInfo1.AffixFilePath = null;
            dictionaryFileInfo1.DictionaryFilePath = null;
            dictionaryFileInfo1.EnableUserDictionary = true;
            dictionaryFileInfo1.UserDictionaryFilePath = null;
            this.winFormHtmlEditor1.SpellCheckOptions.DictionaryFile = dictionaryFileInfo1;
            this.winFormHtmlEditor1.SpellCheckOptions.NHunspellDllFolderPath = null;
            this.winFormHtmlEditor1.SpellCheckOptions.WaitAlertMessage = "Searching next misspelled word..... (please wait)";
            this.winFormHtmlEditor1.TabIndex = 2;
            // 
            // winFormHtmlEditor1.TlstrpSeparator1
            // 
            this.winFormHtmlEditor1.TlstrpSeparator1.AccessibleName = "_toolStripSeparator1";
            this.winFormHtmlEditor1.TlstrpSeparator1.Name = "_toolStripSeparator1";
            this.winFormHtmlEditor1.TlstrpSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.TlstrpSeparator2
            // 
            this.winFormHtmlEditor1.TlstrpSeparator2.AccessibleName = "_toolStripSeparator2";
            this.winFormHtmlEditor1.TlstrpSeparator2.Name = "_toolStripSeparator2";
            this.winFormHtmlEditor1.TlstrpSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.TlstrpSeparator3
            // 
            this.winFormHtmlEditor1.TlstrpSeparator3.AccessibleName = "_toolStripSeparator3";
            this.winFormHtmlEditor1.TlstrpSeparator3.Name = "_toolStripSeparator3";
            this.winFormHtmlEditor1.TlstrpSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.TlstrpSeparator4
            // 
            this.winFormHtmlEditor1.TlstrpSeparator4.AccessibleName = "_toolStripSeparator4";
            this.winFormHtmlEditor1.TlstrpSeparator4.Name = "_toolStripSeparator4";
            this.winFormHtmlEditor1.TlstrpSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.TlstrpSeparator5
            // 
            this.winFormHtmlEditor1.TlstrpSeparator5.AccessibleName = "_toolStripSeparator5";
            this.winFormHtmlEditor1.TlstrpSeparator5.Name = "_toolStripSeparator5";
            this.winFormHtmlEditor1.TlstrpSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.TlstrpSeparator6
            // 
            this.winFormHtmlEditor1.TlstrpSeparator6.AccessibleName = "_toolStripSeparator6";
            this.winFormHtmlEditor1.TlstrpSeparator6.Name = "_toolStripSeparator6";
            this.winFormHtmlEditor1.TlstrpSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.TlstrpSeparator7
            // 
            this.winFormHtmlEditor1.TlstrpSeparator7.AccessibleName = "_toolStripSeparator7";
            this.winFormHtmlEditor1.TlstrpSeparator7.Name = "_toolStripSeparator7";
            this.winFormHtmlEditor1.TlstrpSeparator7.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.TlstrpSeparator8
            // 
            this.winFormHtmlEditor1.TlstrpSeparator8.AccessibleName = "_toolStripSeparator8";
            this.winFormHtmlEditor1.TlstrpSeparator8.Name = "_toolStripSeparator8";
            this.winFormHtmlEditor1.TlstrpSeparator8.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.TlstrpSeparator9
            // 
            this.winFormHtmlEditor1.TlstrpSeparator9.AccessibleName = "_toolStripSeparator9";
            this.winFormHtmlEditor1.TlstrpSeparator9.Name = "_toolStripSeparator9";
            this.winFormHtmlEditor1.TlstrpSeparator9.Size = new System.Drawing.Size(6, 29);
            // 
            // winFormHtmlEditor1.WinFormHtmlEditor_Toolbar1
            // 
            this.winFormHtmlEditor1.Toolbar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.winFormHtmlEditor1.BtnNew,
            this.winFormHtmlEditor1.BtnOpen,
            this.winFormHtmlEditor1.BtnSave,
            this.winFormHtmlEditor1.TlstrpSeparator1,
            this.winFormHtmlEditor1.CmbFontName,
            this.winFormHtmlEditor1.CmbFontSize,
            this.winFormHtmlEditor1.TlstrpSeparator2,
            this.winFormHtmlEditor1.BtnCut,
            this.winFormHtmlEditor1.BtnCopy,
            this.winFormHtmlEditor1.BtnPaste,
            this.winFormHtmlEditor1.BtnPasteFromMSWord,
            this.winFormHtmlEditor1.TlstrpSeparator3,
            this.winFormHtmlEditor1.BtnBold,
            this.winFormHtmlEditor1.BtnItalic,
            this.winFormHtmlEditor1.BtnUnderline,
            this.winFormHtmlEditor1.TlstrpSeparator4,
            this.winFormHtmlEditor1.BtnFormatReset,
            this.winFormHtmlEditor1.BtnFormatUndo,
            this.winFormHtmlEditor1.BtnFormatRedo,
            this.winFormHtmlEditor1.BtnPrint,
            this.winFormHtmlEditor1.BtnSpellCheck,
            this.winFormHtmlEditor1.BtnSearch});
            this.winFormHtmlEditor1.Toolbar1.Location = new System.Drawing.Point(0, 0);
            this.winFormHtmlEditor1.Toolbar1.Name = "WinFormHtmlEditor_Toolbar1";
            this.winFormHtmlEditor1.Toolbar1.Size = new System.Drawing.Size(1359, 29);
            this.winFormHtmlEditor1.Toolbar1.TabIndex = 0;
            this.winFormHtmlEditor1.Toolbar1.Visible = false;
            // 
            // winFormHtmlEditor1.WinFormHtmlEditor_Toolbar2
            // 
            this.winFormHtmlEditor1.Toolbar2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.winFormHtmlEditor1.CmbTitleInsert,
            this.winFormHtmlEditor1.BtnHighlightColor,
            this.winFormHtmlEditor1.BtnFontColor,
            this.winFormHtmlEditor1.TlstrpSeparator5,
            this.winFormHtmlEditor1.BtnHyperlink,
            this.winFormHtmlEditor1.BtnImage,
            this.winFormHtmlEditor1.BtnInsertYouTubeVideo,
            this.winFormHtmlEditor1.BtnTable,
            this.winFormHtmlEditor1.BtnSymbol,
            this.winFormHtmlEditor1.BtnHorizontalRule,
            this.winFormHtmlEditor1.TlstrpSeparator6,
            this.winFormHtmlEditor1.BtnOrderedList,
            this.winFormHtmlEditor1.BtnUnOrderedList,
            this.winFormHtmlEditor1.TlstrpSeparator7,
            this.winFormHtmlEditor1.BtnAlignLeft,
            this.winFormHtmlEditor1.BtnAlignCenter,
            this.winFormHtmlEditor1.BtnAlignRight,
            this.winFormHtmlEditor1.TlstrpSeparator8,
            this.winFormHtmlEditor1.BtnOutdent,
            this.winFormHtmlEditor1.BtnIndent,
            this.winFormHtmlEditor1.TlstrpSeparator9,
            this.winFormHtmlEditor1.BtnStrikeThrough,
            this.winFormHtmlEditor1.BtnSuperScript,
            this.winFormHtmlEditor1.BtnSubscript,
            this.winFormHtmlEditor1.BtnBodyStyle});
            this.winFormHtmlEditor1.Toolbar2.Location = new System.Drawing.Point(0, 0);
            this.winFormHtmlEditor1.Toolbar2.Name = "WinFormHtmlEditor_Toolbar2";
            this.winFormHtmlEditor1.Toolbar2.Size = new System.Drawing.Size(1359, 29);
            this.winFormHtmlEditor1.Toolbar2.TabIndex = 0;
            this.winFormHtmlEditor1.Toolbar2.Visible = false;
            this.winFormHtmlEditor1.ToolbarContextMenuStrip = null;
            // 
            // winFormHtmlEditor1.WinFormHtmlEditor_ToolbarFooter
            // 
            this.winFormHtmlEditor1.ToolbarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.winFormHtmlEditor1.ToolbarFooter.Location = new System.Drawing.Point(0, 413);
            this.winFormHtmlEditor1.ToolbarFooter.Name = "WinFormHtmlEditor_ToolbarFooter";
            this.winFormHtmlEditor1.ToolbarFooter.Size = new System.Drawing.Size(1359, 25);
            this.winFormHtmlEditor1.ToolbarFooter.TabIndex = 7;
            this.winFormHtmlEditor1.ToolbarFooter.Visible = false;
            this.winFormHtmlEditor1.VerticalScroll = null;
            this.winFormHtmlEditor1.z__ignore = false;
            // 
            // SignPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1384, 614);
            this.Controls.Add(this.winFormHtmlEditor1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "SignPage";
            this.Ribbon = this.mainRibbonControl;
            this.Text = "Phê duyệt hồ sơ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SignPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            this.winFormHtmlEditor1.Toolbar1.ResumeLayout(false);
            this.winFormHtmlEditor1.Toolbar1.PerformLayout();
            this.winFormHtmlEditor1.Toolbar2.ResumeLayout(false);
            this.winFormHtmlEditor1.Toolbar2.PerformLayout();
            this.winFormHtmlEditor1.ResumeLayout(false);
            this.winFormHtmlEditor1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem btn_Signed;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor winFormHtmlEditor1;
        private DevExpress.XtraBars.BarButtonItem btnResign;
    }
}