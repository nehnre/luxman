using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace Nehnre.DataAccess.Common
{
    
    public class DbAccess
    {
        public DataSet query(string strsql)
        {
            string strCon = ConfigurationSettings.AppSettings["connectionString"];
            SqlConnection myConn = new SqlConnection(strCon);
            if (myConn.State.Equals(ConnectionState.Closed))
            {
                myConn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(strsql, strCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConn.Close();
            return ds;
        }
        public int update(string strsql)
        {
            string strCon = ConfigurationSettings.AppSettings["connectionString"];
            SqlConnection myConn = new SqlConnection(strCon);
            if (myConn.State.Equals(ConnectionState.Closed))
            {
                myConn.Open();
            }
            SqlCommand sc = new SqlCommand(strsql, myConn);
            int n =  sc.ExecuteNonQuery();
            myConn.Close();
            return n;
        }

        public static DataSet executeQuery(string strsql)
        {
            return new DbAccess().query(strsql);
        }

        public static int executeUpdate(string strsql)
        {
            return new DbAccess().update(strsql);
        }
        public static string parse(string value)
        {
            if (value == null)
                return value;
            string ret = "";
            ret = "'" + value.Replace("'", "''") + "'";
            return ret;
        }
    }
}
