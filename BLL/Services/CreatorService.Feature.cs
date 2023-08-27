using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public partial class CreatorService
    {
        public static List<EventDTO> History(string token)
        {
            string username = DataAccess.TokenData().Get(token).Username;
            var member = DataAccess.CreatorData().Get(username);
            var events = DataAccess.EventData().Get().Where(x => x.CId == member.Id);
            var mapper = MapperService<Event, EventDTO>.GetMapper();
            var con = mapper.Map<List<EventDTO>>(events);
            return con;
        }
    }
}
