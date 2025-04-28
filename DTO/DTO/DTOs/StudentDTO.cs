using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTO.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FName { get; set; }
        [Required,StringLength(50)]
        public string LName { get; set; }
        public double Cgpa { get; set; }
        public System.DateTime Dob { get; set; }
    }
}