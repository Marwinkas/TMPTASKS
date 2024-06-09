using System.Text.RegularExpressions;
namespace TMPTASKS
{
    public class StringManager
    {
        public static string? _text = string.Empty;
        static char[] _error = new char[0];
        static bool IsValid(string? text)
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
        static void ErrorMessage()
        {
            Console.WriteLine("В тексте есть недопустимые символы");
            Console.WriteLine("Недопустимые символы: ");
            for (int i = 0; i < _error.Length; i++)
            {
                if (_error[i] != 0)
                {
                    Console.WriteLine($"Символ {i}: {_error[i]}");
                }
            }
        }
        public static void Output()
        {
            Console.WriteLine("Введите строку: ");
            _text = Console.ReadLine();
            if (!IsValid(_text)) ErrorMessage();
            else
            {
                string text = ReverseString.Get(_text);
                Console.WriteLine("Измененная строка: " + ReverseString.Get(_text));
                RepetitionString.OutputSymbol(text);
                RepetitionString.OutputVowelSubstring(text);
                Sort.OutputSortString();
                GetRandomValue.Get(text, 0, text.Length - 1);
            }
        }
    }
}
