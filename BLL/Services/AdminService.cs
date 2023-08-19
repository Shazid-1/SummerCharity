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
    public class AdminService
    {
        public static List<AdminDTO>Get()
        {
            var data = DataAccess.AdminData().Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<List<AdminDTO>>(data);
            return con;
        }
        public static AdminDTO Get(int id)
        {
            var data = DataAccess.AdminData().Get(id);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });

            var mapper = new Mapper(config);
            var con = mapper.Map<AdminDTO>(data);
            return con;
        }
        public static int Create(UserAdminDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserAdminDTO, Admin>();
                cfg.CreateMap<UserAdminDTO, User>();
            });

            var mapper = new Mapper(config);
            var RId = DataAccess.RoleData().Get("ADMIN").Id;
            obj.RId = RId;
            var con = mapper.Map<Admin>(obj);
            var conU = mapper.Map<User>(obj);

            bool Status = DataAccess.AdminData().Create(con);
            bool StatusU = DataAccess.UserData().Create(conU);
            if (Status && StatusU) return 3;
            if (StatusU) return 2;
            if (Status) return 1;
            else return 0;
        }
        public static bool Delete(int id)
        {
            return DataAccess.AdminData().Delete(id);
        }
        public static bool Update(AdminDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var con = mapper.Map<Admin>(obj);

            return DataAccess.AdminData().Update(con);
        }

        public static List<EventDTO>ViewPendingApproval()
        {
            var data = DataAccess.EventData().Get();

            var events = (from u in data
                          where u.AId == null
                          select u).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDTO>();
            });
            
            var mapper = new Mapper(config);
            var e = mapper.Map<List<EventDTO>>(events);
            return e;
        }


        //this api will let the admin check for donation history for a certain event.
        public static EventDTO DonationHistory(int id)
        {
            var history = DataAccess.EventData().Get(id);
            var mapper = MapperService<Event, EventDTO>.GetMapper();
            var con = mapper.Map<EventDTO>(history);
            return con;
        }


        //this api also let the admin check for donation history but with the title
        public static EventDTO DonationHistory(string t)
        {
            var history = (from e in DataAccess.EventData().Get()
                           where e.Title.ToLower().Contains(t)
                           select e).FirstOrDefault();
            var mapper = MapperService<Event, EventDTO>.GetMapper();
            var con = mapper.Map<EventDTO>(history);
            return con;
        }

        //this api will filter events by its start date
        public static List<EventDTO> DonationHistoryByDate(DateTime d)
        {
            var history = (from e in DataAccess.EventData().Get()
                           where e.StartAt == d
                           select e).ToList();
            var mapper = MapperService<Event, EventDTO>.GetMapper();
            var con = mapper.Map<List<EventDTO>>(history);
            return con;
        }

        public static bool EventApproval(int eid,int aid)
        {
            //fetching data from the database.
            var e = DataAccess.EventData().Get(eid);
            try
            {
                e.AId = aid; // this doesnot update the database.
                return DataAccess.EventData().Update(e); //finally we update the database
            }
            catch (Exception)
            {
                return false;
            } 
        }
    }
}
