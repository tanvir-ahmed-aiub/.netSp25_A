using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class Repo
    {
        protected PMS_Sp25_AEntities db;
        public Repo() { 
            db = new PMS_Sp25_AEntities();
        }
    }
}
