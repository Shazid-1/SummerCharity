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
    public class EventEventDonatorService
    {
        //get all Donator 
        public static List<EventDonatorDto> Get()
        {
            var data = DataAccessFactory.EventDonatorData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDonator, DonatorDto>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<EventDonatorDto>>(data);
            return con;
        }

        //get single Donator
        public static EventDonatorDto Get(int id)
        {
            var data = DataAccessFactory.EventDonatorData().Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDonator, EventDonatorDto>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<EventDonatorDto>(data);
            return con;
        }

        //Create Donator 
        public static bool Create(EventDonatorDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDonatorDto, EventDonator>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<EventDonator>(obj);

            return DataAccessFactory.EventDonatorData().Create(con);
        }

        //Delete Donator
        public static bool Delete(int id)
        {
            return DataAccessFactory.EventDonatorData().Delete(id);
        }

        //Update Donator
        public static bool Update(EventDonatorDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDonatorDto, EventDonator>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<EventDonator>(obj);

            return DataAccessFactory.EventDonatorData().Update(con);
        }
    }
}
