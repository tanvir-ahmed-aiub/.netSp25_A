using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo
    {
        UMSContext db;
        public StudentRepo() { 
            db = new UMSContext();
        }
        public void Create(Student s) {
            db.Students.Add(s);
            db.SaveChanges();
        
        }
        public List<Student> Get() {
            return db.Students.ToList();
        }
        public Student Get(int id) {
            return db.Students.Find(id);
        }
        public void Update(Student s) {
            var exobj = Get(s.Id);
            db.Entry(exobj).CurrentValues.SetValues(s);
            db.SaveChanges();
        }
        public void Delete(int id) {
            var exobj = Get(id);
            db.Students.Remove(exobj);
            db.SaveChanges();
        }

    }
}
