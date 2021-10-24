using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public class EmployeeRepository
    {
        private static List<Employee> _employees;
        public EmployeeRepository()
        {
            _employees = new List<Employee>(){
                new Employee() { Id = 1, Name = "Mindaugas"},
                new Employee() { Id = 2, Name = "Jonas"},
                new Employee() { Id = 3, Name = "Petras"}
            };
        }
        public List<Employee> GetAll()
        {
            return _employees;
        }

        public bool DeleteById(int id)
        {
            var e = _employees.First(e => e.Id == id);
            return _employees.Remove(e);
        }
    }
}
