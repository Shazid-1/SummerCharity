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
    public class AdminService
    {
        public static List<AdminDTO>Get()
        {
            var data = DataAccess.AdminData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<AdminDTO>>(data);
            return con;
        }
        public static AdminDTO Get(int id)
        {
            var data = DataAccess.AdminData().Get(id);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<AdminDTO>(data);
            return con;
        }
        public static int Create(UserAdminDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserAdminDTO, Admin>();
                cfg.CreateMap<UserAdminDTO, User>();
            });

            var mapper = new Mapper(config);
            var RId = DataAccess.RoleData().Get("ADMIN").Id;
            obj.RId = RId;
            var con = mapper.Map<Admin>(obj);
            var conU = mapper.Map<User>(obj);

            bool Status = DataAccess.AdminData().Create(con);
            bool StatusU = DataAccess.UserData().Create(conU);
            if (Status && StatusU) return 3;
            if (StatusU) return 2;
            if (Status) return 1;
            else return 0;
        }
        public static bool Delete(int id)
        {
            return DataAccess.AdminData().Delete(id);
        }
        public static bool Update(AdminDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Admin>(obj);

            return DataAccess.AdminData().Update(con);
        }
    }
}
