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
        public static int Create(UserCreatorDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserCreatorDTO, Creator>();
                cfg.CreateMap<UserCreatorDTO, User>();
                cfg.CreateMap<UserCreatorDTO, MembershipCreator>();
            });

            var mapper = new Mapper(config);
            var RId = DataAccess.RoleData().Get("CREATOR").Id;
            obj.RId = RId;
            var con = mapper.Map<Creator>(obj);
            var conU = mapper.Map<User>(obj);

            bool StatusC = DataAccess.CreatorData().Create(con);
            bool StatusU = DataAccess.UserData().Create(conU);

            obj.MId = DataAccess.MembershipData().Get().Find(x => x.Type.Equals(obj.Type)).Id;
            obj.CId = DataAccess.CreatorData().Get(obj.Username).Id;
            obj.Validity = null;
            var conM = mapper.Map<MembershipCreator>(obj);
            bool StatusM = DataAccess.MembershipCreatorData().Create(conM);

            if (StatusC && StatusU && StatusM) return 200;
            if (StatusC && StatusU)  return 6;
            if (StatusM && StatusU) return 5;
            if (StatusC && StatusM) return 4;
            if (StatusC) return 3;
            if (StatusU) return 2;
            if (StatusM) return 1;
            else return 0;
        }
        public static bool Delete(int id)
        {
            return DataAccess.CreatorData().Delete(id);
        }
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
