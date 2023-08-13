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
        //get all admin 
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

        //get single admin
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

        //Create Admin 
        public static bool Create(AdminDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<Admin>(obj);

            return DataAccess.AdminData().Create(con);
        }
        
        //Delete Admin
        public static bool Delete(int id)
        {
            return DataAccess.AdminData().Delete(id);
        }

        //Update Admin
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
