using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class User
    {
        [Key] public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("Role")] public int RId { get; set; }
        public virtual Role Role { get; set; }
    }
}
