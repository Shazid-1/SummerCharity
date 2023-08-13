using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class MembershipService
    {
        public static bool Create(MembershipDTO obj)
        {
            var mapper = MapperService<MembershipDTO, Membership>.GetMapper();
            var conv = mapper.Map<Membership>(obj);
            return DataAccess.MembershipData().Create(conv);
        }
        public static List<MembershipDTO> Get()
        {
            var data = DataAccess.MembershipData().Get();
            var mapper = MapperService<Membership,MembershipDTO>.GetMapper();
            return mapper.Map<List<MembershipDTO>>(data); ;
        }
        public static MembershipDTO Get(int id)
        {
            var data = DataAccess.MembershipData().Get(id);
            var mapper = MapperService<Membership, MembershipDTO>.GetMapper();
            return mapper.Map<MembershipDTO>(data);
        }
        public static bool Update(MembershipDTO obj)
        {
            var mapper = MapperService<MembershipDTO, Membership>.GetMapper();
            var conv = mapper.Map<Membership>(obj);
            return DataAccess.MembershipData().Update(conv);
        }
        public static bool Delete(int id)
        {
            return DataAccess.MembershipData().Delete(id);
        }
    }
}
