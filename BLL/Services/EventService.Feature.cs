using AutoMapper;
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
    public partial class EventService
    {
        public static int EventRequest(EventDTO obj, string token)
        {
            string Username = DataAccess.TokenData().Get().Find(t => t.Key.Equals(token)).Username;
            var Member = DataAccess.MembershipCreatorData().Get().Find(x => x.Creator.Username.Equals(Username));
            bool Validity = Member.Validity > DateTime.Now;
            if (!Validity) return 0;
            if (obj.Goal > Member.Membership.MaxGoal) return 1;
            obj.CId = Member.CId;
            obj.Fund = 0;
            obj.AId = null;
            var mapper = MapperService<EventDTO, Event>.GetMapper();
            var con = mapper.Map<Event>(obj);

            bool Status = DataAccess.EventData().Create(con);
            if(Status)  return 200;
            else return 2;
        }
        public static bool Approve(int eid, string token)
        {
            var e = DataAccess.EventData().Get(eid);
            if (e.AId != null) return false;
            var username = (from t in DataAccess.TokenData().Get()
                            where t.Key.Equals(token)
                            select t.User.Username).SingleOrDefault();
            var admin = DataAccess.AdminData().Get(username);
            e.AId = admin.Id;
            return DataAccess.EventData().Update(e); //finally we update the database
        }
        public static List<EventDTO> GetPendingEvent()
        {
            var data = DataAccess.EventData().Get();
            var events = (from u in data
                          where u.AId == null
                          select u);
            //var events = DataAccess.EventData().Get().FindAll(x => x.AId == null);
            var mapper = MapperService<Event, EventDTO>.GetMapper();
            var e = mapper.Map<List<EventDTO>>(events);
            return e;
        }
        //this api will filter approved events by its start date
        public static List<EventDTO> GetByDate(DateTime d)
        {
            var history = (from e in DataAccess.EventData().Get()
                           where e.StartAt.Date == d.Date && e.AId != null
                           select e);

            var mapper = MapperService<Event, EventDTO>.GetMapper();
            var con = mapper.Map<List<EventDTO>>(history);
            return con;
        }
        //this api also let the admin check for approved events with the title
        public static EventDTO GetByTitle(string title)
        {
            var history = (from e in DataAccess.EventData().Get()
                           where e.Title.ToLower().Contains(title.ToLower()) && e.AId != null
                           select e).FirstOrDefault();
            var mapper = MapperService<Event, EventDTO>.GetMapper();
            var con = mapper.Map<EventDTO>(history);
            return con;
        }
    }
}
