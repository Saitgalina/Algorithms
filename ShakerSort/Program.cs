internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = new int[] { 4, 8, 1, 6, 0, 3, 2, 7, 9, 5 };
        ShakerSort(numbers);
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
    }
    // Алгоритм представляет собой одну из разновидностей "сортировки пузырьком". 
    // Основное отличие заключается в том, что в классической сортировке пузырьком происходит однонаправленное движение элементов 
    // (слева — направо), в то время, как сортировке перемешиванием мы сначала проходим слева-направл, а затем справа-налево.
    public static void ShakerSort(int[] arr)
    {
        int leftMark = 1;
        int rightMart = arr.Length - 1;
        while (leftMark <= rightMart)
        {
            for (int i = leftMark; i <= rightMart; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }
            }
            rightMart--;
            for (int i = rightMart; i >= leftMark; i--)
            {
                if (arr[i] < arr[i - 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }
            }
            leftMark++;
        }
    }
}