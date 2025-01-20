using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Product,int,Product> ProductData() {
            return new ProductRepo();
        }
        public static IRepo<Category, int, bool> CategoryData() { 
            return new CategoryRepo();
        }
        public static IProductFeatures ProductFeatures() {
            return new ProductRepo();
        }
        public static IRepo<User, string, User> UserData() { 
            return new UserRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IAuth AuthData() {
            return new UserRepo();
        }

    }
}
