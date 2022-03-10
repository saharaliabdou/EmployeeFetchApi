using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFetchApi
{
    public class Employee
    {
        public string status { get; set; }
        public EmployeeData[] data { get; set; }
        public string message { get; set; }
    }
}
