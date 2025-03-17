using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormSubmission.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please provide Id")]
        [Range(1,40)]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters")]
        public string Name { get; set; }
        [Required,StringLength(10)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}