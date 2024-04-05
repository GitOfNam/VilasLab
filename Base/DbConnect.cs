using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilasLab.Base
{
    public class DbConnect
    {
        protected SqlConnection con;
        protected SqlCommand cmm;
        protected SqlTransaction tran = null;
        public string connect(string key)
        {
            string strConnect = ConfigurationManager.ConnectionStrings[key] + string.Empty;
            return strConnect;
        }
        public DataTable Fill(string StoreName, List<SqlParameter> retParaList = null, string strKeyConString = "")
        {
            DataTable retValue = null;
            try
            {

                Open(strKeyConString);

                cmm.Parameters.Clear();
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.CommandText = StoreName;
                if (retParaList != null)
                {
                    cmm.Parameters.AddRange(retParaList.ToArray());
                }
                SqlDataAdapter dap = new SqlDataAdapter(cmm);
                DataSet ds = new DataSet();
                dap.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    retValue = ds.Tables[0];
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Close();
            }

            return retValue;
        }
        public void Open(string strKeyConString = "")
        {
            if (string.IsNullOrEmpty(strKeyConString)) strKeyConString = ConfigurationManager.AppSettings["DefaultDB"];

            //Luôn luôn là key get ConnectionString, Không phải là chuỗi ConnectionString
            string connection = connect(strKeyConString);

            con = new SqlConnection(connection);

            cmm = new SqlCommand();
            cmm.Connection = con;

            con.Open();
        }
        public int ExecuteNonQuery(string strConnectionString, string strQuery)
        {
            try
            {
                if (string.IsNullOrEmpty(strConnectionString)) strConnectionString = ConfigurationManager.ConnectionStrings["DbBase"] + string.Empty;
                SqlConnection connection = new SqlConnection(strConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public virtual int Execute(string strStoreName, List<SqlParameter> retParaList = null, string strKeyConString = "", bool exeCon = true)
        {
            int retValue = -1;
            string retId = string.Empty;
            try
            {
                if (exeCon)
                {
                    Open(strKeyConString);
                }
                cmm.Parameters.Clear();
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.CommandText = strStoreName;

                if (retParaList != null && retParaList.Count > 0)
                {
                    cmm.Parameters.AddRange(retParaList.ToArray());
                }

                // Nếu có sử dụng transation thì 
                if (!exeCon && tran != null)
                {
                    cmm.Transaction = tran;
                }
                retValue = cmm.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                if (exeCon)
                {
                    Close();
                }
            }

            return retValue;
        }

        public void Close()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
        public List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row => {
                var obj = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            Guid o;
                            bool isValid = Guid.TryParse(row[pro.Name] + "", out o);
                            if (isValid)
                            {
                                pro.SetValue(obj, Guid.Parse(row[pro.Name] + ""));
                            }
                            else
                                pro.SetValue(obj, row[pro.Name]);
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                return obj;
            }).ToList();
        }
    }
}
