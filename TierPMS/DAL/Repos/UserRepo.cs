using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>, IAuth
    {
        public User Authenticate(string uname, string pass)
        {
            return db.Users.FirstOrDefault(x => x.Username.Equals(uname) && x.Password.Equals(pass));
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            var ex = Get(id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public User Get(string id)
        {
            return db.Users.FirstOrDefault(x=>x.Username.Equals(id));
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Update(User obj)
        {
            var ex = Get(obj.Username);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
