﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cumulative_Project.Models
{
    public class Teacher
    {
            public int Id { get; set; }
            public string Name { get; set; }

            public string LastName { get; set; }
            public DateTime HireDate { get; set; }
            public decimal Salary { get; set; }
           
    }
}