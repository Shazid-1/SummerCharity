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
        public static int Create(UserDonatorDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDonatorDTO, Donator>();
                cfg.CreateMap<UserDonatorDTO, User>();
            });

            var mapper = new Mapper(config);
            var RId = DataAccess.RoleData().Get("DONATOR").Id;
            obj.RId = RId;
            obj.Balance = 1000; // Default 1k balance upon registration for donators
            var con = mapper.Map<Donator>(obj);
            var conU = mapper.Map<User>(obj);

            bool Status = DataAccess.DonatorData().Create(con);
            bool StatusU = DataAccess.UserData().Create(conU);
            if (Status && StatusU) return 3;
            if (StatusU) return 2;
            if (Status) return 1;
            else return 0;
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
