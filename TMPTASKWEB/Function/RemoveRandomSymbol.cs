using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMPTASKWEB.Function
{
    public class RemoveRandomSymbol
    {
        public static string[] Get(string url)
        {
            string? text = ReverseString.Get(StringManager._text);
            int max = text.Length;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url + $"?min=0&max={max}");
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
                random = r.Next(0, max);
                Console.WriteLine(e);
            }
            string[] output = new string[2];
            output[0] = @"Номер удалённой буквы: " + (random + 1);
            output[1] = "Измененная строка: " + text.Remove(random, 1);
            return output;
        }
    }
}
