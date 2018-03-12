using System;

namespace Task
{
    public class Materials
    {
        public String MaterialId { get; set; }
        public String MaterialType { get; set; }

        public int Smc { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }

        public String Grp { get; set; }


        public UnitEnum Units { get; set; }

        public ClassEnum Class { get; set; }
        

    }
}