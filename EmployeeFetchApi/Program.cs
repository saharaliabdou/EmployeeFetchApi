using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

//using System.Text.Json.Serialization;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmployeeFetchApi
{
    class Program
    {/// <summary>
     /// This application will do a call to this api "http://dummy.restapiexample.com/api/v1/employees"
     /// And then lists the employees in a table.

     /// </summary>
     /// <param name="args"></param>
     /// <returns></returns>
      static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            HttpClient client = new HttpClient();
            try
            {
                var table = new Table();
                table.SetHeaders("ID", "Name", "Salary", "Age", "Profile Image");
                var response = await client.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");


                Employee _employeestatus = JsonConvert.DeserializeObject<Employee>(response); //Converts to c# object


                // iterate over the values in data array:
                // we have to iterate over data because we have multiple variables
                Console.WriteLine(_employeestatus.status);

                foreach (var _employee in _employeestatus.data)
                {


                    table.AddRow(_employee.id.ToString(), _employee.employee_name, _employee.employee_salary.ToString(), _employee.employee_age.ToString(), _employee.profile_image);


                }

                Console.WriteLine(table.ToString());

                Console.WriteLine(_employeestatus.message);
            }
            catch (HttpRequestException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(e.Message + "Please try again later!");

            }




        }





    }

}
