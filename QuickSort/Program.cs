internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = new int[] { 4, 8, 1, 6, 0, 3, 2, 7, 9, 5 };
        QuickSort(numbers, 0, numbers.Length - 1);
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
    }
    //Быстрая сортировка выбирает опорный элемент(последний в массиве) и разделяет остальные элементы относительно опорного.
    //Элементы меньшие опорного располагаются до, большие после.
    //После подобного разбиения опорный элемент занимает свое конечное положение.
    //Далее получившиеся подмассивы подвергаются таким же действиям. 
    public static void QuickSort(int[] arr, int start,int end)
    {
        if (start >= end)
            return;
        int pivot = Partition(arr, start, end);
        QuickSort(arr, start, pivot-1);
        QuickSort(arr,pivot+1, end);
    }
    public static int Partition(int[] arr, int start, int end)
    {
        int pivot = arr[end];
        int PIndex = start;
        for (int i = start; i < end; i++)
        {
            if (arr[i] <= pivot)
            {
                (arr[i], arr[PIndex]) = (arr[PIndex], arr[i]);
                PIndex++;
            }
        }
        (arr[end], arr[PIndex]) = (arr[PIndex], arr[end]);
        return PIndex;
    }
}