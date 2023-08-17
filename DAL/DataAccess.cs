using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IUname<Admin,int, bool> AdminData()
        {
            return new AdminRepo();
        }
        public static IUname<Creator,int, bool> CreatorData()
        {
            return new CreatorRepo();
        }
        public static IUname<Donator, int, bool> DonatorData()
        {
            return new DonatorRepo();
        }
        public static IRepo<Event, int, bool> EventData()
        {
            return new EventRepo();
        }
        public static IRepo<EventDonator, int, bool> EventDonatorData()
        {
            return new EventDonatorRepo();
        }
        public static IRepo<Membership, int, bool> MembershipData()
        {
            return new MembershipRepo();
        }
        public static IRepo<MembershipCreator, int, bool> MembershipCreatorData()
        {
            return new MembershipCreatorRepo();
        }
        public static IUname<Role, int, bool> RoleData()
        {
            return new RoleRepo();
        }
        public static IRepo<Token, int, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IUname<User, string, bool> UserData()
        {
            return new UserRepo();
        }
        public static IAuth AuthData()
        {
            return new UserRepo();
        }
    }
}
