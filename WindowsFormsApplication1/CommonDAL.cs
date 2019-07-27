using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public class CommonDAL
    {
        public string connectionString = System.Configuration.ConfigurationSettings.AppSettings["strConnect"];

        public DataTable GetDataTable(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            try
            {
                con.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = con;
                sqlCom.CommandText = sql;
                sqlCom.CommandType = CommandType.Text;
                DataTable dtb = new DataTable();
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCom);
                sqlDA.Fill(dtb);
                con.Close();
                return dtb;
            }
            catch (Exception ex) { con.Close(); throw ex; }
        }

        public void ExecCommand(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            try
            {

                con.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.CommandText = sql;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Connection = con;
                sqlCom.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { con.Close(); throw ex; }
        }

        public void exeStore(string storeName, string[] paramNames, Object[] parameters)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            try
            {
                if (paramNames.Length != parameters.Length)
                {
                    return;
                }
                con.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                int index = 0;
                foreach (string paramName in paramNames)
                {
                    com.Parameters.AddWithValue(paramName, parameters[index++]);
                }
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = storeName;
                com.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex) { }
        }

    }
}
