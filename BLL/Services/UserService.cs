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
    public class UserService
    {
        public static bool Create(UserDTO obj)
        {
            var mapper = MapperService<UserDTO, User>.GetMapper();
            var conv = mapper.Map<User>(obj);
            return DataAccess.UserData().Create(conv);
        }
        public static List<UserDTO> Get()
        {
            var data = DataAccess.UserData().Get();
            var mapper = MapperService<User, UserDTO>.GetMapper();
            return mapper.Map<List<UserDTO>>(data); ;
        }
        public static UserDTO Get(string username)
        {
            var data = DataAccess.UserData().Get(username);
            var mapper = MapperService<User, UserDTO>.GetMapper();
            return mapper.Map<UserDTO>(data);
        }
        public static bool Update(UserDTO obj)
        {
            var mapper = MapperService<UserDTO, User>.GetMapper();
            var conv = mapper.Map<User>(obj);
            return DataAccess.UserData().Update(conv);
        }
        public static bool Delete(string username)
        {
            return DataAccess.UserData().Delete(username);
        }
    }
}
