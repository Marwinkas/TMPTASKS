namespace TMPTASKS
{
    public class ReverseString
    {
        static bool IsEvenString(string? text)
        {
            if (text.Length % 2 != 0) return false;
            else return true;
        }
        static string Reverse(string? text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
        public static string? Get(string? text)
        {
            if (IsEvenString(text))
            {
                string? firsttext = text.Substring(0, text.Length - text.Length / 2);
                string? secondtext = text.Substring(text.Length - text.Length / 2);
                return Reverse(firsttext) + Reverse(secondtext);
            }
            else
            {
                return Reverse(text) + text;
            }
        }

    }
}
