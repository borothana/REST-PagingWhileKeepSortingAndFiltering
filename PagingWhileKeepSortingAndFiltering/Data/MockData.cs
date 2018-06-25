using SortingAndFiltering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SortingAndFiltering.Data
{
    public static class MockData
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee(){ EmployeeID = 1, Firstname = "Sorphea", Lastname = "Tep", Department = "HR", Team = "Recruiter", StartDate = DateTime.Parse("06/07/2016") },
            new Employee(){ EmployeeID = 2, Firstname = "Samphors", Lastname = "Doul", Department = "Finance", Team = "Receivable", StartDate = DateTime.Parse("06/07/2016") },
            new Employee(){ EmployeeID = 3, Firstname = "Borothana", Lastname = "Doul", Department = "IT", Team = "CRM", StartDate = DateTime.Parse("08/09/2017") },
            new Employee(){ EmployeeID = 4, Firstname = "Samphorsbopha", Lastname = "Lim", Department = "Law", Team = "Lawyer", StartDate = DateTime.Parse("10/11/2018") },
            new Employee(){ EmployeeID = 5, Firstname = "Bopha", Lastname = "Doul", Department = "Finace", Team = "Account", StartDate = DateTime.Parse("01/02/2018") }
        };

    }
}