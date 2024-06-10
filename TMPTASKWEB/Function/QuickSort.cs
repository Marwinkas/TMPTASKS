namespace TMPTASKWEB.Function
{
    public class QuickSort
    {
        public static void Swap(ref char x, ref char y)
        {
            char t = x;
            x = y;
            y = t;
        }
        public static int Partition(char[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }
            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            Console.Write(pivot);
            return pivot;
        }
        public static char[] Sort(char[] array, int minIndex, int maxIndex)
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
            
            return "Быстрая Сортировка: " + new string(Sort(array, 0, array.Length - 1));
        }
    }
}
