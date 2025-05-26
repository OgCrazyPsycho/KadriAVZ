using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadri_AVZ.Models
{
    public class AVZ_Salary
    {
        public long id { get; set; }
        public long EmployeeId { get; set; } // внешний ключ на AVZ_User
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public AVZ_User Employee { get; set; } = null!;
    }
}
