using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Machine.DAL
{
    public class Equipments
    {
        public static List<Equipment> GetList(string con, string EqType, string str)
        {
            if (str != null && str != "")
                str = "%" + str.Replace(" ", "%") + "%";

            SqlParameter[] prm = new SqlParameter[2];
            
            prm[0] = new SqlParameter("@EqType", SqlDbType.VarChar);
            prm[0].Value = EqType;

            prm[1] = new SqlParameter("@str", SqlDbType.NVarChar);
            prm[1].Value = str;
            var ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspEquipmentList",prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new Equipment
                {
                    EquipmentId = r.Field<int>("EquipmentId"),
                    Name = r.Field<string>("Name"),
                    Value= r.Field<string>("Value"),
                    EqType = r.Field<string>("EqType"),
                    CreateDate = r.Field<DateTime>("CreateDate")
                }).ToList();
                return lst;
            }
            return null;
        }

        public static Machine.DAL.Equipment GetDetail(string con, int Id)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = Id;

            var ds = SqlHelper.ExecuteDataset(con, "uspEquipmentDetail", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new Equipment
                {
                    EquipmentId = r.Field<int>("EquipmentId"),
                    Name = r.Field<string>("Name"),
                    Value= r.Field<string>("Value"),
                    EqType = r.Field<string>("EqType"),
                    CreateDate = r.Field<DateTime>("CreateDate")
                }).FirstOrDefault();
                return lst;
            }
            return null;
        }

        public static int Delete(string con,int Id)
        {
            try
            {
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@Id", SqlDbType.Int);
                prm[0].Value = Id;

                return SqlHelper.ExecuteNonQuery(con, "uspEquipmentDelete", prm);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int Edit(string con, int Id, string Name, string Value, string EqType)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = Id;

            prm[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            prm[1].Value = Name;

            prm[2] = new SqlParameter("@Value", SqlDbType.NVarChar);
            prm[2].Value = Value;

            prm[3] = new SqlParameter("@EqType", SqlDbType.VarChar);
            prm[3].Value = EqType;

            return SqlHelper.ExecuteNonQuery(con, "uspEquipmentEdit", prm);
        }

        public static bool CheckExist(string con, string Name, int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            prm[0].Value = Name;

            prm[1] = new SqlParameter("@Id", SqlDbType.Int);
            prm[1].Value = Id;

            return Convert.ToBoolean(SqlHelper.ExecuteScalar(con, "uspEquipmentCheckExist", prm));
        } 
    }

    public class Equipment
    {
       public Equipment() { }
       public Equipment(int equipmentid, string name, string value, string eqtype, DateTime createdate)
        {
            this.EquipmentId = equipmentid;
            this.Name = name;
            this.Value= value;
            this.EqType = eqtype;
            this.CreateDate= createdate;
        }

        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string EqType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
