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
        public static List<DonatorDTO> Get()
        {
            var data = DataAccess.DonatorData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donator, DonatorDTO>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<DonatorDTO>>(data);
            return con;
        }

        //get single Donator
        public static DonatorDTO Get(int id)
        {
            var data = DataAccess.DonatorData().Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donator, DonatorDTO>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<DonatorDTO>(data);
            return con;
        }

        //Create Donator 
        public static bool Create(DonatorDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DonatorDTO, Donator>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<Donator>(obj);

            return DataAccess.DonatorData().Create(con);
        }

        //Delete Donator
        public static bool Delete(int id)
        {
            return DataAccess.DonatorData().Delete(id);
        }

        //Update Donator
        public static bool Update(DonatorDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DonatorDTO, Donator>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Donator>(obj);

            return DataAccess.DonatorData().Update(con);
        }
    }
}
