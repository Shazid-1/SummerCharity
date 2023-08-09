using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DonatorRepo : Repo, IRepo<Donator, int, bool>
    {
        public bool Create(Donator obj)
        {
            db.Donators.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Donators.Find(id);
            db.Donators.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Donator> Get()
        {
            return db.Donators.ToList();
        }

        public Donator Get(int id)
        {
            return db.Donators.Find(id);
        }

        public bool Update(Donator obj)
        {
            var data = db.Donators.Find(obj.Id);

            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
