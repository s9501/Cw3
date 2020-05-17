using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Models.DTOs.Responses
{
    public class EnrollStudentResponse
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Semester { get; set; }
        public DateTime StartDate { get; set; }
    }
}
