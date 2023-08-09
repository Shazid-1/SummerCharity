using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DonatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Occupation { get; set; }
    }
}
