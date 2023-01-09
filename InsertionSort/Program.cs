internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = new int[] { 4, 8, 1, 6, 0, 3, 2, 7, 9, 5 };
        InsertionSort(numbers);
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
    }
    //Слева у нас уже есть часть элементов, которые отсортированы по порядку.
    //А справа, элемент, которые только хотим отсортировать.
    //Мы берём очередную элемент и помещаем ("вставляем") в уже отсортированную часть.
    //Вставляем элемент, найдя ему соответсвующее место
    public static void InsertionSort(int[] arr)
    {
        int index;
        int currentNumber;
        for (int i = 0; i < arr.Length; i++)
        {
            index = i;
            currentNumber = arr[i];
            while (index > 0 && currentNumber < arr[index - 1])
            {
                arr[index] = arr[index - 1];
                index--;
            }
            arr[index] = currentNumber;
        }
    }
}