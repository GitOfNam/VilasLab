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
    public partial class CommentPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        public string IDDoc { get; set; } = "";
        public CommentPage()
        {
            InitializeComponent();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                BeanDocument document = new BeanDocument();
                document = document.SelectByID(IDDoc);
                if(document != null)
                {
                    DelNotify(IDDoc);
                    document.status = 0;
                    document.Update(document);
                    SetNotify(document.CreatedBy, IDDoc);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                function.TrackingError("CommentPage - bbiSaveAndClose_ItemClick", ex.ToString());
            }
        }
        private void SetNotify(Guid NgKiemThu, string idDocument)
        {
            BeanNotify ModelNotify = new BeanNotify();
            ModelNotify.RelatedID = idDocument;
            ModelNotify.Status = 0;
            ModelNotify.Title = richTextBox1.Text;
            ModelNotify.Category = "Yêu cầu điều chỉnh";
            ModelNotify.AssignTo = NgKiemThu;
            ModelNotify.Created = DateTime.Now;
            ModelNotify.CreatedBy = currUser.id;
            ModelNotify.Insert(ModelNotify);
        }
        private void DelNotify(string idDocument)
        {
            BeanNotify ModelNotify = new BeanNotify();
            ModelNotify = ModelNotify.SelectAll().Where(s => s.RelatedID == idDocument && s.Status == 0 && s.Category == "Document").FirstOrDefault();
            if (ModelNotify != null)
            {
                ModelNotify.Delete(ModelNotify);
            }
        }

        private void CommentPage_Load(object sender, EventArgs e)
        {
            
        }
    }
}
