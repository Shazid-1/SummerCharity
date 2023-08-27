using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CreatorRepo : Repo, IName<Creator, int, bool>
    {
        public bool Create(Creator obj)
        {
            db.Creators.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Creators.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Creator> Get()
        {
            return db.Creators.ToList();
        }

        public Creator Get(int id)
        {
            return db.Creators.Find(id);
        }

        public Creator Get(string uname)
        {
            return db.Creators.FirstOrDefault(x => x.Username.Equals(uname));
        }

        public bool Update(Creator obj)
        {
            var prev = Get(obj.Id);
            db.Entry(prev).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
