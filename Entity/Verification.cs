using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMetrolog.Entity
{
    public class Verification
    {
        public Dictionary<string, List<string>> ItemNumber { get; set; }
        public Dictionary<string, List<string>> TypeCode { get; set; }
        public Dictionary<string, List<string>> Name { get; set; }
        public Dictionary<string, List<string>> FactoryNumber { get; set; }
        public Dictionary<string, List<string>> InventoryNumber { get; set; }
        public Dictionary<string, List<string>> DateLast { get; set; }
        public Dictionary<string, List<string>> DateNext { get; set; }
        public Dictionary<string, List<string>> DateOnSchedule { get; set; }
        public Dictionary<string, List<string>> DivisionName { get; set; }
        public Dictionary<string, List<string>> Condition { get; set; }
        public Dictionary<string, List<string>> TypeMo { get; set; }

    }
}
