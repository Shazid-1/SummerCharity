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
    public class EventDonatorService
    {
        //get all Donator 
        public static List<EventDonatorDTO> Get()
        {
            var data = DataAccess.EventDonatorData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDonator, DonatorDTO>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<EventDonatorDTO>>(data);
            return con;
        }

        //get single Donator
        public static EventDonatorDTO Get(int id)
        {
            var data = DataAccess.EventDonatorData().Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDonator, EventDonatorDTO>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<EventDonatorDTO>(data);
            return con;
        }

        //Create Donator 
        public static bool Create(EventDonatorDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDonatorDTO, EventDonator>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<EventDonator>(obj);

            return DataAccess.EventDonatorData().Create(con);
        }

        //Delete Donator
        public static bool Delete(int id)
        {
            return DataAccess.EventDonatorData().Delete(id);
        }

        //Update Donator
        public static bool Update(EventDonatorDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDonatorDTO, EventDonator>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<EventDonator>(obj);

            return DataAccess.EventDonatorData().Update(con);
        }
    }
}
