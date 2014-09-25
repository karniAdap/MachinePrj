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

        public static DataSet GetCounterDetail(string con, int BranchId, char Option)
        {
            SqlParameter[] prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = BranchId;

            prm[1] = new SqlParameter("@Option", SqlDbType.Char);
            prm[1].Value = Option;

            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sprCounterList", prm);
        }
         
        public static DataSet GetPrmRpt(string con, string SpName, DateTime stTime, DateTime endTime, bool IsExcludedWeekend, string TrnFilter = null, string WaitFilter = null,
         string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            SqlParameter[] prm = new SqlParameter[10];

            prm[0] = new SqlParameter("@StTime", SqlDbType.DateTime);
            prm[0].Value = stTime;
            prm[1] = new SqlParameter("@EndTime", SqlDbType.DateTime);
            prm[1].Value = endTime;
            prm[2] = new SqlParameter("@TrnFilter", SqlDbType.VarChar);
            prm[2].Value = string.IsNullOrEmpty(TrnFilter) == true ? null : TrnFilter;
            prm[3] = new SqlParameter("@WaitFilter", SqlDbType.VarChar);
            prm[3].Value = string.IsNullOrEmpty(WaitFilter) == true ? null : WaitFilter;
            prm[4] = new SqlParameter("@Branchs", SqlDbType.VarChar);
            prm[4].Value = string.IsNullOrEmpty(Branches) == true ? null : Branches;
            prm[5] = new SqlParameter("@Buttons", SqlDbType.VarChar);
            prm[5].Value = string.IsNullOrEmpty(Buttons) == true ? null : Buttons;
            prm[6] = new SqlParameter("@Cats", SqlDbType.VarChar);
            prm[6].Value = string.IsNullOrEmpty(Cats) == true ? null : Cats;
            prm[7] = new SqlParameter("@Counters", SqlDbType.VarChar);
            prm[7].Value = string.IsNullOrEmpty(Counters) == true ? null : Counters;
            prm[8] = new SqlParameter("@Users", SqlDbType.VarChar);
            prm[8].Value = string.IsNullOrEmpty(Users) == true ? null : Users;

            prm[9] = new SqlParameter("@IsExcWeekend", SqlDbType.Bit);
            prm[9].Value = IsExcludedWeekend;
            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, SpName, prm);
        }

        public static DataSet GetTicketPrmRpt(string con, string SpName, DateTime stTime, DateTime endTime, string Branches = null, string Buttons = null, string Cats = null,
          string Counters = null, string Users = null)
        {
            SqlParameter[] prm = new SqlParameter[7];

            prm[0] = new SqlParameter("@StTime", SqlDbType.DateTime);
            prm[0].Value = stTime;
            prm[1] = new SqlParameter("@EndTime", SqlDbType.DateTime);
            prm[1].Value = endTime;
            prm[2] = new SqlParameter("@Branchs", SqlDbType.VarChar);
            prm[2].Value = string.IsNullOrEmpty(Branches) == true ? null : Branches;
            prm[3] = new SqlParameter("@Buttons", SqlDbType.VarChar);
            prm[3].Value = string.IsNullOrEmpty(Buttons) == true ? null : Buttons;
            prm[4] = new SqlParameter("@Cats", SqlDbType.VarChar);
            prm[4].Value = string.IsNullOrEmpty(Cats) == true ? null : Cats;
            prm[5] = new SqlParameter("@Counters", SqlDbType.VarChar);
            prm[5].Value = string.IsNullOrEmpty(Counters) == true ? null : Counters;
            prm[6] = new SqlParameter("@Users", SqlDbType.VarChar);
            prm[6].Value = string.IsNullOrEmpty(Users) == true ? null : Users;

            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, SpName, prm);
        }

        public static DataSet GetProcNoPrm(string con, string SpName)
        {
            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, SpName);
        }

        public static DataSet GetPrmOneRpt(string con, string SpName, DateTime stTime, string Branches)
        {
            SqlParameter[] prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@StTime", SqlDbType.DateTime);
            prm[0].Value = stTime;

            prm[1] = new SqlParameter("@Branchs", SqlDbType.VarChar);
            prm[1].Value = string.IsNullOrEmpty(Branches) == true ? null : Branches;

            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, SpName, prm);
        }

        public static DataSet GetHoursRpt(string con, DateTime stTime, DateTime endTime, bool IsExcludedWeekend, string TrnFilter = null, string WaitFilter = null,
            string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            return GetPrmRpt(con, "sprHour", stTime, endTime, IsExcludedWeekend, TrnFilter, WaitFilter, Branches, Buttons, Cats, Counters, Users);
        }

        public static DataSet GetDayMonthRpt(string con, int ColType, DateTime stTime, DateTime endTime, bool IsExcludedWeekend,
            string TrnFilter = null, string WaitFilter = null, string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            SqlParameter[] prm = new SqlParameter[11];

            prm[0] = new SqlParameter("@StTime", SqlDbType.DateTime);
            prm[0].Value = stTime;
            prm[1] = new SqlParameter("@EndTime", SqlDbType.DateTime);
            prm[1].Value = endTime;
            prm[2] = new SqlParameter("@TrnFilter", SqlDbType.VarChar);
            prm[2].Value = string.IsNullOrEmpty(TrnFilter) == true ? null : TrnFilter;
            prm[3] = new SqlParameter("@WaitFilter", SqlDbType.VarChar);
            prm[3].Value = string.IsNullOrEmpty(WaitFilter) == true ? null : WaitFilter;
            prm[4] = new SqlParameter("@Branchs", SqlDbType.VarChar);
            prm[4].Value = string.IsNullOrEmpty(Branches) == true ? null : Branches;
            prm[5] = new SqlParameter("@Buttons", SqlDbType.VarChar);
            prm[5].Value = string.IsNullOrEmpty(Buttons) == true ? null : Buttons;
            prm[6] = new SqlParameter("@Cats", SqlDbType.VarChar);
            prm[6].Value = string.IsNullOrEmpty(Cats) == true ? null : Cats;
            prm[7] = new SqlParameter("@Counters", SqlDbType.VarChar);
            prm[7].Value = string.IsNullOrEmpty(Counters) == true ? null : Counters;
            prm[8] = new SqlParameter("@Users", SqlDbType.VarChar);
            prm[8].Value = string.IsNullOrEmpty(Users) == true ? null : Users;
            prm[9] = new SqlParameter("@ColType", SqlDbType.Int);
            prm[9].Value = ColType;
            prm[10] = new SqlParameter("@IsExcWeekend", SqlDbType.Bit);
            prm[10].Value = IsExcludedWeekend;

            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sprDays", prm);
        }

        public static DataSet GetDatesRpt(string con, DateTime stTime, DateTime endTime, bool IsExcludedWeekend,
           string TrnFilter = null, string WaitFilter = null, string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            return GetPrmRpt(con, "sprDates", stTime, endTime, IsExcludedWeekend, TrnFilter, WaitFilter, Branches, Buttons, Cats, Counters, Users);
        }

        public static DataSet GetCatsRpt(string con, DateTime stTime, DateTime endTime, bool IsExcludedWeekend,
           string TrnFilter = null, string WaitFilter = null, string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            return GetPrmRpt(con, "sprCats", stTime, endTime, IsExcludedWeekend, TrnFilter, WaitFilter, Branches, Buttons, Cats, Counters, Users);
        }

        public static DataSet GetCounterRpt(string con, DateTime stTime, DateTime endTime, bool IsExcludedWeekend,
          string TrnFilter = null, string WaitFilter = null, string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            return GetPrmRpt(con, "sprCounters", stTime, endTime, IsExcludedWeekend, TrnFilter, WaitFilter, Branches, Buttons, Cats, Counters, Users);
        }

        public static DataSet GetUsersRpt(string con, DateTime stTime, DateTime endTime, bool IsExcludedWeekend,
          string TrnFilter = null, string WaitFilter = null, string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            return GetPrmRpt(con, "sprUsers", stTime, endTime, IsExcludedWeekend, TrnFilter, WaitFilter, Branches, Buttons, Cats, Counters, Users);
        }

        public static DataSet GetBranchesRpt(string con, DateTime stTime, DateTime endTime, bool IsExcludedWeekend,
          string TrnFilter = null, string WaitFilter = null, string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            return GetPrmRpt(con, "sprBranches", stTime, endTime, IsExcludedWeekend, TrnFilter, WaitFilter, Branches, Buttons, Cats, Counters, Users);
        }

        public static DataSet GetMatterCodeRpt(string con, DateTime stTime, DateTime endTime, bool IsExcludedWeekend,
          string TrnFilter = null, string WaitFilter = null, string Branches = null, string Buttons = null, string Cats = null, string Counters = null, string Users = null)
        {
            return GetPrmRpt(con, "sprMatterCode", stTime, endTime, IsExcludedWeekend, TrnFilter, WaitFilter, Branches, Buttons, Cats, Counters, Users);
        }

        public static DataSet GetTicketRpt(string con, DateTime stTime, DateTime endTime, string Branches = null, string Buttons = null, string Cats = null,
            string Counters = null, string Users = null)
        {
            return GetTicketPrmRpt(con, "sprTickets", stTime, endTime, Branches, Buttons, Cats, Counters, Users);
        }
         
        public static DataSet GetCounterPerformanceRpt(string con, DateTime stTime, string Branchs)
        {
            return GetPrmOneRpt(con, "sprCounterPerformance", stTime, Branchs);
        }

        public static DataSet GetUserPerformanceRpt(string con, DateTime stTime, string Branches)
        {
            return GetPrmOneRpt(con, "sprUserPerformance", stTime, Branches);
        }

        public static DataSet GetLoginLogoutRpt(string con, DateTime stTime, string Branches)
        {
            return GetPrmOneRpt(con, "sprLoginLogout", stTime, Branches);
        }
         
        public static string[] UserInsert(string con, int LanguageCultureId, Int16 FRKExternalUserProcessType, string UserName, Int16 UserGroupCode = 0,
            int PriorityCode = 0, char Prioritychange = '0', string RegisterNo = "B", Int16 EmailSend = 0, Int16 SmsSend = 0,int Active=0)
        {
            SqlParameter[] prm = new SqlParameter[18];

            prm[0] = new SqlParameter("@LANGUAGECULTUREID", SqlDbType.Int);
            prm[0].Value = LanguageCultureId;
            prm[1] = new SqlParameter("@MYRESULT", SqlDbType.TinyInt);
            prm[1].Direction = ParameterDirection.Output;
            prm[2] = new SqlParameter("@RID", SqlDbType.BigInt);
            prm[2].Direction = ParameterDirection.Output;
            prm[3] = new SqlParameter("@FKXQEXTERNALUSERPROCESSTYPE", SqlDbType.TinyInt);
            prm[3].Value = FRKExternalUserProcessType;          
            prm[4] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            prm[4].Value = UserName;           
            prm[5] = new SqlParameter("@USERGROUPCODE", SqlDbType.SmallInt);
            prm[5].Value = UserGroupCode;
            prm[6] = new SqlParameter("@PRIORITYCODE", SqlDbType.Int);
            prm[6].Value = PriorityCode;
            prm[7] = new SqlParameter("@PRIORITYCHANGE", SqlDbType.Char);
            prm[7].Value = Prioritychange;
            prm[8] = new SqlParameter("@REGISTERNO", SqlDbType.VarChar, 10);
            prm[8].Value = RegisterNo;
            prm[9] = new SqlParameter("@ACTIVE", SqlDbType.SmallInt);
            prm[9].Value = Active;            
            prm[10] = new SqlParameter("@EMAILSEND", SqlDbType.TinyInt);
            prm[10].Value = EmailSend;
            prm[11] = new SqlParameter("@SMSSEND", SqlDbType.TinyInt);
            prm[11].Value = SmsSend;
         
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "xqSp_ExternalUser_Insert", prm);

            string[] res = new string[2];
            res[0] = Convert.ToString(prm[1].Value);
            res[1] = Convert.ToString(prm[2].Value);
            return res;
        }

        public static string[] BranchUpdate(string con, int LanguageCultureId, Int16 FRKExternalUserProcessType,int BranchCode=0,
        int PriorityCode = 0, string RegisterNo = null)
        {
            SqlParameter[] prm = new SqlParameter[7];

            prm[0] = new SqlParameter("@LANGUAGECULTUREID", SqlDbType.Int);
            prm[0].Value = LanguageCultureId;
            prm[1] = new SqlParameter("@MYRESULT", SqlDbType.TinyInt);
            prm[1].Direction = ParameterDirection.Output;
            prm[2] = new SqlParameter("@RID", SqlDbType.BigInt);
            prm[2].Direction = ParameterDirection.Output;
            prm[3] = new SqlParameter("@FKXQEXTERNALUSERPROCESSTYPE", SqlDbType.TinyInt);
            prm[3].Value = FRKExternalUserProcessType;
            prm[4] = new SqlParameter("@BRANCHCODE", SqlDbType.SmallInt);
            prm[4].Value = BranchCode;
            prm[5] = new SqlParameter("@PRIORITYCODE", SqlDbType.Int);
            prm[5].Value = PriorityCode;
            prm[6] = new SqlParameter("@REGISTERNO", SqlDbType.VarChar, 10);
            prm[6].Value = RegisterNo;
         
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "xqSp_ExternalUser_Insert", prm);

            string[] res = new string[2];
            res[0] = Convert.ToString(prm[1].Value);
            res[1] = Convert.ToString(prm[2].Value);
            return res;
        }
    }
}
