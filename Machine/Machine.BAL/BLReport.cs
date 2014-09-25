using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.BAL
{
    public class BLReport
    {
        public static List<DAL.uReport> GetList(string con, string str = null)
        {
            return Machine.DAL.uReports.GetList(con, str, true);
        }

        public static object GetAllList(string con, string str = null, bool IsActive = false, bool IsParent = false)
        {
            return Machine.DAL.uReports.GetList(con, str, IsActive, IsParent);
        }

        public static Machine.DAL.uReport GetDetail(string con, int Id)
        {
            return Machine.DAL.uReports.GetDetail(con, Id);
        }

        public static int Edit(string con, int Id, string Name, string Desc, string PageUrl, bool IsParent, int Parent, bool IsActive = true)
        {
            return Machine.DAL.uReports.Edit(con, Id, Name, Desc, PageUrl, IsParent, Parent, IsActive);
        }

        public static int Delete(string con, int Id)
        {
            return Machine.DAL.uReports.Delete(con, Id);
        }

        public static bool CheckExist(string con, string Name, int Id)
        {
            return Machine.DAL.uReports.CheckExist(con, Name, Id);
        }
    }
}
