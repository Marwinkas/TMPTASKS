using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static string? _text = string.Empty;
    static char[] _errorchar = new char[0];
    static bool IsValidString(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return false;

        _errorchar = new char[text.Length];
        char[] array = text.ToCharArray();
        bool haserror = false;

        for(int i = 0; i < array.Length; i++)
        {
            if (!Regex.IsMatch(array[i].ToString(), @"[a-z]"))
            {
                _errorchar[i] = array[i];
                haserror = true;
            }
        }
        if(haserror) return false;
        else return true;
    }
    static bool IsEvenString(string? text)
    {
        if (text.Length % 2 != 0) return false;
        else return true;
    }
    static string ReverseString(string? text)
    {
        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
    static void ErrorMessage()
    {
        Console.WriteLine("В тексте есть недопустимые символы");
        Console.WriteLine("Недопустимые символы: ");
        for (int i = 0; i < _errorchar.Length; i++)
        {
            if (_errorchar[i] != 0)
            {
                Console.WriteLine($"Символ {i}: {_errorchar[i]}");
            }
        }
    }
    static void OutputRepetitionSymbol(string? text)
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
    static void SplitandReverseString()
    {
        if (IsEvenString(_text))
        {
            string? firsttext = _text.Substring(0, _text.Length - _text.Length / 2);
            string? secondtext = _text.Substring(_text.Length - _text.Length / 2);
            string? reversetext = ReverseString(firsttext) + ReverseString(secondtext);
            Console.WriteLine("Измененная строка: " + reversetext);
            OutputRepetitionSymbol(reversetext);
        }
        else
        {
            string? reversetext = ReverseString(_text) + _text;
            Console.WriteLine("Измененная строка: " + reversetext);
            ReverseString(ReverseString(_text));
            OutputRepetitionSymbol(reversetext);
        }
    }
    static void OutputReverseString()
    {
        Console.WriteLine("Введите строку: ");
        _text = Console.ReadLine();

        if (!IsValidString(_text)) ErrorMessage();
        else SplitandReverseString();
    }
    static void Main()
    {
        OutputReverseString();
        Console.ReadKey(true);
    }
}