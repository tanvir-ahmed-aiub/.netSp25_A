using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormIntro.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Please provide name")]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [Range(1,40,ErrorMessage ="Id must be 1 to 40")]
        public int Id { get; set; }
    }
}