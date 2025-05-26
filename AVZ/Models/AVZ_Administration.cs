using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Supabase.Postgrest.Attributes;
using System.Diagnostics;

namespace Kadri_AVZ.Models
{
    public class AVZ_Administration
    {
        public long idAdm { get; set; }
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!; // Хеш пароля
        public string Role { get; set; } = null!; // Admin, HR, Accountant

    }
}

