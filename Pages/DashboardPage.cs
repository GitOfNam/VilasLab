using DevExpress.Drawing;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
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
    public partial class DashboardPage : DevExpress.XtraEditors.XtraForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        int level = 1;
        public DashboardPage()
        {
            InitializeComponent();
           
        }
        public DataTable GetDataSource()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("userID", currUser.id));
            DataTable result = _db.Fill("GetAllNotify",parameters);
            return result;
        }
        private void checkPermission()
        {
            BeanCustomer customer = new BeanCustomer();
            BeanPermission permission = new BeanPermission();
            customer = customer.SelectByID(currUser.id);
            if(customer.idPermission != null)
            {
                level = permission.SelectByID(customer.idPermission).level;
            }
            currUser = customer;
            if(level <= 2)
            {
                btn_BackupDB.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                rb_Setting.Visible = false;
            }
            if (level < 4)
            {
                ribbonSettingTemp.Visible = false;
            }

        }
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_ShowSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SamplePage page = new SamplePage();
            page.currUser = currUser;
            page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
            page.ShowDialog();
        }

        private void btn_BackupDB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UrlPageSave page = new UrlPageSave();
            page.strTitle = "Backup";
            page.StartPosition = FormStartPosition.CenterScreen;
            page.FormClosed += new FormClosedEventHandler(Backup_FormClosing);
            page.ShowDialog();
           
        }

        private void btnLstUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomerPage page = new CustomerPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.FormClosed += new FormClosedEventHandler(ReloadUser_FormClosing);
            page.ShowDialog();
        }

        private void btnChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangePassPage page = new ChangePassPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen; 
            page.FormClosed += new FormClosedEventHandler(ReloadUser_FormClosing);
            page.ShowDialog();
        }
        private void DashboardPage_Load(object sender, EventArgs e)
        {
            getDataDieuKien();
            LoadDataGrid();
            checkPermission();
            SetDbCombobox();
            LoadDataChart();
            
        }
        private void getDataDieuKien()
        {
            try
            {
                comboBox2.SelectedItem = "Month";
                
                if (comboBox2.SelectedItem + "" == "Month")
                {
                    dateEdit1.Properties.Mask.EditMask = "MM/yyyy";
                    dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
                    dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView;
                }
                else if (comboBox2.SelectedItem + "" == "Year")
                {
                    dateEdit1.Properties.Mask.EditMask = "yyyy";
                    dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
                    dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
                }
                dateEdit1.DateTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - getDataDieuKien", ex.ToString());
            }

        }
        private void SetDbCombobox()
        {
            BeanFactory beanFactory = new BeanFactory();
            cb_Factory.DisplayMember = "name";
            cb_Factory.ValueMember = "id";
            cb_Factory.DataSource = beanFactory.SelectAll();
            //cb_Factory.SelectedIndex = -1;

            BeanIngredient beanIngredient = new BeanIngredient();
            cb_Ingredient.DisplayMember = "name";
            cb_Ingredient.ValueMember = "id";
            cb_Ingredient.DataSource = beanIngredient.SelectAll();
            //cb_Ingredient.SelectedIndex = -1;


            BeanSpecies beanSpecies = new BeanSpecies();
            cb_Species.DisplayMember = "name";
            cb_Species.ValueMember = "id";
            cb_Species.DataSource = beanSpecies.SelectAll();
            //cb_Species.SelectedIndex = -1;

            BeanTargetTest beanTargetTest = new BeanTargetTest();
            cb_Target.DisplayMember = "name";
            cb_Target.ValueMember = "id";
            cb_Target.DataSource = beanTargetTest.SelectAll();
            //cb_Target.SelectedIndex = -1;

            BeanTestType beanTestType = new BeanTestType();
            cb_type.DisplayMember = "name";
            cb_type.ValueMember = "id";
            cb_type.DataSource = beanTestType.SelectAll();
            //cb_type.SelectedIndex = -1;

            BeanCustomer beanCustomer = new BeanCustomer();
            cb_NguoiKiemThu.DisplayMember = "fullName";
            cb_NguoiKiemThu.ValueMember = "id";
            cb_NguoiKiemThu.DataSource = beanCustomer.SelectAll();
            //cb_NguoiKiemThu.SelectedIndex = -1;

            BeanClient beanClient = new BeanClient();
            cbClient.DisplayMember = "name";
            cbClient.ValueMember = "id";
            cbClient.DataSource = beanClient.SelectAll();
            //cbClient.SelectedIndex = -1;

            BeanMachine beanMachine = new BeanMachine();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = beanMachine.SelectAll();
        }
        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataGrid();
        }
        private void LoadDataChart()
        {
            try
            {
                chartFactory.Series.Clear();
                getDataSource(chartFactory, cb_Factory.SelectedValue + "","Fac", "nhà máy");
                chart_Ingredient.Series.Clear();
                getDataSource(chart_Ingredient, cb_Ingredient.SelectedValue + "", "Ing", "nguyên liệu");
                chart_Target.Series.Clear();
                getDataSource(chart_Target, cb_Target.SelectedValue + "", "Tar", "chỉ tiêu");
                chart_Species.Series.Clear();
                getDataSource(chart_Species, cb_Species.SelectedValue + "", "Spe", "thành phần");
                chart_type.Series.Clear();
                getDataSource(chart_type, cb_type.SelectedValue + "", "Type", "loại kiểm thử");
                chart_NguoiKiemThu.Series.Clear();
                getDataSource(chart_NguoiKiemThu, cb_NguoiKiemThu.SelectedValue + "", "NguoiKiemThu", "người kiểm thử");
                chartClient.Series.Clear();
                getDataSource(chartClient, cbClient.SelectedValue + "", "Client", "khách hàng");
                chartMachine.Series.Clear();
                getDataSource(chartMachine, comboBox1.SelectedValue + "", "Machine", "máy sản xuất");
                chartALL.Series.Clear();
                getDataSource(chartALL,"ALL", "ALL", "tất cả");
            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - LoadDataChart", ex.ToString());
            }
           
        }
        private void getDataSource(ChartControl chart,string value,string type,string Title)
        {
            try
            {
                List<CategoricalPoint> dataChart = new List<CategoricalPoint>();
                if (type == "Fac")
                    dataChart = GetDataSourceChart(strFactory: value);
                else if (type == "Ing")
                    dataChart = GetDataSourceChart(strIngredient: value);
                else if (type == "Tar")
                    dataChart = GetDataSourceChart(strTarget: value);
                else if (type == "Spe")
                    dataChart = GetDataSourceChart(strSpecies: value);
                else if (type == "Type")
                    dataChart = GetDataSourceChart(strType: value);
                else if (type == "NguoiKiemThu")
                    dataChart = GetDataSourceChart(strNguoiKiemThu: value);
                else if (type == "Client")
                    dataChart = GetDataSourceChart(strClient: value);
                else if (type == "Machine")
                    dataChart = GetDataSourceChart(strMachine: value);
                else if (type == "ALL")
                    dataChart = GetDataSourceChart(strALL: value);
                
                //Series series1 = new Series("Đạt", ViewType.Pie);
                //chart.Series.Add(series1);
                //series1.DataSource = dataChart;
                //series1.ArgumentScaleType = ScaleType.Auto;
                //series1.ArgumentDataMember = ;
                //series1.ValueScaleType = ScaleType.Numerical;
                //series1.ValueDataMembers.AddRange(new string[] { "Dat", "KhongDat" });
                chart.Titles.Clear();
                chart.Titles.Add(new ChartTitle() { Text = "Tỉ lệ đạt theo " +  Title, DXFont = new DXFont("Time New Roman",11) });

                // Create a pie series.
                Series series1 = new Series("Đạt", ViewType.Pie);

                // Bind the series to data.
                series1.DataSource = dataChart;
                series1.ArgumentDataMember = "Argument";
                series1.ValueDataMembers.AddRange(new string[] { "Value" });

                // Add the series to the chart.
                chart.Series.Add(series1);


                // Format the series legend items.
                series1.LegendTextPattern = "{A}: {V}/ {TV}";
                // Adjust the position of series labels. 
                ((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;
                chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                chart.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
                // Detect overlapping of series labels.
                ((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

                // Access the view-type-specific options of the series.
                PieSeriesView myView = (PieSeriesView)series1.View;

                //// Specify a data filter to explode points.
                //myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                //    DataFilterCondition.GreaterThanOrEqual, 9));
                //myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                //    DataFilterCondition.NotEqual, "Others"));
                myView.ExplodeMode = PieExplodeMode.UseFilters;
                myView.ExplodedDistancePercentage = 30;
                myView.RuntimeExploding = true;

                // Customize the legend.
                chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - getDataSource", ex.ToString());
            }
        }
        private List<CategoricalPoint> GetDataSourceChart(string strIngredient = "", string strFactory = "", string strSpecies = "", string strType = "", string strNguoiKiemThu = "", string strTarget = "", string strClient = "", string strMachine = "",string strALL = "")
        {
            List<CategoricalPoint> dataChart = new List<CategoricalPoint>();
            try
            {
                DateTime frmDate = dateEdit1.DateTime;
                DateTime ToDate = dateEdit1.DateTime;
                if(frmDate.Year < 1900)
                    frmDate = DateTime.Now.AddDays(-30);
                if (ToDate.Year < 1900)
                    ToDate = DateTime.Now;
                if (comboBox2.Text == "Month" && dateEdit1.DateTime.Year > 1900)
                {
                    frmDate = new DateTime(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month, 1);
                    ToDate = frmDate.AddMonths(1).AddDays(-1);

                }
                else if (comboBox2.Text == "Year" && dateEdit1.DateTime.Year > 1900)
                {
                    frmDate = new DateTime(dateEdit1.DateTime.Year, 1, 1);
                    ToDate = frmDate.AddYears(1).AddHours(-10);
                }
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("UserID", currUser.id));
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
                if (!string.IsNullOrEmpty(strALL))
                    parameters.Add(new SqlParameter("All", true));
                
                parameters.Add(new SqlParameter("FromDate", frmDate));
                parameters.Add(new SqlParameter("ToDate", ToDate));
                DataTable result = _db.Fill("stor_GetAllDataStatistical", parameters);
                if(result != null && result.Rows.Count > 0)
                {
                    List<DataStatistical> dataPrepare = _db.ConvertToList<DataStatistical>(result);
                    if (dataPrepare != null && dataPrepare.Count > 0)
                    {
                        foreach (DataStatistical item in dataPrepare)
                        {
                            CategoricalPoint report = new CategoricalPoint();
                            if (item.Title.Contains("Không đạt"))
                            {
                                report.Argument = "Không đạt";
                                report.Value = item.SoLuong;
                            }
                            else
                            {
                                report.Argument = "Đạt";
                                report.Value = item.SoLuong;
                            }
                            dataChart.Add(report);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - GetDataSourceChart", ex.ToString());
            }
            return dataChart;
        }
        private void LoadDataGrid()
        {
            DataTable dataSource = GetDataSource();
            gridControl1.DataSource = dataSource;
            gridView1.Columns[0].Visible = false;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.Rows.Count;
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[4] + string.Empty))
                {
                    switch (gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[4] + string.Empty)
                    {
                        case "Sample":
                            {
                                Sample_Ins_Update page = new Sample_Ins_Update();
                                page.currUser = currUser;
                                page.IDSample = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
                                page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
                                page.ShowDialog();
                                break;
                            }
                        case "Document":
                            {
                                PageSignDoc page = new PageSignDoc();
                                page.currUser = currUser;
                                page.IDDoc = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
                                page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
                                page.ShowDialog();
                                break;
                            }
                        default:
                            {
                                string idDoc = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).ItemArray[1] + string.Empty;
                                if (!string.IsNullOrEmpty(idDoc))
                                {
                                    BeanDocument document = new BeanDocument();
                                    document = document.SelectByID(idDoc);
                                    EditDocumentSample page = new EditDocumentSample();
                                    page.currUser = currUser;
                                    page.IDSample = document.idSample;
                                    page.IDTemplate = document.idTemplate;
                                    page.RequestChanged = true;
                                    page.IDDoc = idDoc;
                                    page.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
                                    page.ShowDialog();
                                }
                               
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                function.TrackingError("DashboardPage - gridView1_RowClick", ex.ToString());
            }
            
            
        }

        private void btnProfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customer_InsUpdPage page = new Customer_InsUpdPage();
            page.currUser = currUser;
            page.idUser = currUser.id + "";
            page.StartPosition = FormStartPosition.CenterScreen;
            page.FormClosed += new FormClosedEventHandler(ReloadUser_FormClosing);
            page.ShowDialog();
        }

        private void btnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPage page = new ReportPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void tab_SettingFactory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FactorySettingPage page = new FactorySettingPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btn_SetIngrediant_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IngrediantSettingPage page = new IngrediantSettingPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btnType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TypeSettingPage page = new TypeSettingPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btnSpecies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SpeciesSettingPage page = new SpeciesSettingPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btnTarget_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TargetSettingPage page = new TargetSettingPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btnRequirement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RequirementSettingPage page = new RequirementSettingPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btnSettingTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AllTemplatePage page = new AllTemplatePage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btnDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AllDocumentPage page = new AllDocumentPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }

        private void btn_ShowClient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClientSettingPage page = new ClientSettingPage();
            page.currUser = currUser;
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog();
        }
        private void Form1_FormClosing(Object sender, FormClosedEventArgs e)
        {
            try
            {
                LoadDataGrid();
                LoadDataChart();
            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - Form1_FormClosing", ex.ToString());
            }
        }
        private void ReloadUser_FormClosing(Object sender, FormClosedEventArgs e)
        {
            try
            {
                BeanCustomer beanCustomer = new BeanCustomer();
                currUser = beanCustomer.SelectByID(currUser.id);
                LoadDataGrid();
                LoadDataChart();
            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - ReloadUser_FormClosing", ex.ToString());
            }
        }
        private void Backup_FormClosing(Object sender, FormClosedEventArgs e)
        {
            try
            {
                string query = "";
                string fileName = "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                BeanUrlSave bean = new BeanUrlSave();
                bean = bean.SelectByID("Backup");
                if (!string.IsNullOrEmpty(bean.urlLink))
                {
                    query = "BACKUP DATABASE " + ConfigurationManager.AppSettings["DatabaseName"] + " TO DISK ='" + "\\" + bean.urlLink + fileName + "';";

                }
                else
                {
                    string urlFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +  "BackupData\\Backup_" + DateTime.Now.ToString("yyyyMMdd") + "\\";
                    string urlBackupDB = Path.GetFullPath(urlFolder) + fileName;
                    if (!Directory.Exists(urlFolder))
                    {
                        Directory.CreateDirectory(urlFolder);
                    }
                }
                _db.ExecuteNonQuery("", query);
                MessageBox.Show("Sao lưu dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy đường dẫn lưu file!");
                function.TrackingError("DashboardPage - Backup_FormClosing", "Không tìm thấy đường dẫn lưu file!");
            }
        }

        private void cb_Factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cb_Factory.SelectedValue + ""))
                {
                    chartFactory.Series.Clear();
                    getDataSource(chartFactory, cb_Factory.SelectedValue + "", "Fac", "nhà máy");
                }

            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - cb_Factory_SelectedIndexChanged", ex.ToString());
            }
        }

        private void cb_Target_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(cb_Target.SelectedValue + ""))
                {
                    chart_Target.Series.Clear();
                    getDataSource(chart_Target, cb_Target.SelectedValue + "", "Tar", "chỉ tiêu");
                }
                
            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - cb_Target_SelectedIndexChanged", ex.ToString());
            }
        }

        private void cb_Ingredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cb_Ingredient.SelectedValue + ""))
                {
                    chart_Ingredient.Series.Clear();
                    getDataSource(chart_Ingredient, cb_Ingredient.SelectedValue + "", "Ing", "nguyên liệu");
                }

            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - cb_Ingredient_SelectedIndexChanged", ex.ToString());
            }
        }

        private void cb_Species_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cb_Species_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cb_Species.SelectedValue + ""))
                {
                    chart_Species.Series.Clear();
                    getDataSource(chart_Species, cb_Species.SelectedValue + "", "Spe", "thành phần");
                }

            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - cb_Species_SelectedIndexChanged", ex.ToString());
            }
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cb_type.SelectedValue + ""))
                {
                    chart_type.Series.Clear();
                    getDataSource(chart_type, cb_type.SelectedValue + "", "Type", "loại kiểm thử");
                }

            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - cb_type_SelectedIndexChanged", ex.ToString());
            }
        }

        private void cb_NguoiKiemThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cb_NguoiKiemThu.SelectedValue + ""))
                {
                    chart_NguoiKiemThu.Series.Clear();
                    getDataSource(chart_NguoiKiemThu, cb_NguoiKiemThu.SelectedValue + "", "NguoiKiemThu", "người kiểm thử");
                }

            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - cb_NguoiKiemThu_SelectedIndexChanged", ex.ToString());
            }
           
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbClient.SelectedValue + ""))
                {
                    chartClient.Series.Clear();
                    getDataSource(chartClient, cbClient.SelectedValue + "", "Client", "khách hàng");
                }

            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - cbClient_SelectedIndexChanged", ex.ToString());
            }
           
        }

        private void btnOpenMachine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MachineSettingPage page = new MachineSettingPage();
            page.currUser = currUser;
            page.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbClient.SelectedValue + ""))
                {
                    chartMachine.Series.Clear();
                    getDataSource(chartMachine, comboBox1.SelectedValue + "", "Machine", "máy sản xuất");
                }

            }
            catch (Exception ex)
            {
                function.TrackingError("DashboardPage - comboBox1_SelectedIndexChanged", ex.ToString());
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = false;
            dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.Default;
            if (comboBox2.SelectedItem + "" == "Month")
            {
                dateEdit1.Properties.Mask.EditMask = "MM/yyyy";
                dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
                dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView;
            }
            else if (comboBox2.SelectedItem + "" == "Year")
            {
                dateEdit1.Properties.Mask.EditMask = "yyyy";
                dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
                dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            }
            LoadDataChart();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataChart();
        }
    }
    public class DataStatistical
    {
        public string Title { get; set; }
        public int SoLuong { get; set; }
    }
    public class DataChartStatistical
    {
        public string Title { get; set; }
        public int Dat { get; set; }
        public int KhongDat { get; set; }
    }
    public class CategoricalPoint
    {
        public string Argument { get; set; }
        public int Value { get; set; } = 0;
    }
}