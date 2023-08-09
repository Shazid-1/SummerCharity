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
    public class DonatorService
    {
        //get all Donator 
        public static List<DonatorDto> Get()
        {
            var data = DataAccessFactory.DonatorData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donator, DonatorDto>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<DonatorDto>>(data);
            return con;
        }

        //get single Donator
        public static DonatorDto Get(int id)
        {
            var data = DataAccessFactory.DonatorData().Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donator, DonatorDto>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<DonatorDto>(data);
            return con;
        }

        //Create Donator 
        public static bool Create(DonatorDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DonatorDto, Donator>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<Donator>(obj);

            return DataAccessFactory.DonatorData().Create(con);
        }

        //Delete Donator
        public static bool Delete(int id)
        {
            return DataAccessFactory.DonatorData().Delete(id);
        }

        //Update Donator
        public static bool Update(DonatorDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DonatorDto, Donator>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Donator>(obj);

            return DataAccessFactory.DonatorData().Update(con);
        }
    }
}
