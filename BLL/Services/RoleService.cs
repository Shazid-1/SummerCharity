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
    public class RoleService
    {
        public static bool Create(RoleDTO obj)
        {
            var mapper = MapperService<RoleDTO, Role>.GetMapper();
            var conv = mapper.Map<Role>(obj);
            return DataAccess.RoleData().Create(conv);
        }
        public static List<RoleDTO> Get()
        {
            var data = DataAccess.RoleData().Get();
            var mapper = MapperService<Role, RoleDTO>.GetMapper();
            return mapper.Map<List<RoleDTO>>(data); ;
        }
        public static RoleDTO Get(int id)
        {
            var data = DataAccess.RoleData().Get(id);
            var mapper = MapperService<Role, RoleDTO>.GetMapper();
            return mapper.Map<RoleDTO>(data);
        }
        public static bool Update(RoleDTO obj)
        {
            var mapper = MapperService<RoleDTO, Role>.GetMapper();
            var conv = mapper.Map<Role>(obj);
            return DataAccess.RoleData().Update(conv);
        }
        public static bool Delete(int id)
        {
            return DataAccess.RoleData().Delete(id);
        }
    }
}
