﻿using AutoMapper;
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
        public static List<CreatorDto> Get()
        {
            var data = DataAccessFactory.CreatorData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Creator, CreatorDto>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<CreatorDto>>(data);
            return con;
        }

        //get single Creator
        public static CreatorDto Get(int id)
        {
            var data = DataAccessFactory.CreatorData().Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Creator, CreatorDto>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<CreatorDto>(data);
            return con;
        }

        //Create Creator 
        public static bool Create(CreatorDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatorDto, Creator>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<Creator>(obj);

            return DataAccessFactory.CreatorData().Create(con);
        }

        //Delete Creator
        public static bool Delete(int id)
        {
            return DataAccessFactory.CreatorData().Delete(id);
        }

        //Update Creator
        public static bool Update(CreatorDto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatorDto, Creator>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Creator>(obj);

            return DataAccessFactory.CreatorData().Update(con);
        }

    }
}