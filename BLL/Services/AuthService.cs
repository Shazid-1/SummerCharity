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
    public class AuthService
    {
        public static TokenDTO Login(string uname, string pass)
        {
            var user = DataAccess.AuthData().Authenticate(uname, pass);
            if (user != null)
            {
                var token = GetValidToken(uname);
                if (token != null) return token;
                token = CreateValidToken(uname);
                return token;
            }
            return null;
        }
        public static TokenDTO CreateValidToken(string uname)
        {
            var token = new Token
            {
                Key = Guid.NewGuid().ToString(),
                Username = uname,
                CreatedAt = DateTime.Now,
                ExpiredAt = DateTime.Now.AddMinutes(5)
            };
            var tk = DataAccess.TokenData().Create(token);
            var mapper = MapperService<Token, TokenDTO>.GetMapper();
            var data = mapper.Map<TokenDTO>(tk);
            return data;
        }
        public static TokenDTO GetValidToken(string uname)
        {
            var token = DataAccess.TokenData().Get().Find(t => t.Username.Equals(uname) && t.ExpiredAt > DateTime.Now);
            if (token == null) return null;
            var mapper = MapperService<Token, TokenDTO>.GetMapper();
            var data = mapper.Map<TokenDTO>(token);
            return data;
        }
        public static bool IsValidToken(string token)
        {
            var tk = DataAccess.TokenData().Get().Find(t => t.Key.Equals(token) && t.ExpiredAt > DateTime.Now);
            /*var tk = (from t in DataAccess.TokenData().Get()
                      where t.Key.Equals(token)
                      && t.ExpiredAt > DateTime.Now
                      select t).SingleOrDefault();*/
            if (tk != null) return true;
            return false;
        }
        public static bool IsRoleToken(string token, string role)
        {
            var uname = DataAccess.TokenData().Get().Find(t => t.Key.Equals(token)).Username;
            var user = DataAccess.UserData().Get(uname);
            var RId = DataAccess.RoleData().Get(role).Id;
            if (user.RId == RId) return true;
            return false;
        }
    }
}
