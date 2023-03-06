using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SendSMS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                string phoneNumber = "+1234567890"; // Your Phone Number
                string message = "Hello, this is a test message from TextBelt.";
                string key = "textbelt";

                var data = new
                {
                    number = phoneNumber,
                    message = message,
                    key = key
                };

                StringContent body = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://textbelt.com/text", body);

                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            Console.ReadLine();
        }
    }
}


