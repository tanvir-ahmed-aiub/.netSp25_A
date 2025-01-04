using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CourseRepo : Repo  
    {

        public void Create(Course s)
        {
            db.Courses.Add(s);
            db.SaveChanges();

        }
        public List<Course> Get()
        {
            return db.Courses.ToList();
        }
        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }
        public void Update(Course s)
        {
            var exobj = Get(s.Id);
            db.Entry(exobj).CurrentValues.SetValues(s);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var exobj = Get(id);
            db.Courses.Remove(exobj);
            db.SaveChanges();
        }

    }
}
