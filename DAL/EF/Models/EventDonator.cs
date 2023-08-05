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
        public int Donated { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey("Doantor")] public int DId { get; set; }
        [ForeignKey("Event")] public int EId { get; set; }
        public Donator Donator { get; set; }
        public Event Event { get; set; }
    }
}
