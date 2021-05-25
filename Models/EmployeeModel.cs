using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperMVC.Models
{
    public class EmployeeModel
    {
        public int employeeid { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public int age { get; set; }
        public int salary { get; set; }

    }
}