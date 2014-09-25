using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Machine.DAL
{
    public class PlantHireMachines
    {
        public static List<PlantHireMachine> GetList(string con)
        {
            //if (str != null && str != "")
            //    str = "%" + str.Replace(" ", "%") + "%";

            //SqlParameter[] prm = new SqlParameter[2];

            //prm[0] = new SqlParameter("@EqType", SqlDbType.VarChar);
            //prm[0].Value = EqType;

            //prm[1] = new SqlParameter("@str", SqlDbType.NVarChar);
            //prm[1].Value = str;

            var ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspPlantHireMachineList");
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new PlantHireMachine
                {
                    MachineId = r.Field<int>("PlantHireMachineId"),
                    HireDate = r.Field<DateTime>("HireDate"),
                    DocketNo = r.Field<int>("DocketNo"),
                    StartHour = r.Field<decimal>("StartHour"),
                    FinishHour = r.Field<decimal>("FinishHour"),
                    Hours = r.Field<decimal>("Hours"),
                    PlantId = r.Field<int>("PlantId"),
                    PlantName = r.Field<string>("PlantName"),
                    Wet = r.Field<decimal>("Wet"),
                    Nett = r.Field<decimal>("Nett")
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
                    MachineId = r.Field<int>("PlantHireMachineId"),
                    HireDate = r.Field<DateTime>("HireDate"),
                    DocketNo = r.Field<int>("DocketNo"),
                    StartHour = r.Field<decimal>("StartHour"),
                    FinishHour = r.Field<decimal>("FinishHour"),
                    Hours = r.Field<decimal>("Hours"),
                    PlantId = r.Field<int>("PlantId"),
                    PlantName = r.Field<string>("PlantName"),
                    Wet = r.Field<decimal>("Wet"),
                    Nett = r.Field<decimal>("Nett")
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

        public static int Edit(string con, int Id, DateTime HireDate, int DocketNo, double StartHour, double FinishHour, double Hours, int Plant, double Wet, double Nett)
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
            prm[4].Value = FinishHour;

            prm[5] = new SqlParameter("@Hours", SqlDbType.Decimal);
            prm[5].Value = Hours;

            prm[6] = new SqlParameter("@Plant", SqlDbType.Int);
            prm[6].Value = Plant;

            prm[7] = new SqlParameter("@Wet", SqlDbType.Decimal);
            prm[7].Value = Wet;

            prm[8] = new SqlParameter("@Nett", SqlDbType.Decimal);
            prm[8].Value = Nett;

            return SqlHelper.ExecuteNonQuery(con, "uspPlantHireMachineEdit", prm);
        }
    }

    public class PlantHireMachine
    {
        public PlantHireMachine() { }

        public PlantHireMachine(int machineid, DateTime hiredate, int docketno, decimal starthour, decimal finishHour, decimal hours, int plantid, string plantname, decimal wet, decimal nett)
        {
            this.MachineId = machineid;
            this.DocketNo = docketno;
            this.StartHour = starthour;
            this.FinishHour = finishHour;
            this.Hours = hours;
            this.PlantId = plantid;
            this.PlantName = plantname;
            this.Wet = wet;
            this.Nett = nett;
        }

        public int MachineId { get; set; }
        public DateTime HireDate { get; set; }
        public int DocketNo { get; set; }
        public decimal StartHour { get; set; }
        public decimal FinishHour { get; set; }
        public decimal Hours { get; set; }
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public decimal Wet { get; set; }
        public decimal Nett { get; set; }
    }
}
