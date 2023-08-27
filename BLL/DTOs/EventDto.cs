using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int Goal { get; set; }
        public int Fund { get; set; }
        public int? AId { get; set; }
        public int CId { get; set; }
    }
}
