using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventDonatorDto
    {
        public int Id { get; set; }
        public int Donation { get; set; }
        public DateTime Time { get; set; }
        public int DId { get; set; }
        public int EId { get; set; }
    }
}
