using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using FunSueClient.Model;
using Newtonsoft.Json;

namespace FunSueClient
{
    public class Client
    {
        private HttpClient httpClient;

        public string BaseUrl { get; set; }
        public Client(string baseUrl)
        {
            this.BaseUrl = baseUrl;
            this.httpClient = new HttpClient();
        }

        private JsonContent ToJsonContent<T>(T obj)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };

            var content = JsonContent.Create(obj, options: options);
            return content;
        }

        private async Task<T> Output<T>(HttpResponseMessage response)
        {

            if (response.IsSuccessStatusCode)
            {
                // Get response from server
                var responseBody = await response.Content.ReadAsStringAsync();

                // Convert response of type JSON into a PingResponse object
                var convertedResponse = JsonConvert.DeserializeObject<T>(responseBody);

                return convertedResponse;

            }
            else
            {
                Console.WriteLine($"Fehler: {(int)response.StatusCode} ({response.StatusCode})");
                return default(T);
            }
        }

        public async Task Ping()
        {
            // HTTP GET-Request /ping
            var response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/ping");

            var awaitedReturn = await Output<PingResponse>(response);

            Console.WriteLine(awaitedReturn.Message);
        }

        public async Task Greeting(string name)
        {
            var response = await this.httpClient.GetAsync($"{this.BaseUrl}/api/v1/greet?name={name}");

            var awaitedReturn = await Output<GreetingResponse>(response);

            Console.WriteLine(awaitedReturn.Greeting);
        }

        public async Task CalcAdd(CalcAddRequest request)
        {
            var content = ToJsonContent(request);

            var response = await this.httpClient.PostAsync($"{this.BaseUrl}/api/v1/calc/add", content);

            var awaitedReturn = await Output<CalcAddResponse>(response);

            // Output
            Console.WriteLine(awaitedReturn.Result);
        }
    }
}
