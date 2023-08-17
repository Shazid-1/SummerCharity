using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MembershipCreatorService
    {
        public static bool Create(MembershipCreatorDTO obj)
        {
            var mapper = MapperService<MembershipCreatorDTO, MembershipCreator>.GetMapper();
            var conv = mapper.Map<MembershipCreator>(obj);
            return DataAccess.MembershipCreatorData().Create(conv);
        }
        public static List<MembershipCreatorDTO> Get()
        {
            var data = DataAccess.MembershipCreatorData().Get();
            var mapper = MapperService<MembershipCreator, MembershipCreatorDTO>.GetMapper();
            return mapper.Map<List<MembershipCreatorDTO>>(data); ;
        }
        public static MembershipCreatorDTO Get(int id)
        {
            var data = DataAccess.MembershipCreatorData().Get(id);
            var mapper = MapperService<MembershipCreator, MembershipCreatorDTO>.GetMapper();
            return mapper.Map<MembershipCreatorDTO>(data);
        }
        public static bool Update(MembershipCreatorDTO obj)
        {
            var mapper = MapperService<MembershipCreatorDTO, MembershipCreator>.GetMapper();
            var conv = mapper.Map<MembershipCreator>(obj);
            return DataAccess.MembershipCreatorData().Update(conv);
        }
        public static bool Delete(int id)
        {
            return DataAccess.MembershipCreatorData().Delete(id);
        }
    }
}
