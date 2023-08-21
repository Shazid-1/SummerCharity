using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserCreatorDTO: CreatorDTO
    {
        public string Password { get; set; }
        public int RId { get; set; }
        public int CId { get; set; }
        public int MId { get; set; }
        public string Type { get; set; }
        public DateTime? Validity { get; set; }
    }
}
