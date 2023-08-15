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
    public class CreatorService
    {
        //get all Creator 
        public static List<CreatorDTO> Get()
        {
            var data = DataAccess.CreatorData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Creator, CreatorDTO>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<CreatorDTO>>(data);
            return con;
        }

        //get single Creator
        public static CreatorDTO Get(int id)
        {
            var data = DataAccess.CreatorData().Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Creator, CreatorDTO>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<CreatorDTO>(data);
            return con;
        }

        //Create Creator 
        public static int Create(UserCreatorDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserCreatorDTO, Creator>();
                cfg.CreateMap<UserCreatorDTO, User>();
            });

            var mapper = new Mapper(config);
            var RId = DataAccess.RoleData().Get("CREATOR").Id;
            obj.RId = RId;
            var con = mapper.Map<Creator>(obj);
            var conU = mapper.Map<User>(obj);

            bool CStatus = DataAccess.CreatorData().Create(con);
            bool StatusU = DataAccess.UserData().Create(conU);
            if (CStatus && StatusU) return 3;
            if (StatusU)  return 2;
            if (CStatus) return 1;
            else return 0;
        }

        //Delete Creator
        public static bool Delete(int id)
        {
            return DataAccess.CreatorData().Delete(id);
        }

        //Update Creator
        public static bool Update(CreatorDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatorDTO, Creator>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Creator>(obj);

            return DataAccess.CreatorData().Update(con);
        }

    }
}
