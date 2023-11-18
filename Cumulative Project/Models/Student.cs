using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cumulative_Project.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public DateTime EnrolDate { get; set; }
    }
}