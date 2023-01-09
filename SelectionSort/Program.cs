internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = new int[] { 4, 8, 1, 6, 0, 3, 2, 7, 9, 5 };
        SelectionSort(numbers);
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
        
    }
    // Находим минимальный элемент в массиве.
    // Меняем местами минимальный и первый элемент местами.
    // Ищем минимальный элемент в неотсортированной части массива, т.е., начиная уже со второго элемента массива.
    // Меняем местами второй элемент массива и найденный минимальный.
    // Ищем минимальный элемент в массиве, начиная с третьего, меняем местами третий и минимальный элементы.
    // Продолжаем алгоритм до тех пор пока не дойдем то конца массива.
    public static void SelectionSort(int[] arr)  //Сортировка Выбором
    {
       for (int i = 0; i < arr.Length; i++)
       {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
       }        
    }
}