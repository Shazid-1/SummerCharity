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
        //get all Event 
        public static List<EventDto> Get()
        {
            var data = DataAccessFactory.EventData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDto>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<EventDto>>(data);
            return con;
        }

        //get single Event
        public static EventDto Get(int id)
        {
            var data = DataAccessFactory.EventData().Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDto>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<EventDto>(data);
            return con;
        }

        //Create Event 
        public static bool Create(EventDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDto, Event>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<Event>(obj);

            return DataAccessFactory.EventData().Create(con);
        }

        //Delete Event
        public static bool Delete(int id)
        {
            return DataAccessFactory.EventData().Delete(id);
        }

        //Update Event
        public static bool Update(EventDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDto, Event>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Event>(obj);

            return DataAccessFactory.EventData().Update(con);
        }
    }
}
