using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MembershipRepo : Repo, IRepo<Membership, int, bool>
    {
        public bool Create(Membership obj)
        {
            db.Memberships.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Memberships.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Membership> Get()
        {
            return db.Memberships.ToList();
        }

        public Membership Get(int id)
        {
            return db.Memberships.Find(id);
        }

        public bool Update(Membership obj)
        {
            var prev = Get(obj.Id);
            db.Entry(prev).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
