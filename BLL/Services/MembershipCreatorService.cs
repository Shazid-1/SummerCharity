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

        //membership approval. Do it after finishing event service
        public static bool MembershipApprove(int cid,string token)
        {
            var m = DataAccess.MembershipCreatorData().Get();
            var user = (from u in DataAccess.TokenData().Get()
                        where u.Key.Equals(token)
                        select u).FirstOrDefault();
            var admin = (from a in DataAccess.TokenData().Get()
                         where a.Username.Equals(user.Username)
                         select a).FirstOrDefault();

            if(admin == null)
            {
                return false; // no admin found.
            }
            else
            {
                var mc =(from mcr in DataAccess.MembershipCreatorData().Get()
                         where mcr.CId == cid
                         select mcr).FirstOrDefault();
                var newdate = DateTime.Now.AddDays(30); //add thirty days from current date
                mc.Validity = newdate; // set new validity

                return DataAccess.MembershipCreatorData().Update(mc); //finally update
            }
            
        }
    }
}
