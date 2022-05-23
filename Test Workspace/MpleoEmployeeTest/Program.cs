using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Linq;

namespace MpleoEmployeeTest
{
    public class Program
    {
        static string _myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string _mpleoPath = $"{_myDocuments}\\TaskScheduler\\Mpleo";
        //static string _url = "https://apim-stage-resource.azure-api.net/mpleo/ws/employee";
        static string _url = "https://demoarnohr.mpleo.net/ws/employee";

        static void Main()
        {
            var result = GetEmployees.GetMpleoEmployeesAsync(_url).Result;

            var arnoEmployees = result.Select(e => ArnoEmployee.MapFrom(e));
            //Write all employees to file
            foreach (var employee in arnoEmployees)
            {
                File.AppendAllText(_mpleoPath + "\\Employees.txt", JsonSerializer.Serialize(employee, new JsonSerializerOptions { WriteIndented = true }) + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}
