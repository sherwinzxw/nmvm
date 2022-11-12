using System;

namespace nmvm.Models.nmvm
{
    public partial class Employee
    {
        /// <summary>
        /// Construct a new employee with new default values;
        /// </summary>
        /// <param name="employee">The employee data from the POST method</param>
        /// <returns></returns>
        public Employee New(Employee employee)
        {
            DateTime currentTimestamp = DateTime.Now;
            employee.CreatedDateTime = currentTimestamp;
            employee.ModifiedDateTime = currentTimestamp;
            return employee;
        }
    }
}