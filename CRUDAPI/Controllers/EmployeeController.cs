using CRUDAPI.Models;
using CRUDAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUDAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        private IRepository<Employee> repository = null;
        public EmployeeController()
        {
            
                repository = new Repository<Employee>();
            
        }

        [ResponseType(typeof(IQueryable<Employee>))]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/Employee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Employee employee = repository.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            
        }

        // POST: api/Employee
        [ResponseType(typeof(Employee))]
        public IHttpActionResult Post(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repository.Add(employee);
                repository.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != employee.EmployeeId)
                {
                    return BadRequest();
                }

                repository.Update(employee);
                repository.SaveChanges();
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Employee/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Employee employee = repository.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    repository.Delete(id);
                    repository.SaveChanges();
                    return Ok(employee);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }
    }
}
