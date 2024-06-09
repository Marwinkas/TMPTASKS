using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMPTASKS
{
    public class GetRandomValue
    {
        public static void Get(string? text, int min,int max)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"http://www.randomnumberapi.com/api/v1.0/random?min={min}&max={max}");
            int random = 0;
            try
            {
                var result = client.GetAsync(client.BaseAddress).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                json = json.Remove(0, 1);
                json = json.Remove(json.Length - 2, 1);
                random = int.Parse(json);
            }
            catch (Exception e) {
                Random r = new Random();
                random = r.Next(min, max);
                Console.WriteLine(e);
            }

            Console.WriteLine(@"Номер удалённой буквы: " + (random + 1));
            Console.WriteLine("Измененная строка: " + text.Remove(random, 1));
        }
    }
}
