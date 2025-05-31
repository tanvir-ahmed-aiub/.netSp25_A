using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CategoryRepo : Repo, IRepo<Category,int,bool>
    {
        public bool Create(Category c) { 
            db.Categories.Add(c);   
            return db.SaveChanges()>0;
        }

        public void Delete(int id)
        {
            var exobj = Get(id);
            db.Categories.Remove(exobj);
            db.SaveChanges();
        }

        public List<Category> Get() { 
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges()>0;
        }
    }
}
