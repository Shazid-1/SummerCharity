using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Goal { get; set; }
        public int Fund { get; set; }
        [ForeignKey("Admin")] public int? AId { get; set; }
        [ForeignKey("Creator")] public int CId { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Creator Creator { get; set; }
    }
}
