using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kadri_AVZ.Models
{
    public class AVZ_User
    {
        public long id_user { get; set; }
        public string First_Name { get; set; } = null!;
        public string Middle_Name { get; set; } = null!;
        public string Last_Name { get; set; } = null!;
        public long Phone { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Job_Title { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string EmployeeCode { get; set; } = null!;
        public string EmploymentStatus { get; set; } = "Активен";
    }
}
