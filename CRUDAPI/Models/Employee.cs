﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public string Position { get; set; }

        public string EmpCode { get; set; }

        public string Mobile { get; set; }

    }
}