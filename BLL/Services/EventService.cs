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
    public class EventService
    {
        public static List<EventDTO> Get()
        {
            var data = DataAccess.EventData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDTO>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<EventDTO>>(data);
            return con;
        }
        public static EventDTO Get(int id)
        {
            var data = DataAccess.EventData().Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDTO>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<EventDTO>(data);
            return con;
        }
        public static bool Create(EventDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDTO, Event>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<Event>(obj);

            return DataAccess.EventData().Create(con);
        }
        public static bool Delete(int id)
        {
            return DataAccess.EventData().Delete(id);
        }
        public static bool Update(EventDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDTO, Event>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Event>(obj);

            return DataAccess.EventData().Update(con);
        }

        public static List<EventDTO> GetPendingEvent()
        {
            var data = DataAccess.EventData().Get();

            var events = (from u in data
                          where u.AId == null
                          select u).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<Event>, List<EventDTO>>();
            });

            var mapper = new Mapper(config);
            var e = mapper.Map<List<EventDTO>>(events);
            return e;
        }

        //this api will filter events by its start date
        public static List<EventDTO> GetByDate(DateTime d)
        {
            var history = (from e in DataAccess.EventData().Get()
                           where e.StartAt.Date == d.Date
                           select e).ToList();

            var mapper = MapperService<List<Event>, List<EventDTO>>.GetMapper();
            var con = mapper.Map<List<EventDTO>>(history);
            return con;
        }

        public static bool Approve(int eid,string token)
        {
            
            var e = DataAccess.EventData().Get(eid);
            try
            {
                var username = (from t in DataAccess.TokenData().Get()
                              where t.Key.Equals(token)
                              select t.User.Username).SingleOrDefault();
                var admin = (from a in DataAccess.AdminData().Get()
                             where a.Username.Equals(username)
                             select a).SingleOrDefault();

                e.AId = admin.Id;
           
                return DataAccess.EventData().Update(e); //finally we update the database
            }
            catch (Exception)
            {
                return false;
            }
        }

        //this api also let the admin check for donation history but with the title
        public static EventDTO GetByTitle(string t)
        {
            var history = (from e in DataAccess.EventData().Get()
                           where e.Title.ToLower().Contains(t)
                           select e).FirstOrDefault();
            var mapper = MapperService<Event, EventDTO>.GetMapper();
            var con = mapper.Map<EventDTO>(history);
            return con;
        }
    }
}
