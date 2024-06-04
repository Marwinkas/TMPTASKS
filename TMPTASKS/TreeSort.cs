namespace TMPTASKS
{
    public class TreeSort
    {
        public TreeSort(char data)
        {
            Data = data;
        }

        public char Data { get; set; }

        public TreeSort Left { get; set; }

        public TreeSort Right { get; set; }
        public void Insert(TreeSort node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }
        public char[] Transform(List<char> elements = null)
        {
            if (elements == null)
            {
                elements = new List<char>();
            }

            if (Left != null)
            {
                Left.Transform(elements);
            }

            elements.Add(Data);

            if (Right != null)
            {
                Right.Transform(elements);
            }

            return elements.ToArray();
        }
        static char[] Sort(char[] array)
        {
            var treeNode = new TreeSort(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeSort(array[i]));
            }

            return treeNode.Transform();
        }
        public static void Output()
        {
            char[] array = ReverseString.Get(StringManager._text).ToCharArray();
            Console.WriteLine("Отсортированная строка методом сортировкой дерева: " + new string(Sort(array)));
        }
    }
}
