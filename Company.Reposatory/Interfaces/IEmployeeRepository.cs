using Company.Data.Models;
using Company.Reposatory.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatory.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetEmployeeByName(string name);    
        IEnumerable<Employee> GetEmployeesByAddress(string address);
      
    }
}
