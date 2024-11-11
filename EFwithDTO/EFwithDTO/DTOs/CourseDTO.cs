using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFwithDTO.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int DeptId { get; set; }
    }
}