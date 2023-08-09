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
        public static List<AdminDto>Get()
        {
            var data = DataAccessFactory.AdminData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDto>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<AdminDto>>(data);
            return con;
        }

        //get single admin
        public static AdminDto Get(int id)
        {
            var data = DataAccessFactory.AdminData().Get(id);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDto>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<AdminDto>(data);
            return con;
        }

        //Create Admin 
        public static bool Create(AdminDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDto, Admin>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<Admin>(obj);

            return DataAccessFactory.AdminData().Create(con);
        }
        
        //Delete Admin
        public static bool Delete(int id)
        {
            return DataAccessFactory.AdminData().Delete(id);
        }

        //Update Admin
        public static bool Update(AdminDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDto, Admin>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Admin>(obj);

            return DataAccessFactory.AdminData().Update(con);
        }
    }
}
