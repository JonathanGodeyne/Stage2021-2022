using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MpleoEmployeeTest
{
    public class GetEmployees
    {
        private static HttpClient Client = new HttpClient();
        static string _myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string _mpleoPath = $"{_myDocuments}\\TaskScheduler\\Mpleo";

        public static async Task<List<MpleoEmployee>> GetMpleoEmployeesAsync(string url)
        {            
            Console.WriteLine("GET: + " + url);

            //TODO use correct method to use secrets
            //Basic authentication values for Mpleo
            var username = "DemoArnoHRAPI";
            var password = "DU4OMQF89TsjIL";

            //TODO use correct method to use secrets
            //Azure subscription values
            var keyName = "Ocp-Apim-Subscription-Key";
            var keyValue = "81b01fa3ef0c47a599a0c57cb4027442";

            //Add basic authentication and azure subscription to request header
            var byteArray = Encoding.ASCII.GetBytes(username + ":" + password);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Client.DefaultRequestHeaders.Add(keyName, keyValue);

            //GET response and convert to content
            HttpResponseMessage response = await Client.GetAsync(url);
            HttpContent content = response.Content;

            //Write status code to file                                
            File.WriteAllText(_mpleoPath + "\\Employees.txt", "Response StatusCode: " + (int)response.StatusCode + Environment.NewLine + "Date: " + DateTime.Now + Environment.NewLine);

            if ((int)response.StatusCode == 200)
            {
                //Serialize content to List of Mpleo employees
                string result = await content.ReadAsStringAsync();
                var mpleoEmployees = JsonSerializer.Deserialize<List<MpleoEmployee>>(result);

                return mpleoEmployees;
            }
            return new List<MpleoEmployee>();
        }
    }
}
