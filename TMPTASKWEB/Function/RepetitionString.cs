using System.Text;
using System.Text.RegularExpressions;
namespace TMPTASKWEB.Function
{
    public class RepetitionString
    {
        public static string[] OutputSymbol()
        {
            string text = ReverseString.Get(StringManager._text);
            List<String> outputstring = new List<string>();
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
                outputstring.Add( $"{c} - {k}");
            }
            string[] tempoutput = outputstring.ToArray();
            return tempoutput;
        }
        public static string[] OutputSymbol(string text)
        {
            List<String> outputstring = new List<string>();
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
                outputstring.Add($"{c} - {k}");
            }
            string[] tempoutput = outputstring.ToArray();
            return tempoutput;
        }
        public static string OutputVowelSubstring()
        {
            string text = ReverseString.Get(StringManager._text);
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
            return text.Substring(startsubstring, endsubstring);
        }
        public static string OutputVowelSubstring(string text)
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
            return text.Substring(startsubstring, endsubstring);
        }
    }
}
