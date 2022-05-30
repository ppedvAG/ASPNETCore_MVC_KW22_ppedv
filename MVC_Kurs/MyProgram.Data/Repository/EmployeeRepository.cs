using MyProgram.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgram.Data.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public override List<Employee> GetAll()
        {
            return new List<Employee>();
        }

        public override Employee GetById(int id)
        {
            return new Employee();
        }

        public override void Insert(Employee Entity)
        {
            throw new NotImplementedException();
        }
    }


    //Achtung ist nicht Vorbildlich

    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
    }
}
