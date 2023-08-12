using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MembershipCreatorRepo: Repo, IRepo<MembershipCreator, int, bool>
    {
        public bool Create(MembershipCreator obj)
        {
            db.MembershipCreators.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.MembershipCreators.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<MembershipCreator> Get()
        {
            return db.MembershipCreators.ToList();
        }

        public MembershipCreator Get(int id)
        {
            return db.MembershipCreators.Find(id);
        }

        public bool Update(MembershipCreator obj)
        {
            var prev = Get(obj.Id);
            db.Entry(prev).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
