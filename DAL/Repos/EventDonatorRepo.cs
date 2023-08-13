using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EventDonatorRepo : Repo, IRepo<EventDonator, int, bool>
    {
        public bool Create(EventDonator obj)
        {
            db.EventDonators.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            db.EventDonators.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<EventDonator> Get()
        {
            return db.EventDonators.ToList();
        }

        public EventDonator Get(int id)
        {
            return db.EventDonators.Find(id);
        }

        public bool Update(EventDonator obj)
        {
            var data = Get(obj.Id);

            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
