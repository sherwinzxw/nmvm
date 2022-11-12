using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using nmvm.Models.nmvm;
using nmvm.Utilities;

namespace nmvm.Controllers.nmvm
{
    /// <summary>
    /// The Restful API controller for the interactions with the Employee data
    /// </summary>
    public class EmployeesController : ApiController
    {
        private NMVM_Entities db = new NMVM_Entities();

        // GET: api/Employees
        ///<Summary>
        /// List the employees
        ///</Summary>
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/Employees/5
        ///<Summary>
        /// Get the employee by its id
        /// <param name="id">The id of the employee</param>
        ///</Summary>
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        ///<Summary>
        /// Update the employee
        /// <param name="id">The id of the employee</param>
        /// <param name="employee">The update content of the employee</param>
        ///</Summary>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(int id, [FromBody] dynamic employee)
        {
            int _id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (Int32.TryParse(employee.id.Value.ToString(), out _id))
                {
                    _id = Int32.Parse(employee.id.Value.ToString());
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Error Message: " + e.Message);
            }

            if (id != _id)
            {
                return BadRequest();
            }

            Employee existingEmployee = db.Employees.Where(u => u.Id == id).First();
            Employee merge = ObjectMerger.UpsertDynamic(existingEmployee, employee);
            if (existingEmployee != null)
            {
                db.Entry(existingEmployee).CurrentValues.SetValues(merge);

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                return NotFound();
            }


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        ///<Summary>
        /// Create a new employee
        /// <param name="employee">The content of the new employee</param>
        ///</Summary>
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee newEmployee = new Employee().New(employee);

            db.Employees.Add(newEmployee);

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newEmployee.Id }, newEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}