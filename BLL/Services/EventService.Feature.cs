using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public partial class EventService
    {
        public static int EventRequest(EventDTO eventDTO, string token)
        {
            string Username = DataAccess.TokenData().Get().Find(t => t.Key.Equals(token)).Username;
            var Member = DataAccess.MembershipCreatorData().Get().Find(x => x.Creator.Username.Equals(Username));
            bool Validity = Member.Validity > DateTime.Now;
            if (!Validity) return 0;
            if (eventDTO.Goal > Member.Membership.MaxGoal) return 1;

            return 200;
        }
    }
}
