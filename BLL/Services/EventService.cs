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
    }
}
