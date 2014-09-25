using System.Collections.Generic;
using System.Data;
using System;
namespace Machine.BAL
{
    public class BLPlantHM
    {
        public static List<DAL.PlantHireMachine> GetList(string con)
        {
            return Machine.DAL.PlantHireMachines.GetList(con);
        }

        public static Machine.DAL.PlantHireMachine GetDetail(string con, int Id)
        {
            return Machine.DAL.PlantHireMachines.GetDetail(con, Id);
        }

        public static int Edit(string con, int Id, DateTime HireDate, int DocketNo, double StartHour, double FinishHour, double Hours, int Plant, double Wet, double Nett)
        {
            return Machine.DAL.PlantHireMachines.Edit(con, Id, HireDate, DocketNo, StartHour,FinishHour, Hours, Plant,Wet,Nett);
        }

        public static object Delete(string con, int Id)
        {
            return Machine.DAL.PlantHireMachines.Delete(con, Id);
        }
    }
}
