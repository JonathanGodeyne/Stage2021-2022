using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using Meziantou.Framework.Win32;
using System.Net.Http.Headers;

namespace MpleoEmployeeTest
{
    public class Program
    {
        private static HttpClient Client = new HttpClient();
        static void Main()
        {
            Task t = new Task(WriteMpleoEmployeesToTextFile);
            t.Start();
           Console.ReadLine();
        }

        static async void WriteMpleoEmployeesToTextFile()
        {
            string _myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string _mpleoPath = $"{_myDocuments}\\TaskScheduler\\Mpleo";

            var _url = "https://apim-stage-test-resource.azure-api.net/mpleo/employee";

            Console.WriteLine("GET: + " + _url);

            //Get basic authentication values from windows credentialmanager
            var basicAuthenticationMpleo = CredentialManager.ReadCredential("Mpleo");
            var username = basicAuthenticationMpleo.UserName;
            var password = basicAuthenticationMpleo.Password;

            //Get azure subscription values from windows credentialmanager
            var azureSubscription = CredentialManager.ReadCredential("AzureSubscriptionKey");
            var keyName = azureSubscription.UserName;
            var keyValue = azureSubscription.Password;

            //Add basic authentication and azure subscription to request header
            var byteArray = Encoding.ASCII.GetBytes(username+":"+password);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Client.DefaultRequestHeaders.Add(keyName, keyValue);

            //GET response and convert to content
            HttpResponseMessage response = await Client.GetAsync(_url);
            HttpContent content = response.Content;

            //Write status code to file                                
            File.WriteAllText(_mpleoPath + "\\Employees.txt", "Response StatusCode: " + (int)response.StatusCode +" "+DateTime.Now+ Environment.NewLine);

            //Serialize content to List of Mpleo employees
            string result = await content.ReadAsStringAsync();
            var mpleoEmployees = JsonSerializer.Deserialize<List<MpleoEmployee>>(result);
            

            //Write all employees to file
            foreach (var mpleoEmployee in mpleoEmployees)
            {
                ArnoEmployee arnoEmployee = (ArnoEmployee)mpleoEmployee;
                File.AppendAllText(_mpleoPath + "\\Employees.txt", JsonSerializer.Serialize(arnoEmployee, new JsonSerializerOptions { WriteIndented = true }) + Environment.NewLine);
            }
        }
    }
}
