using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Machine.DAL
{
    public class PlantHireMachines
    {
        public static List<PlantHireMachine> GetList(string con, string EqType, string str)
        {
            if (str != null && str != "")
                str = "%" + str.Replace(" ", "%") + "%";

            SqlParameter[] prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@EqType", SqlDbType.VarChar);
            prm[0].Value = EqType;

            prm[1] = new SqlParameter("@str", SqlDbType.NVarChar);
            prm[1].Value = str;

            var ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspPlantHireMachineList", prm);
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new PlantHireMachine
                {
                    MachineId = r.Field<int>("MachineId"),
                    HireDate = r.Field<DateTime>("HireDate"),
                    DocketNo = r.Field<int>("DocketNo"),
                    StartHour = r.Field<float>("StartHour"),
                    FinishHour = r.Field<float>("FinishHour"),
                    Hours = r.Field<float>("Hours"),
                    Plant = r.Field<int>("Plant"),
                    Wet = r.Field<float>("Wet"),
                    Nett = r.Field<float>("Nett")
                }).ToList();
                return lst;
            }
            return null;
        }

        public static Machine.DAL.PlantHireMachine GetDetail(string con, int Id)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = Id;

            var ds = SqlHelper.ExecuteDataset(con, "uspPlantHireMachineDetail", prm);

            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new PlantHireMachine
                {
                    MachineId = r.Field<int>("MachineId"),
                    HireDate = r.Field<DateTime>("HireDate"),
                    DocketNo = r.Field<int>("DocketNo"),
                    StartHour = r.Field<float>("StartHour"),
                    FinishHour = r.Field<float>("FinishHour"),
                    Hours = r.Field<float>("Hours"),
                    Plant = r.Field<int>("Plant"),
                    Wet = r.Field<float>("Wet"),
                    Nett = r.Field<float>("Nett")
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

                return SqlHelper.ExecuteNonQuery(con, "uspPlantHireMachineDelete", prm);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int Edit(string con, int Id, DateTime HireDate, int DocketNo, float StartHour, float FinishHour, float Hours, int Plant, float Wet, float Nett)
        {
            SqlParameter[] prm = new SqlParameter[9];
            prm[0] = new SqlParameter("@Id", SqlDbType.Int);
            prm[0].Value = Id;

            prm[1] = new SqlParameter("@HireDate", SqlDbType.DateTime);
            prm[1].Value = HireDate;

            prm[2] = new SqlParameter("@DocketNo", SqlDbType.Int);
            prm[2].Value = DocketNo;

            prm[3] = new SqlParameter("@StartHour", SqlDbType.Decimal);
            prm[3].Value = StartHour;

            prm[4] = new SqlParameter("@FinishHour", SqlDbType.Decimal);
            prm[4].Value = StartHour;

            prm[5] = new SqlParameter("@Hours", SqlDbType.Decimal);
            prm[5].Value = StartHour;

            prm[6] = new SqlParameter("@Plant", SqlDbType.Int);
            prm[6].Value = StartHour;

            prm[7] = new SqlParameter("@Wet", SqlDbType.Decimal);
            prm[7].Value = StartHour;

            prm[8] = new SqlParameter("@Nett", SqlDbType.Decimal);
            prm[8].Value = Nett;

            return SqlHelper.ExecuteNonQuery(con, "uspPlantHireMachineEdit", prm);
        }

        public static bool CheckExist(string con, string Name, int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            prm[0].Value = Name;

            prm[1] = new SqlParameter("@Id", SqlDbType.Int);
            prm[1].Value = Id;

            return Convert.ToBoolean(SqlHelper.ExecuteScalar(con, "uspPlantHireMachineCheckExist", prm));
        }
    }

    public class PlantHireMachine
    {
        public PlantHireMachine() { }
        public PlantHireMachine(int machineid, DateTime hiredate, int docketno, float starthour, float finishHour, float hours, int plant, float wet, float nett)
        {
            this.MachineId = machineid;
            this.DocketNo = docketno;
            this.StartHour = starthour;
            this.FinishHour = finishHour;
            this.Hours = hours;
            this.Plant = plant;
            this.Wet = wet;
            this.Nett = nett;
        }

        public int MachineId { get; set; }
        public DateTime HireDate { get; set; }
        public int DocketNo { get; set; }
        public float StartHour { get; set; }
        public float FinishHour { get; set; }
        public float Hours { get; set; }
        public int Plant { get; set; }
        public float Wet { get; set; }
        public float Nett { get; set; }
    }
}
