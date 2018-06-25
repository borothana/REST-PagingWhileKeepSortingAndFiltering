using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SortingAndFiltering.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public DateTime StartDate { get; set; }
    }
}