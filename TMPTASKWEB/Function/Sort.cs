namespace TMPTASKWEB.Function
{
    public class Sort
    {
        public static void OutputSortString(int sort)
        {
            if (sort == 0) QuickSort.Output();
            else if (sort == 1) TreeSort.Output();
        }

    }
}
