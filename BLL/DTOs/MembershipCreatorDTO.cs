using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MembershipCreatorDTO
    {
        public int Id { get; set; }
        public DateTime Validity { get; set; }
        public int CId { get; set; }
        public int MId { get; set; }
    }
}
