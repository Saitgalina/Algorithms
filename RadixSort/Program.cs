internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };
        RadixSort(arr);
        foreach (int i in arr)
        {
            Console.WriteLine(i);
        }
    }
    //При поразрядной сортировке (сортировке с выравниванием по младшему разряду, направо, к единицам)
    //Значения сначала сортируются по единицам, затем сортируются по десяткам,
    //сохраняя отсортированность по единицам внутри десятков,
    //затем по сотням, сохраняя отсортированность по десяткам и единицам внутри сотен, и т. п.
    public static void RadixSort(int[] arr)
    {
        int max = GetMax(arr);

        for (int rank = 1; max / rank > 0; rank *= 10)
        {
            RankSort(arr, rank);
        }
    }
    public static void RankSort(int[] arr, int rank)
    {
        int[] output = new int[arr.Length];
        int[] count = new int[10];

        for (int i = 0; i < arr.Length; i++)
        {
            count[(arr[i] / rank) % 10]++;
        }
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }
        for (int i = arr.Length-1; i >= 0; i--)
        {
            output[count[(arr[i] / rank) % 10] - 1] = arr[i];
            count[(arr[i] / rank) % 10]--;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = output[i];
        }
    }
    public static int GetMax(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i]>max)
                max = arr[i];
        }return max;
    }    
}