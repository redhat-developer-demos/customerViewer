using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace customerViewer.Data
{
    public class CustomerService
    {
        public async Task<List<Customer>> GetCustomersAsync()
        {
            // Get URL from environment variable
            
            string URL = Environment.GetEnvironmentVariable("TRIVIAHHH_GATEWAY_URL");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                List<Customer> customerList = null;
                if (response.IsSuccessStatusCode)
                {
                    customerList = (List<Customer>?)await response.Content.ReadAsAsync<IEnumerable<Customer>>();
                }
                return customerList;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}
