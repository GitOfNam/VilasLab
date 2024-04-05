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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VilasLab.Base;
using VilasLab.Models;

namespace VilasLab.Pages
{
    public partial class ResultSample : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        public string IDSample { get; set; } = "";
        public string IDResult { get; set; } = "";
        int level = 1;
        public ResultSample()
        {
            InitializeComponent();
          
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
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
                btn_ExportFile.Visibility = BarItemVisibility.Never;
                bbiDelete.Visibility = BarItemVisibility.Never;
                ribbonPageGroup1.Visible = false;
            }

        }
        private void SaveData()
        {
            try
            {
                if (checkValidate())
                {
                    BeanResult beanResult = new BeanResult();
                    if (!string.IsNullOrEmpty(IDResult))
                    {
                        beanResult = beanResult.SelectByID(Guid.Parse(IDResult));
                        beanResult.idTarget = cb_Target.SelectedValue + string.Empty;
                        beanResult.expectedResult = Guid.Parse(cb_requirement.SelectedValue + string.Empty);
                        beanResult.unit = txtUnit.Text;
                        beanResult.actualResult = txtActualResult.Text;
                        beanResult.conclusion = txt_conclusion.Text;
                        beanResult.startDate = dt_StartDate.Value;
                        beanResult.completeDate = dtCompleteDate.Value;
                        beanResult.testDate = dt_TestDate.Value;
                        beanResult.idSample = IDSample;
                        beanResult.ModifiedBy = currUser.id;
                        beanResult.Modified = DateTime.Now;
                        beanResult.Update(beanResult);
                    }
                    else
                    {
                        beanResult.id = Guid.NewGuid();
                        beanResult.idTarget = cb_Target.SelectedValue + string.Empty;
                        beanResult.expectedResult = Guid.Parse(cb_requirement.SelectedValue + string.Empty); ;
                        beanResult.unit = txtUnit.Text;
                        beanResult.actualResult = txtActualResult.Text;
                        beanResult.conclusion = txt_conclusion.Text;
                        beanResult.startDate = dt_StartDate.Value;
                        beanResult.completeDate = dtCompleteDate.Value;
                        beanResult.testDate = dt_TestDate.Value;
                        beanResult.idSample = IDSample;
                        beanResult.ModifiedBy = beanResult.CreatedBy = currUser.id;
                        beanResult.Modified = beanResult.Created = DateTime.Now;
                        beanResult.Insert(beanResult);
                        IDResult = beanResult.id + string.Empty;
                    }
                    UpdateCompleteDate(dtCompleteDate.Value);
                    MessageBox.Show("Thành công!");
                }
                else
                    MessageBox.Show("Vui lòng nhập đủ thông tin cần thiết!");
            }
            catch (Exception ex)
            {
                function.TrackingError("ResultSample - SaveData", ex.ToString());
            }
        }

        private bool checkValidate()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtUnit.Text) || string.IsNullOrEmpty(cb_requirement.SelectedValue + "") || string.IsNullOrEmpty(txtActualResult.Text)
                 || string.IsNullOrEmpty(txt_conclusion.Text) || string.IsNullOrEmpty(cb_Target.SelectedValue + ""))
            {
                result = false;
            }
            return result;
        }
        public void UpdateCompleteDate(DateTime completeDate)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("sampleID", IDSample));
                parameters.Add(new SqlParameter("completedDate", completeDate));
                DataTable result = _db.Fill("UpdateCompletedDate", parameters);
            }
            catch(Exception ex)
            {
                function.TrackingError("ResultSample - UpdateCompleteDate", ex.ToString());
            }
        }
        private void SetData()
        {
            if (!string.IsNullOrEmpty(IDResult))
            {
                BeanResult beanResult = new BeanResult();
                beanResult = beanResult.SelectByID(Guid.Parse(IDResult));
                cb_Target.SelectedValue = beanResult.idTarget;
                if (!string.IsNullOrEmpty(cb_Target.SelectedValue + ""))
                {
                    BeanRequirement requirement = new BeanRequirement();
                    List<BeanRequirement> lstrequirement = new List<BeanRequirement>();
                    lstrequirement.Add(new BeanRequirement() { id = Guid.Empty, name = "" });
                    lstrequirement.AddRange(requirement.SelectAll().Where(s => s.idTarget == cb_Target.SelectedValue + "").ToList());
                    cb_requirement.DisplayMember = "name";
                    cb_requirement.ValueMember = "id";
                    cb_requirement.DataSource = lstrequirement;
                    cb_requirement.SelectedIndex = -1;
                }
                cb_requirement.SelectedValue = beanResult.expectedResult;
                txtUnit.Text = beanResult.unit;
                txtActualResult.Text = beanResult.actualResult;
                txt_conclusion.Text = beanResult.conclusion;
                dt_StartDate.Value = beanResult.startDate;
                dt_TestDate.Value = beanResult.testDate;
            }
        }
        private void SetDbCombobox()
        {
            if (!string.IsNullOrEmpty(IDSample))
            {
                BeanSample sample = new BeanSample();
                BeanTargetTest beanTargetTest = new BeanTargetTest();
                sample = sample.SelectByID(IDSample);
                List<BeanTargetTest> lstTarget = new List<BeanTargetTest>();
                lstTarget.Add(beanTargetTest.SelectByID(sample.idTarget));
                
                cb_Target.DisplayMember = "name";
                cb_Target.ValueMember = "id";
                cb_Target.DataSource = lstTarget;
            }
        }
        private void btn_ExportFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditDocumentSample page = new EditDocumentSample();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.IDResult = IDResult;
            page.WindowState = FormWindowState.Maximized;
            page.ShowDialog();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ResultSample_Load(object sender, EventArgs e)
        {
            checkPermission();
            SetDbCombobox();
            SetData();
            CheckData();
        }

        private void CheckData()
        {
            if (!string.IsNullOrEmpty(IDSample))
            {
                BeanDocument document = new BeanDocument();
                var checkTemplate1 = document.SelectAll().Where(s => s.idSample == IDSample && s.status != 0 && s.idTemplate == 1).FirstOrDefault();
                if (checkTemplate1 != null)
                {
                    btn_ExportFile.Visibility = BarItemVisibility.Never;
                }
                else
                {
                    btn_ExportFile.Visibility = BarItemVisibility.Always;
                }
                var checkTemplate2 = document.SelectAll().Where(s => s.idSample == IDSample && s.status != 0 && s.idTemplate == 2).FirstOrDefault();
                if (checkTemplate2 != null)
                {
                    btnDocTest.Visibility = BarItemVisibility.Never;
                }
                else
                {
                    btnDocTest.Visibility = BarItemVisibility.Always;
                }
            }
        }
        private void refreshData()
        {
            //cb_Target.SelectedValue = "";
            cb_requirement.SelectedIndex = -1;
            txtUnit.Text = "";
            txtActualResult.Text = "";
            txt_conclusion.Text = "";
            dt_StartDate.Value = DateTime.Now;
            dt_TestDate.Value = DateTime.Now;
            IDResult = "";
        }
        private void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
            this.Close();
        }

        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
            refreshData();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(IDResult))
                {
                    var mes = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mes == DialogResult.Yes)
                    {
                        BeanResult result = new BeanResult();
                        result = result.SelectByID(Guid.Parse(IDResult));
                        result.Delete(result);
                        refreshData();
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
                function.TrackingError("ResultSample - bbiDelete_ItemClick", ex.ToString());
            }
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cb_Target_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cb_Target.SelectedValue + ""))
            {
                BeanRequirement requirement = new BeanRequirement();
                List<BeanRequirement> lstrequirement = new List<BeanRequirement>();
                lstrequirement.Add(new BeanRequirement() { id = Guid.Empty, name = "" });
                lstrequirement.AddRange(requirement.SelectAll().Where(s=>s.idTarget == cb_Target.SelectedValue + "").ToList());
                cb_requirement.DisplayMember = "name";
                cb_requirement.ValueMember = "id";
                cb_requirement.DataSource = lstrequirement;
                cb_requirement.SelectedIndex = -1;

                BeanTargetTest tar = new BeanTargetTest();
                tar = tar.SelectByID(cb_Target.SelectedValue + "");
                if (tar != null)
                {
                    if (tar.timeLine > 0)
                    {
                        DateTime overDue = dt_StartDate.Value.AddDays(tar.timeLine);
                        dtCompleteDate.Value = overDue;
                    }
                }
            }
        }

        private void dt_TestDate_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dt_StartDate_ValueChanged(object sender, EventArgs e)
        {
            if (cb_Target.SelectedValue != null)
            {
                BeanTargetTest tar = new BeanTargetTest();
                tar = tar.SelectByID(cb_Target.SelectedValue + "");
                if (tar != null)
                {
                    if (tar.timeLine > 0)
                    {
                        DateTime overDue = dt_StartDate.Value.AddDays(tar.timeLine);
                        dtCompleteDate.Value = overDue;
                    }
                }
            }
        }

        private void btnDocTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditDocumentSample page = new EditDocumentSample();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.IDResult = IDResult;
            page.IDTemplate = 2;
            page.WindowState = FormWindowState.Maximized;
            page.ShowDialog();
            this.Hide();
        }
    }
}
