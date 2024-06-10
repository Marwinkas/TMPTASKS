namespace TMPTASKWEB.Function
{
    public class QuickSort
    {
        static void Swap(ref char x, ref char y)
        {
            char t = x;
            x = y;
            y = t;
        }
        static int Partition(char[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }
            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static char[] Sort(char[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            int pivotIndex = Partition(array, minIndex, maxIndex);
            Sort(array, minIndex, pivotIndex - 1);
            Sort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        public static string Output()
        {
            char[] array = ReverseString.Get(StringManager._text).ToCharArray();
            Sort(array, 0, array.Length - 1);
            return "Быстрая Сортировка: " + new string(array);
        }
    }
}
