using System.Collections.Generic;
using System.Data;
namespace Machine.BAL
{
    public class BLEquipment
    {
        public static List<DAL.Equipment> GetList(string con, string EqType, string str=null)
        {
            return Machine.DAL.Equipments.GetList(con, EqType, str);
        }

        public static Machine.DAL.Equipment GetDetail(string con, int Id)
        {
            return Machine.DAL.Equipments.GetDetail(con, Id);
        }

        public static int Edit(string con, int Id, string Name, string Value, string EqType)
        {
            return Machine.DAL.Equipments.Edit(con, Id, Name, Value, EqType);
        }

        public static object Delete(string con, int Id)
        {
            return Machine.DAL.Equipments.Delete(con, Id);
        }

        public static bool CheckExist(string con, string Name, int Id)
        {
            return Machine.DAL.Equipments.CheckExist(con, Name, Id);
        } 
    }
}
