using System.Text;
using System.Text.RegularExpressions;
namespace TMPTASKS
{
    public class RepetitionString
    {
        public static void OutputSymbol(string? text)
        {
            StringBuilder temptext = new StringBuilder(text);
            for (int i = 0; i < temptext.Length; i++)
            {
                char c = temptext[i];
                int k = 1;
                for (int j = i + 1; j < temptext.Length; j++)
                {
                    if (c == temptext[j])
                    {
                        k++;
                        temptext.Remove(j, 1);
                        j--;
                    }
                }
                Console.WriteLine($"Символ {c} - {k} раз");
            }
        }
        public static void OutputVowelSubstring(string? text)
        {
            bool isvowelsubstring = false;
            bool isstart = false;
            int startsubstring = 0;
            int endsubstring = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (Regex.IsMatch(c.ToString(), @"[a,e,i,o,u,y]"))
                {
                    isvowelsubstring = !isvowelsubstring;
                }
                if (isvowelsubstring)
                {
                    if (i == 0) isstart = true;
                    if (startsubstring == 0 && !isstart) startsubstring = i;
                    else endsubstring = i - startsubstring + 2;
                }
            }
            Console.WriteLine("Наибольшая подстрока, которая начинается и заканчивается на гласную букву: " + text.Substring(startsubstring, endsubstring));
        }
    }
}
