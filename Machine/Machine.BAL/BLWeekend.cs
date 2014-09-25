using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.BAL
{
    public class BLWeekend
    {
        public static List<DAL.Weekend> GetList(string con)
        {
            return DAL.Weekends.GetList(con);
        }
    }
}
