using System.Collections.Generic;
using System.Data;
namespace Machine.BAL
{
    public class BLPlantHM
    {
        public static List<DAL.PlantHireMachine> GetList(string con, string EqType, string str)
        {
            return Machine.DAL.PlantHireMachines.GetList(con, EqType, str);
        }

        public static Machine.DAL.PlantHireMachine GetDetail(string con, int Id)
        {
            return Machine.DAL.PlantHireMachines.GetDetail(con, Id);
        }

        public static int Edit(string con, int Id, string Name, string Value, string EqType)
        {
            return Machine.DAL.PlantHireMachines.Edit(con, Id, Name, Value, EqType);
        }

        public static object Delete(string con, int Id)
        {
            return Machine.DAL.PlantHireMachines.Delete(con, Id);
        }

        public static bool CheckExist(string con, string Name, int Id)
        {
            return Machine.DAL.PlantHireMachines.CheckExist(con, Name, Id);
        } 
    }
}
