using System.Text.RegularExpressions;

namespace TMPTASKWEB.Function
{
    public class StringManager
    {
        public static string? _text = string.Empty;
        static char[] _error = new char[0];
        public static bool IsValid(string? text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;

            _error = new char[text.Length];
            char[] array = text.ToCharArray();
            bool haserror = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (!Regex.IsMatch(array[i].ToString(), @"[a-z]"))
                {
                    _error[i] = array[i];
                    haserror = true;
                }
            }
            if (haserror) return false;
            else return true;
        }
        public static string ErrorMessage()
        {
            string errormasage = "В тексте есть недопустимые символы\nНедопустимые символы: \n";
            for (int i = 0; i < _error.Length; i++)
            {
                if (_error[i] != 0)
                {
                    errormasage = errormasage + $"Символ {i}: {_error[i]}\n";
                }
            }
            return errormasage;
        }
    }
}
