using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Machine.DAL
{
    public class Weekends
    {
        public static List<Weekend> GetList(string con)
        {
            var ds = Common.ExtDataset(con, "Select Id,Name,IsWeekend ,Sno from tblWeekend");
            if (ds != null)
            {
                var lst = ds.Tables[0].AsEnumerable().Select(r => new Weekend
                {
                    Id = r.Field<int>("Id"),
                    Name = r.Field<string>("Name"),
                    IsWeekend = r.Field<bool>("IsWeekend"),
                    SNo = r.Field<int>("SNo")
                }).ToList();

                return lst;
            }
            return null;
        } 
        
    }
    public class Weekend
    {
        public Weekend()
        { }
        public Weekend(int id, string name, bool isweekend, int sno)
        {
            this.Id = id;
            this.Name = name;
            this.IsWeekend = isweekend;
            this.SNo = sno;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsWeekend { get; set; }
        public int SNo { get; set; }
    }
}
