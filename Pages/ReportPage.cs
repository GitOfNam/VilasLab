using DevExpress.XtraCharts;
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
    public partial class ReportPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DbConnect _db = new DbConnect();
        private PublicFunction function = new PublicFunction();
        public BeanCustomer currUser { get; set; }
        private DataTable dataExport = new DataTable();
        public ReportPage()
        {
            InitializeComponent();
        }
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            checkValid("frm");
        }

        private void ReportPage_Load(object sender, EventArgs e)
        {
            cb_Type.SelectedItem = "Day";
            dateEdit2.DateTime = DateTime.Now.AddDays(15);
            dateEdit1.DateTime = DateTime.Now.AddDays(-15);
            getDataGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateEdit1.Properties.ShowWeekNumbers = false;
            dateEdit2.Properties.ShowWeekNumbers = false;
            dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = false;
            dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = false;
            dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.Default;
            dateEdit2.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.Default;
            if (cb_Type.SelectedItem + "" == "Day")
            {
                dateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
                dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;

                dateEdit2.Properties.Mask.EditMask = "dd/MM/yyyy";
                dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            else if (cb_Type.SelectedItem + "" == "Week")
            {
                dateEdit1.Properties.ShowWeekNumbers = true;
                dateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
                dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
               

                dateEdit2.Properties.ShowWeekNumbers = true;
                dateEdit2.Properties.Mask.EditMask = "dd/MM/yyyy";
                dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
               
            }
            else if (cb_Type.SelectedItem + "" == "Month")
            {
                dateEdit1.Properties.Mask.EditMask = "MM/yyyy";
                dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
                dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView;

                dateEdit2.Properties.Mask.EditMask = "MM/yyyy";
                dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
                dateEdit2.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView;
            }
            else if (cb_Type.SelectedItem + "" == "Year")
            {
                dateEdit1.Properties.Mask.EditMask = "yyyy";
                dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
                dateEdit1.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;

                dateEdit2.Properties.Mask.EditMask = "yyyy";
                dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
                dateEdit2.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            }
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            getDataGrid();
        }
        private void getDataGrid()
        {
            try
            {
                DateTime toDate = dateEdit2.DateTime;
                DateTime frmDate = dateEdit1.DateTime;
                int frmDateInt = 0;
                int toDateInt = 0;
                frmDateInt = Convert.ToInt32(frmDate.ToString("yyyyMMdd"));
                toDateInt = Convert.ToInt32(toDate.ToString("yyyyMMdd"));
                if (cb_Type.Text == "Month")
                {
                    frmDate = new DateTime(dateEdit1.DateTime.Year, dateEdit1.DateTime.Month, 1);
                    int dateend = frmDate.AddMonths(1).AddDays(-1).Day;
                    toDate = new DateTime(dateEdit2.DateTime.Year, dateEdit2.DateTime.Month, dateend);
                    frmDateInt = Convert.ToInt32(frmDate.ToString("yyyyMMdd"));
                    toDateInt = Convert.ToInt32(toDate.ToString("yyyyMMdd"));
                }
                else if (cb_Type.Text == "Year")
                {
                    frmDate = new DateTime(dateEdit1.DateTime.Year, 1, 1);
                    toDate = new DateTime(dateEdit2.DateTime.Year, 12, 31);
                    frmDateInt = Convert.ToInt32(frmDate.ToString("yyyyMMdd"));
                    toDateInt = Convert.ToInt32(toDate.ToString("yyyyMMdd"));
                }
                DataTable dataSource = GetDataDS(frmDate, toDate);
                dataExport = dataSource;
                gridControl2.DataSource = dataSource;
                List<DataReport> Data = GetDataSource(frmDateInt, toDateInt, cb_Type.Text);
                gridControl1.DataSource = Data;
                gridView1.Columns[0].ColumnEditName = "Thời gian";
                gridView1.Columns[1].ColumnEditName = "Tất cả";
                gridView1.Columns[2].ColumnEditName = "Đang thực hiện";
                gridView1.Columns[3].ColumnEditName = "Hoàn tất đúng hạn";
                gridView1.Columns[4].ColumnEditName = "Hoàn tất trễ hạn";
            }
            catch (Exception ex)
            {
                function.TrackingError("ReportPage - getDataGrid", ex.ToString());
            }

        }
        public List<DataReport> GetDataSource(int from, int to,string Type)
        {
            List<DataReport> dataReport = new List<DataReport>();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("DateFrom", from));
                parameters.Add(new SqlParameter("DateTo", to));
                parameters.Add(new SqlParameter("Type", Type));
                parameters.Add(new SqlParameter("UserID", currUser.id));
                DataTable result = _db.Fill("GetDataCountReport", parameters);
                List<DataPrepare> dataPrepare = _db.ConvertToList<DataPrepare>(result);
                if (dataPrepare != null && dataPrepare.Count > 0)
                {
                    string itemPrevi = "";
                    foreach (DataPrepare item in dataPrepare)
                    {
                        if (itemPrevi != item.Title)
                        {
                            itemPrevi = item.Title;
                            DataReport report = new DataReport(); ;
                            report.Title = item.Title;
                            List<DataPrepare> datainTile = dataPrepare.Where(s => s.Title == item.Title).ToList();
                            foreach (DataPrepare itemChild in datainTile)
                            {
                                if (itemChild.Type == "tong")
                                    report.Total = itemChild.SoLuong;
                                else if (itemChild.Type == "Completed")
                                    report.Completed = itemChild.SoLuong;
                                else if (itemChild.Type == "Inprocess")
                                    report.Inprocess = itemChild.SoLuong;
                                else if (itemChild.Type == "OverDue")
                                    report.CompletedOverDue = itemChild.SoLuong;
                            }
                            dataReport.Add(report);

                        }
                    }
                }
                chartControl1.Series.Clear();
                Series series1 = new Series("Tất cả", ViewType.Bar);
                chartControl1.Series.Add(series1);
                series1.DataSource = dataReport;
                series1.ArgumentScaleType = ScaleType.Auto;
                series1.ArgumentDataMember = "Title";
                series1.ValueScaleType = ScaleType.Numerical;
                series1.ValueDataMembers.AddRange(new string[] { "Total" });
                Series series3 = new Series("Đang thực hiện", ViewType.Bar);
                chartControl1.Series.Add(series3);
                series3.DataSource = dataReport;
                series3.ArgumentScaleType = ScaleType.Auto;
                series3.ArgumentDataMember = "Title";
                series3.ValueScaleType = ScaleType.Numerical;
                series3.ValueDataMembers.AddRange(new string[] { "Inprocess" });
                Series series2 = new Series("Hoàn tất đúng hạn", ViewType.Bar);
                chartControl1.Series.Add(series2);
                series2.DataSource = dataReport;
                series2.ArgumentScaleType = ScaleType.Auto;
                series2.ArgumentDataMember = "Title";
                series2.ValueScaleType = ScaleType.Numerical;
                series2.ValueDataMembers.AddRange(new string[] { "Completed" });

                Series series5 = new Series("Hoàn tất trễ hạn", ViewType.Bar);
                chartControl1.Series.Add(series5);
                series5.DataSource = dataReport;
                series5.ArgumentScaleType = ScaleType.Auto;
                series5.ArgumentDataMember = "Title";
                series5.ValueScaleType = ScaleType.Numerical;
                series5.ValueDataMembers.AddRange(new string[] { "CompletedOverDue" });
               
            }
            catch (Exception ex)
            {
                function.TrackingError("ReportPage - GetDataSource", ex.ToString());
            }
            return dataReport;
        }
        private DataTable GetDataDS(DateTime from, DateTime to)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("DateFrom", from));
            parameters.Add(new SqlParameter("DateTo", to));
            parameters.Add(new SqlParameter("UserID", currUser.id));
            DataTable result = _db.Fill("GetDataSampleReport", parameters);
            return result;
        }
        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            checkValid("To");
        }
        private void checkValid(string control)
        {
            try
            {
                DateTime toDate = dateEdit2.DateTime;
                DateTime frmDate = dateEdit1.DateTime;
                if (toDate < frmDate)
                {
                    if (control == "frm")
                        dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-7);
                    else
                        dateEdit2.DateTime = dateEdit1.DateTime.AddDays(1);
                    MessageBox.Show("Từ ngày không thể lớn hơn Đến ngày", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                function.TrackingError("ReportPage - checkValid", ex.ToString());
            }
        }

        private void btnExportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dataExport != null && dataExport.Rows.Count > 0)
            {
                UrlPageSave page = new UrlPageSave();
                page.strTitle = "ExcelReport";
                page.StartPosition = FormStartPosition.CenterScreen;
                page.FormClosed += new FormClosedEventHandler(ExportData);
                page.ShowDialog();
            }        
        }
        private void ExportData(Object sender, FormClosedEventArgs e)
        {
            try
            {
                BeanUrlSave bean = new BeanUrlSave();
                bean = bean.SelectByID("ExcelReport");
                if (!string.IsNullOrEmpty(bean.urlLink))
                {
                    function.exportDataReport(bean.urlLink, dataExport);
                    MessageBox.Show("Thành công!");
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn đường dẫn lưu file!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy đường dẫn lưu file!");
                function.TrackingError("ReportPage - ExportData", "Không tìm thấy đường dẫn lưu file!");
            }
           
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
    public class DataPrepare
    {
        public string Title { get; set; }
        public int SoLuong { get; set; }
        public string Type { get; set; }
    }
    public class DataReport
    {
        public string Title { get; set; }
        public int Total { get; set; } = 0;
        public int Inprocess { get; set; } = 0;
        public int Completed { get; set; } = 0;
        public int CompletedOverDue { get; set; } = 0;
    }
}
