using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class MembershipCreator
    {
        public int Id { get; set; }
        public DateTime? Validity { get; set; }
        [ForeignKey("Creator")] public int CId { get; set; }
        [ForeignKey("Membership")] public int MId { get; set; }
        public virtual Creator Creator { get; set; }
        public virtual Membership Membership { get; set; }
    }
}
