using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Machine.DAL
{
    public class uReports
    {
        public static List<uReport> GetList(string con, string str= null, bool IsActive=false, bool IsParent=false)
        {
            if (str != null && str != "")
                str = "%" + str.Replace(" ", "%") + "%";
                
            SqlParameter[] prm = new SqlParameter[3];

            prm[0] = new SqlParameter("@str", SqlDbType.NVarChar);
            prm[0].Value = str;

            prm[1] = new SqlParameter("@IsActive", SqlDbType.Bit);
            prm[1].Value = IsActive;   

            prm[2] = new SqlParameter("@IsParent", SqlDbType.Bit);
            prm[2].Value = IsParent;

            var ds = SqlHelper.ExecuteDataset(con, "uspReportList", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new uReport
                {
                    ReportId = r.Field<int>("ReportId"),
                    Name = r.Field<string>("Name"),
                    Desc = r.Field<string>("Description"),
                    PageUrl = r.Field<string>("PageUrl"),
                    IsParent = r.Field<bool>("IsParent"),
                    Parent = r.Field<int>("Parent"),
                    IsActive = r.Field<bool>("IsActive"),
                    CreateDate = r.Field<DateTime>("CreateDate")
                });
                return lst.ToList();
            }
            return null;
        }

        public static uReport GetDetail(string con, int Id)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = Id;

            var ds = SqlHelper.ExecuteDataset(con, "uspReportDetail", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new uReport
                {
                    ReportId = r.Field<int>("ReportId"),
                    Name = r.Field<string>("Name"),
                    Desc = r.Field<string>("Description"),
                    PageUrl = r.Field<string>("PageUrl"),
                    IsParent = r.Field<bool>("IsParent"),
                    Parent = r.Field<int>("Parent"),
                    IsActive= r.Field<bool>("IsActive"),
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

                return SqlHelper.ExecuteNonQuery(con, "uspReportDelete", prm);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int Edit(string con, int Id, string Name, string Desc, string PageUrl, bool IsParent, int Parent,bool IsActive)
        {
            SqlParameter[] prm = new SqlParameter[7];
            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = Id;

            prm[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            prm[1].Value = Name;

            prm[2] = new SqlParameter("@Desc", SqlDbType.NVarChar);
            prm[2].Value = Desc;

            prm[3] = new SqlParameter("@PageUrl", SqlDbType.NVarChar);
            prm[3].Value = PageUrl;

            prm[4] = new SqlParameter("@IsParent", SqlDbType.Bit);
            prm[4].Value = IsParent;

            prm[5] = new SqlParameter("@Parent", SqlDbType.Int);
            prm[5].Value = Parent;

            prm[6] = new SqlParameter("@IsActive", SqlDbType.Bit);
            prm[6].Value = IsActive;

            return SqlHelper.ExecuteNonQuery(con, "uspReportEdit", prm);
        }

        public static bool CheckExist(string con, string Name, int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            prm[0].Value = Name;

            prm[1] = new SqlParameter("@Id", SqlDbType.Int);
            prm[1].Value = Id;

            return Convert.ToBoolean(SqlHelper.ExecuteScalar(con, "uspReportCheckExist", prm));
        }
    }

    public class uReport
    {
        public uReport() { }
        public uReport(int Reportid, string name, string desc, string pageurl, bool isparent, int parent, bool isactive, int index, DateTime createdate)
        {
            this.ReportId = Reportid;
            this.Name = name;
            this.Desc = desc;
            this.PageUrl = pageurl;
            this.IsParent = isparent;
            this.Parent = parent;
            this.IsActive = isactive;
            this.Index = index;
            this.CreateDate = createdate;
        }

        public int ReportId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string PageUrl { get; set; }
        public bool IsParent { get; set; }
        public int Parent { get; set; }
        public bool IsActive { get; set; }
        public int Index { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
