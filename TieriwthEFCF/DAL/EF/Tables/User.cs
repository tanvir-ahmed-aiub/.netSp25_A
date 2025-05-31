using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uname { get; set; }
        public string Pass { get; set; }
    }
}
