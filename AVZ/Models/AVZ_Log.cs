using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadri_AVZ.Models
{
    public class AVZ_Log
    {
        public long id_log { get; set; }
        public DateTime Log_Date { get; set; }
        public string First_Name { get; set; } 
        public string Middle_Name { get; set; } 
        public string Last_Name { get; set; }
        public string Job_Title { get; set; }
        public string Activity { get; set; } = null!;
        
    }
}

