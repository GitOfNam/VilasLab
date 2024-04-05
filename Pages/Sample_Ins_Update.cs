using DevExpress.XtraBars;
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VilasLab.Base;
using VilasLab.Models;

namespace VilasLab.Pages
{
    public partial class Sample_Ins_Update : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        public string IDSample { get; set; } = "";
        int level = 1;
        bool fisrtRun = true;
        public Sample_Ins_Update()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            if (!string.IsNullOrEmpty(IDSample))
            {
                DataTable dataSource = GetDataSource();
                gridControl1.DataSource = dataSource;
                gridView1.Columns[0].Visible = false;
            }
        }
        public DataTable GetDataSource()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", IDSample));
            DataTable result = _db.Fill("stor_GetResultSampleByID", parameters);
            return result;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mainRibbonControl_Click(object sender, EventArgs e)
        {

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
            
            
            if (level == 1)
            {
                bbiDelete.Visibility = BarItemVisibility.Never;
                bbiSave.Visibility = BarItemVisibility.Never;
                bbiSaveAndClose.Visibility = BarItemVisibility.Never;
                bbiSaveAndNew.Visibility = BarItemVisibility.Never;
            }

        }
        private void Sample_Ins_Update_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            dt_overDue.Value = DateTime.Now.AddDays(7);
            checkPermission();
            SetDbCombobox();
            SetData();
            GetData();
        }
        private void SetData()
        {
            if (!string.IsNullOrEmpty(IDSample))
            {
                BeanSample beanSample = new BeanSample();
                beanSample = beanSample.SelectByID(IDSample);
                txtID.Text = IDSample;
                txtTitle.Text = beanSample.name;
                rtb_descript.Text = beanSample.descript;
                cbMachine.SelectedValue = beanSample.idMachine;
                nmrSampleNumber.Value = beanSample.sampleNumber;
                nmb_Pressure.Value = beanSample.pressure;
                nmb_Diameter.Value = beanSample.diameter;
                cb_type.SelectedValue = Guid.Parse(beanSample.idType + string.Empty);
                cb_NguoiKiemThu.SelectedValue = Guid.Parse(beanSample.idCustomer + string.Empty);
                cb_Factory.SelectedValue = Guid.Parse(beanSample.idFactory + string.Empty);
                cb_Ingredient.SelectedValue = Guid.Parse(beanSample.idIngredient + string.Empty);
                cb_Species.SelectedValue = Guid.Parse(beanSample.idSpecies + string.Empty);
                cbClient.SelectedValue = Guid.Parse(beanSample.idClient + string.Empty);
                dt_overDue.Value = beanSample.overdue != null ? Convert.ToDateTime(beanSample.overdue) : DateTime.Now;
                cb_Target.SelectedValue = beanSample.idTarget + string.Empty;
            }
        }
        private void SetDbCombobox()
        {
            BeanFactory beanFactory = new BeanFactory(); 
            cb_Factory.DisplayMember = "name";
            cb_Factory.ValueMember = "id";
            cb_Factory.DataSource = beanFactory.SelectAll();
            cb_Factory.SelectedIndex = -1;

            BeanIngredient beanIngredient = new BeanIngredient();
            cb_Ingredient.DisplayMember = "name";
            cb_Ingredient.ValueMember = "id";
            cb_Ingredient.DataSource = beanIngredient.SelectAll();
            cb_Ingredient.SelectedIndex = -1;


            BeanSpecies beanSpecies = new BeanSpecies();
            cb_Species.DisplayMember = "name";
            cb_Species.ValueMember = "id";
            cb_Species.DataSource = beanSpecies.SelectAll();
            cb_Species.SelectedIndex = -1;

            BeanTargetTest beanTargetTest = new BeanTargetTest();
            cb_Target.DisplayMember = "name";
            cb_Target.ValueMember = "id";
            cb_Target.DataSource = beanTargetTest.SelectAll();
            cb_Target.SelectedIndex = -1;

            BeanTestType beanTestType = new BeanTestType();
            cb_type.DisplayMember = "name";
            cb_type.ValueMember = "id";
            cb_type.DataSource = beanTestType.SelectAll();
            cb_type.SelectedIndex = -1;

            BeanCustomer beanCustomer = new BeanCustomer();
            cb_NguoiKiemThu.DisplayMember = "fullName";
            cb_NguoiKiemThu.ValueMember = "id";
            cb_NguoiKiemThu.DataSource = beanCustomer.SelectAll();
            cb_NguoiKiemThu.SelectedIndex = -1;

            BeanClient beanClient = new BeanClient();
            cbClient.DisplayMember = "name";
            cbClient.ValueMember = "id";
            cbClient.DataSource = beanClient.SelectAll();
            cbClient.SelectedIndex = -1;


            BeanMachine beanMachine = new BeanMachine();
            List<BeanMachine> lstBeanMachine = new List<BeanMachine>();
            if (!string.IsNullOrEmpty(IDSample))
            {
                BeanSample sample = new BeanSample();
                sample = sample.SelectByID(IDSample);
                List<BeanMachine> data = beanMachine.SelectAll().Where(s => s.idFactory == sample.idFactory).ToList();
                if (data != null && data.Count > 0)
                {
                    lstBeanMachine.AddRange(data);
                    cbMachine.DisplayMember = "name";
                    cbMachine.ValueMember = "id";
                    cbMachine.DataSource = lstBeanMachine;
                }
            }
            else
            {
                lstBeanMachine.Add(new BeanMachine() { id = 0, name = "" });
                lstBeanMachine.AddRange(beanMachine.SelectAll());
                cbMachine.DisplayMember = "name";
                cbMachine.ValueMember = "id";
                cbMachine.DataSource = lstBeanMachine;
                cbMachine.SelectedIndex = -1;
            }
           
        }
        private void SaveData()
        {
            try
            {
                if (checkValidate())
                {
                    BeanSample beanSample = new BeanSample();
                    if (!string.IsNullOrEmpty(IDSample))
                    {
                        beanSample.id = IDSample;
                        beanSample = beanSample.SelectByID(IDSample);
                        beanSample.name = txtTitle.Text;
                        beanSample.sampleNumber = Convert.ToInt32(nmrSampleNumber.Value);
                        beanSample.pressure = Convert.ToDecimal(nmb_Pressure.Value);
                        beanSample.diameter = Convert.ToDecimal(nmb_Diameter.Value);
                        beanSample.idType = Guid.Parse(cb_type.SelectedValue + "");
                        beanSample.idCustomer = Guid.Parse(cb_NguoiKiemThu.SelectedValue + "");
                        beanSample.idFactory = Guid.Parse(cb_Factory.SelectedValue + "");
                        beanSample.idIngredient = Guid.Parse(cb_Ingredient.SelectedValue + "");
                        beanSample.idSpecies = Guid.Parse(cb_Species.SelectedValue + "");
                        beanSample.idClient = Guid.Parse(cbClient.SelectedValue + "");
                        beanSample.idTarget = cb_Target.SelectedValue + "";
                        beanSample.idMachine = Convert.ToInt32(cbMachine.SelectedValue);
                        beanSample.descript = rtb_descript.Text;
                        beanSample.status = false;
                        beanSample.startDate = dt_StartDate.Value;
                        beanSample.overdue = dt_overDue.Value;
                        beanSample.ModifiedBy = currUser.id;
                        beanSample.Modified = DateTime.Now;
                        beanSample.Update(beanSample);
                    }
                    else
                    {
                        beanSample.id = txtID.Text;
                        beanSample.name = txtTitle.Text;
                        beanSample.sampleNumber = Convert.ToInt32(nmrSampleNumber.Value);
                        beanSample.pressure = Convert.ToDecimal(nmb_Pressure.Value);
                        beanSample.diameter = Convert.ToDecimal(nmb_Diameter.Value);
                        beanSample.idType = Guid.Parse(cb_type.SelectedValue + "");
                        beanSample.idCustomer = Guid.Parse(cb_NguoiKiemThu.SelectedValue + "");
                        beanSample.idFactory = Guid.Parse(cb_Factory.SelectedValue + "");
                        beanSample.idIngredient = Guid.Parse(cb_Ingredient.SelectedValue + "");
                        beanSample.idSpecies = Guid.Parse(cb_Species.SelectedValue + "");
                        beanSample.idClient = Guid.Parse(cbClient.SelectedValue + "");
                        beanSample.idTarget = cb_Target.SelectedValue + "";
                        beanSample.idMachine = Convert.ToInt32(cbMachine.SelectedValue);
                        beanSample.descript = rtb_descript.Text;
                        beanSample.status = false;
                        beanSample.startDate = dt_StartDate.Value;
                        beanSample.overdue = dt_overDue.Value;
                        beanSample.ModifiedBy = beanSample.CreatedBy = currUser.id;
                        beanSample.Modified = beanSample.Created = DateTime.Now;
                        beanSample.Insert(beanSample);
                        IDSample = beanSample.id;
                    }
                    DelNotify(Guid.Parse(cb_NguoiKiemThu.SelectedValue + ""), IDSample);
                    SetNotify(Guid.Parse(cb_NguoiKiemThu.SelectedValue + ""), IDSample);
                    MessageBox.Show("Thành công!");
                }
                else
                    MessageBox.Show("Vui lòng nhập đủ thông tin cần thiết!");
                
            }
            catch (Exception ex)
            {
                function.TrackingError("Sample_Ins_Update - SaveData", ex.ToString());
            }
        }
        private bool checkValidate()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(cb_type.SelectedValue + "") || string.IsNullOrEmpty(cb_NguoiKiemThu.SelectedValue + "")
                 || string.IsNullOrEmpty(cb_Factory.SelectedValue + "") || string.IsNullOrEmpty(cb_Ingredient.SelectedValue + "") || string.IsNullOrEmpty(cb_Species.SelectedValue + "")
                 || string.IsNullOrEmpty(cbClient.SelectedValue + "") || string.IsNullOrEmpty(cb_Target.SelectedValue + "") || string.IsNullOrEmpty(cbMachine.SelectedValue + ""))
            {
                result = false;
            }
            return result;
        }
        private void freshData()
        {
            txtID.Text = "";
            txtTitle.Text = "";
            nmrSampleNumber.Value =0;
            nmb_Pressure.Value = 0;
            nmb_Diameter.Value = 0;
            cb_type.SelectedIndex = -1;
            cb_NguoiKiemThu.SelectedIndex = -1;
            cb_Factory.SelectedIndex = -1;
            cb_Ingredient.SelectedIndex = -1;
            cb_Species.SelectedIndex = -1;
            cb_Target.SelectedIndex = -1;
            cbClient.SelectedIndex = -1;
            dt_overDue.Value = DateTime.Now;
            IDSample = "";
        }
        private void SetNotify(Guid NgKiemThu,string idSample)
        {
            BeanNotify ModelNotify = new BeanNotify();
            ModelNotify.RelatedID = idSample;
            ModelNotify.Status = 0;
            ModelNotify.Title = "Bạn có yêu cầu kiểm thử mới: "+ idSample;
            ModelNotify.Category = "Sample";
            ModelNotify.AssignTo = NgKiemThu;
            ModelNotify.Created = DateTime.Now;
            ModelNotify.CreatedBy = currUser.id;
            ModelNotify.Insert(ModelNotify);
        }
        private void DelNotify(Guid NgKiemThu, string idSample)
        {
            BeanNotify ModelNotify = new BeanNotify();
            ModelNotify = ModelNotify.SelectAll().Where(s => s.AssignTo == NgKiemThu && s.RelatedID == idSample).FirstOrDefault();
            if(ModelNotify != null)
            {
                ModelNotify.Delete(ModelNotify);
            }
        }
        private void CompletedNotify(Guid NgKiemThu, string idSample)
        {
            BeanNotify ModelNotify = new BeanNotify();
            ModelNotify = ModelNotify.SelectAll().Where(s => s.AssignTo == NgKiemThu && s.RelatedID == idSample).FirstOrDefault();
            if (ModelNotify != null)
            {
                ModelNotify.Status = 1;
                ModelNotify.Modified = DateTime.Now;
                ModelNotify.Update(ModelNotify);
            }
        }
        private void cb_Target_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_Target.SelectedValue != null && IDSample == "")
            {
                txtID.Text = DateTime.Now.ToString("ddMMyy") +"/"+ cb_Target.SelectedValue + "/" + selectCountSample();
                BeanTargetTest tar = new BeanTargetTest();
                tar = tar.SelectByID(cb_Target.SelectedValue + "");
                if(tar != null)
                {
                    if(tar.timeLine > 0)
                    {
                        DateTime overDue = dt_StartDate.Value.AddDays(tar.timeLine);
                        dt_overDue.Value = overDue;
                    }
                }
            }
        }

        private string selectCountSample()
        {
            string strCount = "001";
            BeanSample beanSample = new BeanSample();
            strCount = (beanSample.SelectAll().Where(s => Convert.ToDateTime(s.Created).Month == DateTime.Now.Month && Convert.ToDateTime(s.Created).Year == DateTime.Now.Year).Count() + 1).ToString("000");
            return strCount;
        }
        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            GetData();
        }

        private void btn_EnterResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AllResultPage page = new AllResultPage();
            //page.currUser = currUser;
            //page.IDSample = IDSample;
            //page.ShowDialog();
            ResultSample page = new ResultSample();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.ShowDialog();
        }

        private void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
            this.Close();
        }

        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
            freshData();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(IDSample))
                {
                    var mes = MessageBox.Show("Bạn có chắc chắn muốn xóa mẫu và kết quả mẫu?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mes == DialogResult.Yes)
                    {
                        BeanSample bean = new BeanSample();
                        bean = bean.SelectByID(IDSample);
                        if(!string.IsNullOrEmpty(bean.id))
                        {
                            BeanResult result = new BeanResult();
                            List<BeanResult> lstResult = new List<BeanResult>();
                            lstResult = result.SelectAll().Where(s => s.idSample == bean.id).ToList();
                            foreach(BeanResult item in lstResult)
                            {
                                item.Delete(item);
                            }
                        }
                        bean.Delete(bean);
                        GetData();
                        MessageBox.Show("Thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nội dung cần xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void dt_StartDate_ValueChanged(object sender, EventArgs e)
        {
            if (cb_Target.SelectedValue != null && IDSample == "")
            {
                BeanTargetTest tar = new BeanTargetTest();
                tar = tar.SelectByID(cb_Target.SelectedValue + "");
                if (tar != null)
                {
                    if (tar.timeLine > 0)
                    {
                        DateTime overDue = dt_StartDate.Value.AddDays(tar.timeLine);
                        dt_overDue.Value = overDue;
                    }
                }
            }
        }

        private void cb_Factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeanMachine beanMachine = new BeanMachine();
            List<BeanMachine> lstBeanMachine = new List<BeanMachine>();
            if (cb_Factory.SelectedValue != null && !fisrtRun)
            {
                List<BeanMachine> data = beanMachine.SelectAll().Where(s => s.idFactory == Guid.Parse(cb_Factory.SelectedValue + "")).ToList();
                if (data != null && data.Count > 0)
                {
                    lstBeanMachine.AddRange(data);
                    cbMachine.DisplayMember = "name";
                    cbMachine.ValueMember = "id";
                    cbMachine.DataSource = lstBeanMachine;
                }
            }
            
        }

        private void cb_Factory_ValueMemberChanged(object sender, EventArgs e)
        {
           
        }

        private void cb_Factory_DisplayMemberChanged(object sender, EventArgs e)
        {
           
        }

        private void Sample_Ins_Update_Shown(object sender, EventArgs e)
        {
            if (fisrtRun)
                fisrtRun = false;
        }
    }
}
