using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDonatorDTO: DonatorDTO
    {
        public string Password { get; set; }
        public int RId { get; set; }
    }
}
