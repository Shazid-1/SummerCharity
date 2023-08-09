using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, bool>
    {
        public bool Create(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            //finding the deletable data
            var data = db.Admins.Find(id);

            db.Admins.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public bool Update(Admin obj)
        {
            var data = db.Admins.Find(obj.Id);
            //corresponding function checks for data and sets to set values
            db.Entry(data).CurrentValues.SetValues(obj);

            return db.SaveChanges() > 0;
        }
    }
}
