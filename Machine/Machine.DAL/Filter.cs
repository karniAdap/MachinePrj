using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.DAL
{
    public class Filters
    {
        public static List<Filter> GetList(string con, int UserId)
        {
            //if (str != null && str != "")
            //    str = "%" + str.Replace(" ", "%") + "%";

            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@UserId", SqlDbType.Int);
            prm[0].Value = UserId;

            var ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspFilterList", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new Filter
                {
                    Id = r.Field<int>("Id"),
                    UserId = r.Field<int>("Userid"),
                    Name = r.Field<string>("Name"),
                    ReportType = r.Field<string>("ReportType"),
                    StrTime = r.Field<string>("strTime"),
                    StrBranches = r.Field<string>("strBranches"),
                    StrButtons = r.Field<string>("strButtons"),
                    StrCategories = r.Field<string>("strCategories"),
                    StrCounter = r.Field<string>("strCounter"),
                    StrUsers = r.Field<string>("strUsers"),
                    TransactionTime = r.Field<string>("TransactionTime"),
                    WaitingTime = r.Field<string>("WaitingTime"),
                    IsAverage = r.Field<bool>("IsAverage"),
                    ISMax = r.Field<bool>("ISMax"),
                 //   IsStaffPlan = r.Field<bool>("IsStaffPlan"),
                    IsTimeFormat = r.Field<bool>("IsTimeFormat"),
                    IsExcludeWeekend = r.Field<bool>("IsExcludeWeekend"),
                    IsWorkingDay = r.Field<bool>("IsWorkingDay"),
                    CreateDate = r.Field<DateTime>("CreateDate")
                }).ToList();
                return lst;
            }
            return null;
        }

        public static Machine.DAL.Filter GetDetail(string con, int Id)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = Id;

            var ds = SqlHelper.ExecuteDataset(con, "uspFilterDetail", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new Filter
                {
                    Id = r.Field<int>("Id"),
                    UserId = r.Field<int>("Userid"),
                    Name = r.Field<string>("Name"),
                    ReportType= r.Field<string>("ReportType"),
                    StrTime = r.Field<string>("strTime"),
                    StrBranches = r.Field<string>("strBranches"),
                    StrButtons = r.Field<string>("strButtons"),
                    StrCategories = r.Field<string>("strCategories"),
                    StrCounter = r.Field<string>("strCounter"),
                    StrUsers = r.Field<string>("strUsers"),
                    TransactionTime = r.Field<string>("TransactionTime"),
                    WaitingTime = r.Field<string>("WaitingTime"),
                    IsAverage = r.Field<bool>("IsAverage"),
                    ISMax = r.Field<bool>("ISMax"),
                    //IsStaffPlan = r.Field<bool>("IsStaffPlan"),
                    IsTimeFormat = r.Field<bool>("IsTimeFormat"),
                    IsExcludeWeekend = r.Field<bool>("IsExcludeWeekend"),
                    IsWorkingDay = r.Field<bool>("IsWorkingDay"),
                    CreateDate = r.Field<DateTime>("CreateDate")
                }).FirstOrDefault();
                return lst;
            }
            return null;
        }

        public static int Delete(string con, int Id)
        {
            try
            {
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", SqlDbType.Int);
                prm[0].Value = Id;

                return SqlHelper.ExecuteNonQuery(con, "uspFilterDelete", prm);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int Add(string con, int UserId, string Name, string strTime, string strBranches, string strButtons, string strCategories, string strCounter, string strUsers, string TransactionTime, string WaitingTime, bool IsAverage, bool ISMax, bool IsStaffPlan, bool IsTimeFormat, bool IsExcludeWeekend, bool IsWorkingDay,string ReportType)
        {
            SqlParameter[] prm = new SqlParameter[17];
            prm[0] = new SqlParameter("@Userid", SqlDbType.Int);
            prm[0].Value = UserId;

            prm[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            prm[1].Value = Name;

            prm[2] = new SqlParameter("@strTime", SqlDbType.NVarChar);
            prm[2].Value = strTime;

            prm[3] = new SqlParameter("@strBranches", SqlDbType.NVarChar);
            prm[3].Value = strBranches;

            prm[4] = new SqlParameter("@strButtons", SqlDbType.NVarChar);
            prm[4].Value = strButtons;

            prm[5] = new SqlParameter("@strCategories", SqlDbType.NVarChar);
            prm[5].Value = strCategories;

            prm[6] = new SqlParameter("@strCounter", SqlDbType.NVarChar);
            prm[6].Value = strCounter;

            prm[7] = new SqlParameter("@strUsers", SqlDbType.NVarChar);
            prm[7].Value = strUsers;

            prm[8] = new SqlParameter("@TransactionTime", SqlDbType.NVarChar);
            prm[8].Value = TransactionTime;

            prm[9] = new SqlParameter("@WaitingTime", SqlDbType.NVarChar);
            prm[9].Value = WaitingTime;

            prm[10] = new SqlParameter("@IsAverage", SqlDbType.Bit);
            prm[10].Value = IsAverage;

            prm[11] = new SqlParameter("@ISMax", SqlDbType.Bit);
            prm[11].Value = ISMax;

            prm[12] = new SqlParameter("@IsStaffPlan", SqlDbType.Bit);
            prm[12].Value = IsStaffPlan;

            prm[13] = new SqlParameter("@IsTimeFormat", SqlDbType.Bit);
            prm[13].Value = IsTimeFormat;

            prm[14] = new SqlParameter("@IsExcludeWeekend", SqlDbType.Bit);
            prm[14].Value = IsExcludeWeekend;

            prm[15] = new SqlParameter("@IsWorkingDay", SqlDbType.Bit);
            prm[15].Value = IsWorkingDay;

            prm[16] = new SqlParameter("@ReportType", SqlDbType.NVarChar);
            prm[16].Value = ReportType;

            return SqlHelper.ExecuteNonQuery(con, "uspFilterAdd", prm);
        }

    }
    public class Filter
    {
        public Filter()
        { }
        public Filter(int id, int userid, string name, string reporttype, string strtime, string strbranches, string strbuttons, string strcategories, string strcounter, string strusers, string transactiontime, string waitingtime, bool isaverage, bool ismax, bool istimeformat, bool isexcludeweekend, bool isworkingday, DateTime createdate)
        {
            this.Id = id;
            this.UserId = userid;
            this.Name = name;
            this.ReportType = reporttype;
            this.StrTime = strtime;
            this.StrBranches = strbranches;
            this.StrButtons = strbuttons;
            this.StrCategories = strcategories;
            this.StrCounter = strcounter;
            this.StrUsers = strusers;
            this.TransactionTime = transactiontime;
            this.WaitingTime = waitingtime;
            this.IsAverage = isaverage;
            this.ISMax = ismax;
            //this.IsStaffPlan = isstaffplan;
            this.IsTimeFormat = istimeformat;
            this.IsExcludeWeekend = isexcludeweekend;
            this.IsWorkingDay = isworkingday;
            this.CreateDate = createdate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ReportType { get; set; }
        public string StrTime { get; set; }
        public string StrBranches { get; set; }
        public string StrButtons { get; set; }
        public string StrCategories { get; set; }
        public string StrCounter { get; set; }
        public string StrUsers { get; set; }
        public string TransactionTime { get; set; }
        public string WaitingTime { get; set; }
        public bool IsAverage { get; set; }
        public bool ISMax { get; set; }
        
        public bool IsTimeFormat { get; set; }
        public bool IsExcludeWeekend { get; set; }
        public bool IsWorkingDay { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
