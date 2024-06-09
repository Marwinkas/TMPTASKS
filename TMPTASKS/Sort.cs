namespace TMPTASKS
{
    public class Sort
    {
        public static void OutputSortString()
        {
            Console.WriteLine("Выберите Сортировку: ");
            Console.WriteLine("0 - Быстрая Сортировка");
            Console.WriteLine("1 - Сортировка Деревом");
            Console.WriteLine(">2 Не сортировать");
            string text = Console.ReadLine();
            int sort;
            if (!string.IsNullOrWhiteSpace(text)) int.TryParse(text, out sort);
            else sort = -1;
            if (sort == 0) QuickSort.Output();
            else if (sort == 1) TreeSort.Output();
        }

    }
}
