using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class EventDonator
    {
        public int Id { get; set; }
        public int Donation { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey("Doantor")] public int DId { get; set; }
        [ForeignKey("Event")] public int EId { get; set; }
        public virtual Donator Donator { get; set; }
        public virtual Event Event { get; set; }
    }
}
