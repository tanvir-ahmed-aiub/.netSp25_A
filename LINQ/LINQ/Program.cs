using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        
        static int Add(params int[] a) {
            int sum = 0;
            foreach (int i in a) {
                sum += i;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Add();
            Add(1,2);
            Add(2,3,3);
            Add(2,3,56,45,456,3);
            var s1 = new Student() { 
                Id = 1,
                Name = "S1",
                Cgpa = 3.45f
            };
            var s2 = new Student()
            {
                Id = 1,
                Name = "S1",
                Cgpa = 3.78f
            };
            var s3 = new Student()
            {
                Id = 1,
                Name = "S1",
                Cgpa = 3.76f
            };
            Student[] students = new Student[] { s1,s2,s3};
            var data= (from s in students where s.Cgpa >= 3.75 select s).ToList();

            /*from s in students
            where s.Cgpa>=3.75
            select  s*/
        }
    }
}
