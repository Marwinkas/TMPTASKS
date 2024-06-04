using System;
class Program
{
    static string? _text = string.Empty;
    static bool Stringiseven(string? text)
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
    static void SplitandReverseString()
    {
        Console.WriteLine("Введите строку: ");
        _text = Console.ReadLine();
        if (_text == null) return;
        if (Stringiseven(_text))
        {
            string? firsttext = _text.Substring(0, _text.Length - _text.Length / 2);
            string? secondtext = _text.Substring(_text.Length - _text.Length / 2);

            Console.WriteLine("Измененная строка: " + ReverseString(firsttext) + ReverseString(secondtext));
        }
        else Console.WriteLine("Измененная строка: " + ReverseString(_text) + _text);
    }
    static void Main()
    {
        SplitandReverseString();
        Console.ReadKey(true);
    }
}