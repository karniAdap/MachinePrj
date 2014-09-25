using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Machine.Web.App_Code
{ 
    public class chart
    {
        public chart(int id, string name, string p1, string p2, string p3, string p4)
        {
            this.Id = id;
            this.Name = name;
            this.P1 = p1;
            this.P2 = p2;
            this.P3 = p3;
            this.P4 = p4;            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }        
    }
}