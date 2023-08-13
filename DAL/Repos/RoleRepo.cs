using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RoleRepo: Repo, IRepo<Role,int, bool>
    {
        public bool Create(Role obj)
        {
            db.Roles.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Roles.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Role> Get()
        {
            return db.Roles.ToList();
        }

        public Role Get(int id)
        {
            return db.Roles.Find(id);
        }

        public bool Update(Role obj)
        {
            var prev = Get(obj.Id);
            db.Entry(prev).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
