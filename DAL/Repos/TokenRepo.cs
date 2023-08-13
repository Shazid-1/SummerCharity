using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Tokens.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public Token Update(Token obj)
        {
            var prev = Get(obj.Id);
            db.Entry(prev).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
