using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using SortingAndFiltering.Data;
using SortingAndFiltering.Helpers;
using SortingAndFiltering.Models;

namespace SortingAndFiltering.Controllers
{
    public class EmployeeController : ApiController
    {
        [Route("Employees", Name = "EmployeeList")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Employees(string sort, string lastname, int page, int pageSize)
        {
            
            //calculate data for metadata
            var totalCount = MockData.Employees.Where(e => e.Lastname.Contains(lastname)).ToList().Count;
            var totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            var urlHelper = new UrlHelper(Request);
            var preLink = page > 1 ? urlHelper.Link("EmployeeList",
                                        new { page = page - 1, pageSize = pageSize, sort = sort, lastname = lastname }) : "";

            var nextLink = page < totalPage ? urlHelper.Link("EmployeeList",
                                        new { page = page + 1, pageSize = pageSize, sort = sort, lastname = lastname }) : "";



            var paginationHeader = new {
                currentPage = page,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPage = totalPage,
                previousLink = preLink,
                nextLink = nextLink
            };

            HttpContext.Current.Response.Headers.Add("X-Pagination", 
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

            IQueryable<Employee> result = MockData.Employees
                                            .Where(e => e.Lastname.Contains(lastname))
                                            .AsQueryable()
                                            .ApplySort(sort)
                                            .Skip((page-1) * pageSize)
                                            .Take(pageSize);
                                                        
            return Ok(result.ApplySort(sort));
        }

        [Route("Employees")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Employees()
        {
            var result = MockData.Employees;
            return Ok(result);
        }


        [Route("Employees/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Employees(int id)
        {
            var result = MockData.Employees.Where(e => e.EmployeeID == id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}