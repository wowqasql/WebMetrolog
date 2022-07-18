using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMetrolog.Entity;

namespace WebMetrolog
{
    public class RootJson
    {
        public Dictionary<string, List<string>> Verification { get; set; }
        public Dictionary<string, List<string>> Calibration { get; set; }



        public string ver = File.ReadAllText("Verification.json");
        public string cal = File.ReadAllText("Calibration.json");
    }

}
