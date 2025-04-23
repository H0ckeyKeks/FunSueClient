using FunSueClient;
using FunSueClient.Model;

namespace FunSueClientConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Client funSueClient = new Client("http://192.168.178.70:8000");
            await funSueClient.Greeting("Jasmin");

            var request = new CalcAddRequest()
            {
                Number1 = 1,
                Number2 = 2
            };

            await funSueClient.CalcAdd(request);

        }
    }
}
