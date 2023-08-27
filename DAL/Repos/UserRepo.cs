using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IName<User, string, bool>, IAuth
    {
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(string username)
        {
            var exobj = Get(username);
            db.Users.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string username)
        {
            /*var user = from u in db.Users
                       where u.Username.Equals(username)
                       select u;
            if (user != null) return user.SingleOrDefault();*/

            return db.Users.Find(username);
        }

        public bool Update(User obj)
        {
            var prev = Get(obj.Username);
            db.Entry(prev).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
        public User Authenticate(string uname, string pass)
        {
            var user = db.Users.FirstOrDefault(u => u.Username.Equals(uname) && u.Password.Equals(pass));
            if (user != null) return user;
            /*var user = from u in db.Users
                       where u.Username.Equals(uname)
                       && u.Password.Equals(pass)
                       select u;
            if (user != null) return user.SingleOrDefault();*/
            return null;
        }
    }
}
