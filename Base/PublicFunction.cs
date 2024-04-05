using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using VilasLab.Models;
using excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.Data;

namespace VilasLab.Base
{
    public class PublicFunction
    {
        private DbConnect _db = new DbConnect();
        #region function
        public string ConvertTVKhongDauVietLien(string str)
        {
            string[] a = { "à", "á", "ạ", "ả", "ã", "â", "ầ", "ấ", "ậ", "ẩ", "ẫ", "ă", "ằ", "ắ", "ặ", "ẳ", "ẵ" };
            string[] aUpper = { "À", "Á", "Ạ", "Ả", "Ã", "Â", "Ầ", "Ấ", "Ậ", "Ẩ", "Ẫ", "Ă", "Ằ", "Ắ", "Ặ", "Ẳ", "Ẵ" };
            string[] e = { "è", "é", "ẹ", "ẻ", "ẽ", "ê", "ề", "ế", "ệ", "ể", "ễ" };
            string[] eUpper = { "È", "É", "Ẹ", "Ẻ", "Ẽ", "Ê", "Ề", "Ế", "Ệ", "Ể", "Ễ" };
            string[] i = { "ì", "í", "ị", "ỉ", "ĩ" };
            string[] iUpper = { "Ì", "Í", "Ị", "Ỉ", "Ĩ" };
            string[] o = { "ò", "ó", "ọ", "ỏ", "õ", "ô", "ồ", "ố", "ộ", "ổ", "ỗ", "ơ", "ờ", "ớ", "ợ", "ở", "ỡ" };
            string[] oUpper = { "Ò", "Ó", "Ọ", "Ỏ", "Õ", "Ô", "Ồ", "Ố", "Ộ", "Ổ", "Ỗ", "Ơ", "Ờ", "Ớ", "Ợ", "Ở", "Ỡ" };
            string[] u = { "ù", "ú", "ụ", "ủ", "ũ", "ư", "ừ", "ứ", "ự", "ử", "ữ" };
            string[] uUpper = { "Ù", "Ú", "Ụ", "Ủ", "Ũ", "Ư", "Ừ", "Ứ", "Ự", "Ử", "Ữ" };
            string[] y = { "ỳ", "ý", "ỵ", "ỷ", "ỹ" };
            string[] yUpper = { "Ỳ", "Ý", "Ỵ", "Ỷ", "Ỹ" };
            str = str.Replace("đ", "d");
            str = str.Replace("Đ", "D");
            foreach (string a1 in a)
            {
                str = str.Replace(a1, "a");
            }
            foreach (string a1 in aUpper)
            {
                str = str.Replace(a1, "A");
            }
            foreach (string e1 in e)
            {
                str = str.Replace(e1, "e");
            }
            foreach (string e1 in eUpper)
            {
                str = str.Replace(e1, "E");
            }
            foreach (string i1 in i)
            {
                str = str.Replace(i1, "i");
            }
            foreach (string i1 in iUpper)
            {
                str = str.Replace(i1, "I");
            }
            foreach (string o1 in o)
            {
                str = str.Replace(o1, "o");
            }
            foreach (string o1 in oUpper)
            {
                str = str.Replace(o1, "O");
            }
            foreach (string u1 in u)
            {
                str = str.Replace(u1, "u");
            }
            foreach (string u1 in uUpper)
            {
                str = str.Replace(u1, "U");
            }
            foreach (string y1 in y)
            {
                str = str.Replace(y1, "y");
            }
            foreach (string y1 in yUpper)
            {
                str = str.Replace(y1, "Y");
            }
            return str.Replace(" ", "");
        }
        public string ConvertTVKhongDau(string str)
        {
            string[] a = { "à", "á", "ạ", "ả", "ã", "â", "ầ", "ấ", "ậ", "ẩ", "ẫ", "ă", "ằ", "ắ", "ặ", "ẳ", "ẵ" };
            string[] aUpper = { "À", "Á", "Ạ", "Ả", "Ã", "Â", "Ầ", "Ấ", "Ậ", "Ẩ", "Ẫ", "Ă", "Ằ", "Ắ", "Ặ", "Ẳ", "Ẵ" };
            string[] e = { "è", "é", "ẹ", "ẻ", "ẽ", "ê", "ề", "ế", "ệ", "ể", "ễ" };
            string[] eUpper = { "È", "É", "Ẹ", "Ẻ", "Ẽ", "Ê", "Ề", "Ế", "Ệ", "Ể", "Ễ" };
            string[] i = { "ì", "í", "ị", "ỉ", "ĩ" };
            string[] iUpper = { "Ì", "Í", "Ị", "Ỉ", "Ĩ" };
            string[] o = { "ò", "ó", "ọ", "ỏ", "õ", "ô", "ồ", "ố", "ộ", "ổ", "ỗ", "ơ", "ờ", "ớ", "ợ", "ở", "ỡ" };
            string[] oUpper = { "Ò", "Ó", "Ọ", "Ỏ", "Õ", "Ô", "Ồ", "Ố", "Ộ", "Ổ", "Ỗ", "Ơ", "Ờ", "Ớ", "Ợ", "Ở", "Ỡ" };
            string[] u = { "ù", "ú", "ụ", "ủ", "ũ", "ư", "ừ", "ứ", "ự", "ử", "ữ" };
            string[] uUpper = { "Ù", "Ú", "Ụ", "Ủ", "Ũ", "Ư", "Ừ", "Ứ", "Ự", "Ử", "Ữ" };
            string[] y = { "ỳ", "ý", "ỵ", "ỷ", "ỹ" };
            string[] yUpper = { "Ỳ", "Ý", "Ỵ", "Ỷ", "Ỹ" };
            str = str.Replace("đ", "d");
            str = str.Replace("Đ", "D");
            foreach (string a1 in a)
            {
                str = str.Replace(a1, "a");
            }
            foreach (string a1 in aUpper)
            {
                str = str.Replace(a1, "A");
            }
            foreach (string e1 in e)
            {
                str = str.Replace(e1, "e");
            }
            foreach (string e1 in eUpper)
            {
                str = str.Replace(e1, "E");
            }
            foreach (string i1 in i)
            {
                str = str.Replace(i1, "i");
            }
            foreach (string i1 in iUpper)
            {
                str = str.Replace(i1, "I");
            }
            foreach (string o1 in o)
            {
                str = str.Replace(o1, "o");
            }
            foreach (string o1 in oUpper)
            {
                str = str.Replace(o1, "O");
            }
            foreach (string u1 in u)
            {
                str = str.Replace(u1, "u");
            }
            foreach (string u1 in uUpper)
            {
                str = str.Replace(u1, "U");
            }
            foreach (string y1 in y)
            {
                str = str.Replace(y1, "y");
            }
            foreach (string y1 in yUpper)
            {
                str = str.Replace(y1, "Y");
            }
            return str;
        }
        #endregion
        #region Encrypt/DeEncryptcrypt
        string key = ConfigurationManager.AppSettings["KeyCrypt"];
        public string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        #endregion
        public string exportExcelResult(string urlSave,DataTable lstSample){
            string fullUrl = "";
            try
            {
                string urlFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\ExcelTemp.xlsx";
                var excelApp = new excel.Application();
                Workbook workbook = excelApp.Workbooks.Open(urlFolder, ReadOnly: false, Editable: true);
                Worksheet worksheet = workbook.Worksheets.Item[1] as Worksheet;
                if (worksheet == null)
                    return "";
                worksheet.Cells[4, 5] = "Tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
               // worksheet.Cells[5, 1] = "Chỉ tiêu thử nghiệm: " + beanTar.SelectByID(bean.idTarget).name;
                DataTable lstResult = new DataTable();
                if (lstSample != null && lstSample.Rows.Count > 0)
                {
                    int sttRow = 0;
                    int countRow = 8;
                    foreach (DataRow rowitemData in lstSample.Rows)
                    {
                        lstResult = GetDataSource(rowitemData[1] + "");
                        if (lstResult != null && lstResult.Rows.Count > 0)
                        {
                            for (int row = countRow; row < countRow + lstResult.Rows.Count; row++)
                            {
                                int sttRowColumn = 0;
                                DataRow rowData = lstResult.Rows[sttRowColumn];
                                worksheet.Cells[row, 1] = sttRow + 1;
                                if (!string.IsNullOrEmpty(rowData["startDate"] + string.Empty))
                                    worksheet.Cells[row, 2] = Convert.ToDateTime(rowData["startDate"] + string.Empty).ToString("dd-MM-yy");
                                if (!string.IsNullOrEmpty(rowData["testDate"] + string.Empty))
                                    worksheet.Cells[row, 3] = Convert.ToDateTime(rowData["testDate"] + string.Empty).ToString("dd-MM-yy");
                                worksheet.Cells[row, 4] = rowData["SampleName"] + string.Empty;
                                worksheet.Cells[row, 5] = rowData["KhachHang"] + string.Empty;
                                worksheet.Cells[row, 6] = rowData["Standard"] + string.Empty;
                                worksheet.Cells[row, 7] = rowData["actualResult"] + string.Empty;
                                worksheet.Cells[row, 8] = rowData["conclusion"] + string.Empty;
                                worksheet.Cells[row, 9] = rowData["descript"] + string.Empty;
                                worksheet.Cells[row, 10] = rowData["fullName"] + string.Empty;
                                sttRow++;
                                sttRowColumn++;
                            }
                            countRow += lstResult.Rows.Count;
                        }
                    }
                }
                //BeanSample bean = new BeanSample();
                //BeanTargetTest beanTar = new BeanTargetTest();
                //bean = bean.SelectByID(idSample);
                //if(bean != null)
                //{
                //    if(lstResult != null && lstResult.Rows.Count > 0)
                //    {
                //        int sttRow = 0;
                //        for (int row = 8; row < 8 + lstResult.Rows.Count; row++)
                //        {

                //            DataRow rowData = lstResult.Rows[sttRow];
                //            worksheet.Cells[row, 1] = sttRow + 1;
                //            if(!string.IsNullOrEmpty(rowData["startDate"] + string.Empty))
                //                worksheet.Cells[row, 2] = Convert.ToDateTime(rowData["startDate"] + string.Empty).ToString("dd-MM-yy");
                //            if (!string.IsNullOrEmpty(rowData["testDate"] + string.Empty))
                //                worksheet.Cells[row, 3] = Convert.ToDateTime(rowData["testDate"] + string.Empty).ToString("dd-MM-yy");
                //            worksheet.Cells[row, 4] = rowData["SampleName"] + string.Empty;
                //            worksheet.Cells[row, 5] = rowData["KhachHang"] + string.Empty;
                //            worksheet.Cells[row, 6] = rowData["Standard"] + string.Empty;
                //            worksheet.Cells[row, 7] = rowData["actualResult"] + string.Empty;
                //            worksheet.Cells[row, 8] = rowData["conclusion"] + string.Empty;
                //            worksheet.Cells[row, 10] = rowData["fullName"] + string.Empty;
                //            sttRow++;
                //        }
                //    }
                //}
                fullUrl = urlSave + "ExcelResult_" + DateTime.Now.ToString("ddMMyymmHH") + ".xlsx";
                try
                {
                    workbook.SaveAs(fullUrl);
                }
                catch
                {
                    workbook.SaveAs(fullUrl);
                }
                object misValue = System.Reflection.Missing.Value;
                workbook.Close(true, misValue, misValue);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                TrackingError("exportExcelResult", ex.ToString());
            }
            return fullUrl;
        }
        public DataTable GetDataSource(string idDoc)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("ID", idDoc));
            DataTable result = _db.Fill("GetDataResultExportExcel", parameters);
            return result;
        }
        public void TrackingError(string Title,string TrackMess)
        {
            BeanTrackingError trackingError = new BeanTrackingError();
            trackingError.Title = Title;
            trackingError.TrackLog = TrackMess;
            trackingError.Created = DateTime.Now;
            trackingError.Insert(trackingError);
        }
        public void exportDataReport(string urlSave, DataTable dt)
        {
            try
            {
                var excel = new excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                Workbook workbook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Báo cáo";

                // loop through each row and add values to our sheet
                int rowcount = 1;

                foreach (DataRow datarow in dt.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= dt.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 2)
                        {
                            worksheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        }
                        // Filling the excel file 
                        worksheet.Cells[rowcount, i] = datarow[i - 1].ToString();
                    }
                }
                try
                {
                    workbook.SaveAs(urlSave + "ExcelReport_" + DateTime.Now.ToString("ddMMyymmHH") + ".xlsx");
                }
                catch
                {
                    workbook.SaveAs(urlSave + "\\ExcelReport_" + DateTime.Now.ToString("ddMMyymmHH") + ".xlsx");
                }

                workbook.Close();
                excel.Quit();
            }
            catch (Exception ex)
            {

            }
        }
        private void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }
    }
}