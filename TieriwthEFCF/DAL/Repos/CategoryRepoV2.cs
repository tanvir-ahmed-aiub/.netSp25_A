using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepoV2 : IRepo<Category,int,bool>
    {
        public bool Create(Category obj)
        {
            throw new NotImplementedException();
        }

        public void CreateCategory() { 
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategory() {
            return null;
        }

        public bool Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
