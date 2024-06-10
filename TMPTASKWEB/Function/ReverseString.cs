namespace TMPTASKWEB.Function
{
    public class ReverseString
    {
        public static bool IsEvenString(string? text)
        {
            if (text.Length % 2 != 0) return false;
            else return true;
        }
        public static string Reverse(string? text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
        public static string? Get(string? text)
        {
            if (IsEvenString(text))
            {
                string? firsttext = text.Substring(0, text.Length / 2);
                string? secondtext = text.Substring(text.Length / 2);
                return Reverse(firsttext) + Reverse(secondtext);
            }
            else
            {
                return Reverse(text) + text;
            }
        }

    }
}
