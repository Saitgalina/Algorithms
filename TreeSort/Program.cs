internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = new int[] { 4, 8, 1, 6, 0, 3, 2, 7, 9, 5 };
        
        Console.WriteLine("Inisial Array: {0}", string.Join(" ", numbers));

        Console.WriteLine("Sorted Array: {0}", string.Join(" ", TreeNode.TreeSort(numbers)));
    }
    //Все элементы вставляются в двоичное дерево поиска.
    //После того, как все элементы вставлены достаточно обойти дерево в глубину и получить отсортированный массив.

    //Бинарное дерево поиска — это бинарное дерево, обладающее дополнительными свойствами:
    //значение левого потомка меньше значения родителя,
    //а значение правого потомка больше значения родителя для каждого узла дерева.

    // Сортировка двоичным деревом. Сложность O(n*log2 n). Элементы располагаются деревом, слева < число, справа >= число
    public class TreeNode
    {
        int Data { get; set; }
        TreeNode Left { get; set; }
        TreeNode Right { get; set; }
        public TreeNode(int data)
        {
            Data = data;
        }

        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if(Left == null)
                    Left = node;
                else
                    Left.Insert(node);
            }
            else
            {
                if(Right == null)
                    Right = node;
                else
                    Right.Insert(node);
            }
        }
        public int[] Transform(List<int> elements = null)
        {
            if(elements == null)
                elements = new List<int>();
            if(Left != null)
                Left.Transform(elements);
            elements.Add(Data);
            if(Right != null)
                Right.Transform(elements);
            return elements.ToArray();
        }
        public static int[] TreeSort(int[] arr)
        {
            var treeNode = new TreeNode(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                treeNode.Insert(new TreeNode(arr[i]));
            }
            return treeNode.Transform();
        }
    }
}