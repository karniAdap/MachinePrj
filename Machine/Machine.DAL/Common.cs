using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Machine.DAL
{
    public class Common
    {
        public static string con = @"Data Source=ADMIN-PC\Latest;Initial Catalog=DbMachine;Persist Security Info=True;User ID=sa;Password=sql";

        public static DataSet ExtDataset(string Con, string query)
        {
            return SqlHelper.ExecuteDataset(Con, CommandType.Text, query);
        }

        public static object ExtScaler(string Con, string query)
        {
            return SqlHelper.ExecuteScalar(Con, CommandType.Text, query);
        }

        public static int ExtNonQuery(string Con, string query)
        {
            return SqlHelper.ExecuteNonQuery(Con, CommandType.Text, query);
        }

        public static DataSet ExtProc(string con, string SpName)
        {
            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, SpName);
        }

        public static DataSet ExtProc(string con, string SpName, int Id)
        {
            SqlParameter[] prm = new SqlParameter[1];

            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = Id;

            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, SpName, prm);
        }

        
      
        public static DataSet GetProcNoPrm(string con, string SpName)
        {
            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, SpName);
        }

       
    }
}
