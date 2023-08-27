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
    public partial class EventDonatorService
    {
        public static int Donate(EventDonatorDTO obj, string token)
        {
            string username = DataAccess.TokenData().Get(token).Username;
            var Member = DataAccess.DonatorData().Get(username);
            var objEvent = DataAccess.EventData().Get(obj.EId);

            if (!GetEventState(objEvent).Equals("ONGOING")) return 0;
            if (obj.Donation > Member.Balance) return 1;
            if (obj.Donation > (objEvent.Goal - objEvent.Fund)) return 2;

            obj.DId = Member.Id;
            obj.Time = DateTime.Now;
            var mapper = MapperService<EventDonatorDTO, EventDonator>.GetMapper();
            var con = mapper.Map<EventDonator>(obj);
            bool statusED = DataAccess.EventDonatorData().Create(con);
            objEvent.Fund += obj.Donation;
            Member.Balance -= obj.Donation;
            bool statusE = DataAccess.EventData().Update(objEvent);
            bool statusD = DataAccess.DonatorData().Update(Member);

            if (statusED && statusD && statusE) return 200;
            else if (statusED && statusD) return 3;
            else if (statusED && statusE) return 4;
            else if (statusE && statusD) return 5;
            else if (statusED) return 6;
            else if (statusE) return 7;
            else if (statusD) return 8;
            else return 9;
        }
        public static string GetEventState(Event obj)
        {
            if (obj == null) return null;
            if (obj.EndAt == null || obj.EndAt.Equals(DateTime.MinValue)) return "CANCELED";
            if (obj.EndAt < DateTime.Now) return "FINISHED";
            if (obj.StartAt > DateTime.Now) return "UPCOMING";
            if (obj.StartAt < DateTime.Now && obj.EndAt > DateTime.Now) return "ONGOING";
            else return "UNKNOWN";
        }
    }
}
