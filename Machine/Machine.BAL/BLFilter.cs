using System.Collections.Generic;

namespace Machine.BAL
{
    public class BLFilter
    {
        public static List<DAL.Filter> GetList(string con, int UserId)
        {
            return Machine.DAL.Filters.GetList(con, UserId);             
        }

        public static Machine.DAL.Filter GetDetail(string con, int Id)
        {
            return Machine.DAL.Filters.GetDetail(con, Id);
        }

        public static int Add(string con, int UserId, string Name, string strTime, string strBranches, string strButtons, string strCategories, string strCounter, string strUsers, string TransactionTime, string WaitingTime, bool IsAverage, bool ISMax, bool IsStaffPlan, bool IsTimeFormat, bool IsExcludeWeekend, bool IsWorkingDay)
        {
            return Machine.DAL.Filters.Add(con, UserId, Name, strTime, strBranches, strButtons, strCategories, strCounter, strUsers, TransactionTime, WaitingTime, IsAverage, ISMax, IsStaffPlan, IsTimeFormat, IsExcludeWeekend, IsWorkingDay, "");
        }

        public static int Add(string con, int UserId, string Name, string strTime, string strBranches, string strButtons, string strCategories, string strCounter, string strUsers, string TransactionTime, string WaitingTime, bool IsAverage, bool ISMax, bool IsStaffPlan, bool IsTimeFormat, bool IsExcludeWeekend, bool IsWorkingDay, string ReportType)
        {
            return Machine.DAL.Filters.Add(con, UserId, Name, strTime, strBranches, strButtons, strCategories, strCounter, strUsers, TransactionTime, WaitingTime, IsAverage, ISMax, IsStaffPlan, IsTimeFormat, IsExcludeWeekend, IsWorkingDay, ReportType);
        }

        public static int Delete(string con, int Id)
        {
            return Machine.DAL.Filters.Delete(con, Id);
        }
    }
}
