using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EventRepo : Repo, IRepo<Event, int, bool>
    {
        public bool Create(Event obj)
        {
            db.Events.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Events.Find(id);
            db.Events.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Event> Get()
        {
            return db.Events.ToList();
        }

        public Event Get(int id)
        {
            return db.Events.Find(id);
        }

        public bool Update(Event obj)
        {
            var data = db.Events.Find(obj.Id);

            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
