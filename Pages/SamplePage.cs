using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
    public partial class SamplePage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        int level = 1;
        DataTable dtExport = new DataTable();
        public SamplePage()
        {
            InitializeComponent();
            
        }
        private void SetDbCombobox()
        {
            BeanFactory beanFactory = new BeanFactory();
            List<BeanFactory> lstBeanFactory = new List<BeanFactory>();
            lstBeanFactory.Add(new BeanFactory() { id = Guid.Empty, name = "" });
            lstBeanFactory.AddRange(beanFactory.SelectAll());
            cb_Factory.DisplayMember = "name";
            cb_Factory.ValueMember = "id";
            cb_Factory.DataSource = lstBeanFactory;
            cb_Factory.SelectedIndex = -1;

            BeanIngredient beanIngredient = new BeanIngredient();
            List<BeanIngredient> lstBeanIngredient = new List<BeanIngredient>();
            lstBeanIngredient.Add(new BeanIngredient() { id = Guid.Empty, name = "" });
            lstBeanIngredient.AddRange(beanIngredient.SelectAll());
            cb_Ingredient.DisplayMember = "name";
            cb_Ingredient.ValueMember = "id";
            cb_Ingredient.DataSource = lstBeanIngredient;
            cb_Ingredient.SelectedIndex = -1;


            BeanSpecies beanSpecies = new BeanSpecies();
            List<BeanSpecies> lstBeanSpecies = new List<BeanSpecies>();
            lstBeanSpecies.Add(new BeanSpecies() { id = Guid.Empty, name = "" });
            lstBeanSpecies.AddRange(beanSpecies.SelectAll());
            cb_Species.DisplayMember = "name";
            cb_Species.ValueMember = "id";
            cb_Species.DataSource = lstBeanSpecies;
            cb_Species.SelectedIndex = -1;

            BeanTargetTest beanTargetTest = new BeanTargetTest();
            List<BeanTargetTest> lstBeanTargetTest = new List<BeanTargetTest>();
            lstBeanTargetTest.Add(new BeanTargetTest() { id = "", name = "" });
            lstBeanTargetTest.AddRange(beanTargetTest.SelectAll());
            cb_Target.DisplayMember = "name";
            cb_Target.ValueMember = "id";
            cb_Target.DataSource = lstBeanTargetTest;
            cb_Target.SelectedIndex = -1;

            BeanTestType beanTestType = new BeanTestType();
            List<BeanTestType> lstBeanTestType = new List<BeanTestType>();
            lstBeanTestType.Add(new BeanTestType() { id = Guid.Empty, name = "" });
            lstBeanTestType.AddRange(beanTestType.SelectAll());
            cb_type.DisplayMember = "name";
            cb_type.ValueMember = "id";
            cb_type.DataSource = lstBeanTestType;
            cb_type.SelectedIndex = -1;

            BeanCustomer beanCustomer = new BeanCustomer();
            List<BeanCustomer> lstBeanCustomer = new List<BeanCustomer>();
            lstBeanCustomer.Add(new BeanCustomer() { id = Guid.Empty, fullName = "" });
            lstBeanCustomer.AddRange(beanCustomer.SelectAll());
            cb_NguoiKiemThu.DisplayMember = "fullName";
            cb_NguoiKiemThu.ValueMember = "id";
            cb_NguoiKiemThu.DataSource = lstBeanCustomer;
            cb_NguoiKiemThu.SelectedIndex = -1;

            BeanClient beanClient = new BeanClient();
            List<BeanClient> lstBeanClient = new List<BeanClient>();
            lstBeanClient.Add(new BeanClient() { id = Guid.Empty, name = "" });
            lstBeanClient.AddRange(beanClient.SelectAll());
            cbClient.DisplayMember = "name";
            cbClient.ValueMember = "id";
            cbClient.DataSource = lstBeanClient;
            cbClient.SelectedIndex = -1;

            BeanMachine beanMachine = new BeanMachine();
            List<BeanMachine> lstBeanMachine = new List<BeanMachine>();
            lstBeanMachine.Add(new BeanMachine() { id = 0, name = "" });
            lstBeanMachine.AddRange(beanMachine.SelectAll());
            cb_Machine.DisplayMember = "name";
            cb_Machine.ValueMember = "id";
            cb_Machine.DataSource = lstBeanMachine;
            cb_Machine.SelectedIndex = -1;
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

            if(level == 1)
            {
                bbiDelete.Visibility = BarItemVisibility.Never;
                bbiEdit.Visibility = BarItemVisibility.Never;
                btnLstResult.Visibility = BarItemVisibility.Never;
                btnView.Visibility = BarItemVisibility.Never;
            }

        }
        private void GetData()
        {
            DataTable dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.Rows.Count;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public DataTable GetDataSource(string keyword = "",string strIngredient = "", string strFactory = "", string strSpecies = "", string strType = "",string strNguoiKiemThu = "",string strTarget = "",string strClient = "",string strMachine = "",DateTime? strFromDate = null,DateTime? strToDate = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("UserID", currUser.id));
            if(!string.IsNullOrEmpty(keyword))
                parameters.Add(new SqlParameter("KeyWord", keyword));
            if (!string.IsNullOrEmpty(strIngredient) && strIngredient != Guid.Empty.ToString())
                parameters.Add(new SqlParameter("Ingredient", strIngredient));
            if (!string.IsNullOrEmpty(strFactory) && strFactory != Guid.Empty.ToString())
                parameters.Add(new SqlParameter("Factory", strFactory));
            if (!string.IsNullOrEmpty(strSpecies) && strSpecies != Guid.Empty.ToString())
                parameters.Add(new SqlParameter("Species", strSpecies));
            if (!string.IsNullOrEmpty(strType) && strType != Guid.Empty.ToString())
                parameters.Add(new SqlParameter("Type", strType));
            if (!string.IsNullOrEmpty(strNguoiKiemThu) && strNguoiKiemThu != Guid.Empty.ToString())
                parameters.Add(new SqlParameter("NguoiKiemThu", strNguoiKiemThu));
            if (!string.IsNullOrEmpty(strTarget))
                parameters.Add(new SqlParameter("Target", strTarget));
            if (!string.IsNullOrEmpty(strClient))
                parameters.Add(new SqlParameter("Client", strClient));
            if (!string.IsNullOrEmpty(strMachine))
                parameters.Add(new SqlParameter("Machine", Convert.ToInt32(strMachine)));
            if (strFromDate.HasValue)
                parameters.Add(new SqlParameter("FromDate", strFromDate));
            if (strToDate.HasValue)
                parameters.Add(new SqlParameter("ToDate", strToDate));
            parameters.Add(new SqlParameter("IsResult", ckIsResult.Checked));
            DataTable result = _db.Fill("stor_GetAllDataSample", parameters);
            dtExport = result;
            return result;
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sample_Ins_Update page = new Sample_Ins_Update();
            page.currUser = currUser;
            page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
            page.ShowDialog();
        }

        private void btn_ShowResult_ItemClick(object sender, ItemClickEventArgs e)
        {
            string IDSample = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
            ResultSample page = new ResultSample();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.ShowDialog();
        }

        private void SamplePage_Load(object sender, EventArgs e)
        {
            bbiDelete.Visibility = BarItemVisibility.Never;
            bbiEdit.Visibility = BarItemVisibility.Never;
            btn_ShowResult.Visibility = BarItemVisibility.Never;
            SetDbCombobox();
            fromDate.DateTime = DateTime.Now.AddDays(-30);
            toDate.DateTime = DateTime.Now;
            checkPermission();
            GetData();
        }

        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (level != 1)
            {
                bbiDelete.Visibility = BarItemVisibility.Always;
                bbiEdit.Visibility = BarItemVisibility.Always;
            }
            btnView.Visibility = BarItemVisibility.Always;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            string IDSample = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
            Sample_Ins_Update page = new Sample_Ins_Update();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
            page.ShowDialog();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string IDSample = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
                if (!string.IsNullOrEmpty(IDSample))
                {
                    var mes = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mes == DialogResult.Yes)
                    {
                        BeanSample sample = new BeanSample();
                        sample = sample.SelectByID(IDSample);
                        if ( !string.IsNullOrEmpty(sample.id))
                        {
                            BeanResult result = new BeanResult();
                            List<BeanResult> lstResult = new List<BeanResult>();
                            lstResult = result.SelectAll().Where(s => s.idSample == sample.id).ToList();
                            foreach (BeanResult item in lstResult)
                            {
                                item.Delete(item);
                            }
                            sample.Delete(sample);
                            GetData();
                            MessageBox.Show("Thành công!");
                        }
                        else
                            MessageBox.Show("Không tìm thấy nội dung cần xóa!");
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
                function.TrackingError("SamplePage - LoadDataChart", ex.ToString());
            }
        }

        private void btnLstResult_ItemClick(object sender, ItemClickEventArgs e)
        {
            string IDSample = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
            AllResultPage page = new AllResultPage();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.ShowDialog();
        }

        private void btnView_ItemClick(object sender, ItemClickEventArgs e)
        {
            string IDSample = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
            Sample_Ins_Update page = new Sample_Ins_Update();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.ShowDialog();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetData();
        }

        private void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataTable dataSource = GetDataSource(txtKeyWord.Text, cb_Ingredient.SelectedValue + "", cb_Factory.SelectedValue + "", cb_Species.SelectedValue + "", cb_type.SelectedValue + "", cb_NguoiKiemThu.SelectedValue + "", cb_Target.SelectedValue + "", cbClient.SelectedValue + "", cb_Machine.SelectedValue + "", fromDate.DateTime,toDate.DateTime);
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.Rows.Count;
            
        }
        private void Form1_FormClosing(Object sender, FormClosedEventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            UrlPageSave page = new UrlPageSave();
            page.strTitle = "ExportExcel";
            page.StartPosition = FormStartPosition.CenterScreen;
            page.FormClosed += new FormClosedEventHandler(Export);
            page.ShowDialog();
        }
        private void Export(Object sender, FormClosedEventArgs e)
        {
            try
            {
                string fullUrl = "";
                BeanUrlSave bean = new BeanUrlSave();
                bean = bean.SelectByID("ExportExcel");
                if (!string.IsNullOrEmpty(bean.urlLink))
                {
                    fullUrl = function.exportExcelResult(bean.urlLink, dtExport);

                }
                else
                {
                    string urlFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                    fullUrl = function.exportExcelResult(urlFolder, dtExport);
                }
                if (!string.IsNullOrEmpty(fullUrl))
                {
                    DialogResult dialogResult = MessageBox.Show("Tải xuống thành công! Bạn có muốn mở file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(fullUrl);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đường dẫn lưu file!");
                    function.TrackingError("SamplePage - Export", "Lỗi lưu excel");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy đường dẫn lưu file!");
                function.TrackingError("SamplePage - Export", ex.ToString());
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            string IDSample = gridView.GetDataRow(gridView.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
            Sample_Ins_Update page = new Sample_Ins_Update();
            page.currUser = currUser;
            page.IDSample = IDSample;
            page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
            page.ShowDialog();
        }
    }
}