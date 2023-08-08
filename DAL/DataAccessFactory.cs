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
    public class DataAccessFactory
    {
        public static IRepo<Admin,int, bool> AdminData()
        {
            return new AdminRepo();
        }

        public static IRepo<Creator,int, bool> CreatorData()
        {
            return new CreatorRepo();
        }

        public static IRepo<Donator, int, bool> DonatorData()
        {
            return new DonatorRepo();
        }

        public static IRepo<EventDonator, int, bool> EventDonatorData()
        {
            return new EventDonatorRepo();
        }

        public static IRepo<Event, int, bool> EventData()
        {
            return new EventRepo();
        }

        public static IRepo<Membership, int, bool> MembershipData()
        {
            return new MembershipRepo();
        }




    }
}
