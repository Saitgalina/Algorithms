internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = new int[] { 4, 8, 1, 6, 0, 3, 2, 7, 9 ,5};
        BubbleSort(numbers);
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
    }
    // Алгоритм заключается в циклических проходах по массиву,
    // за каждый проход элементы массива попарно сравниваются и,
    // если их порядок не правильный, то осуществляется обмен.
    // Обход массива повторяется до тех пор, пока массив не будет упорядочен.
    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length-1-i; j++)
            {
                if (arr[j] > arr[j+1])
                {
                    (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                }
            }
        }
    }

    public static void ManyDirectionalMerge(string pathToSort)//многопутевое слияние
    {
        var helpFiles = new List<string>();
        using (var reader = new StreamReader(pathToSort))
        {
            uint name = 0;              // Имя файлов
            int? num = null;            // Текущее число из исходника
            Func<int> readNum = () =>
            {
                if (num == null)
                    num = int.Parse(reader.ReadLine());
                return num.Value;
            };
            // Заполняем файлы сериями
            do
            {
                int? lastNum = null;
                helpFiles.Add($"{name}.txt");
                using (var writer = new StreamWriter($"{name}.txt"))
                {
                    name++;
                    while (!reader.EndOfStream && (lastNum == null || lastNum < readNum()))
                    {
                        writer.WriteLine(readNum());
                        lastNum = readNum();
                        num = null;         // Говорим функции выше, что мы приняли число
                    }
                }
            } while (!reader.EndOfStream);
        }

        var readers = new List<StreamReader>();
        for (int i = 0; i < helpFiles.Count; i++)
            readers.Add(new StreamReader(helpFiles[i]));

        var dict = new Dictionary<StreamReader, int>();

        File.Create(pathToSort).Close();
        using (var writer = new StreamWriter(pathToSort))
        {
            while (readers.Count > 0)
            {
                foreach (var reader in readers.ToArray())       // Проходимся во всем ридерам и сдвигаем указатель, где взяли значение. Также удаляем пустые ридеры
                {
                    if (!dict.ContainsKey(reader))
                    {
                        if (reader.EndOfStream)
                        {
                            reader.Close();
                            readers.Remove(reader);
                        }
                        else
                        {
                            dict.Add(reader, int.Parse(reader.ReadLine() ?? throw new Exception()));
                        }
                    }
                }
                if (dict.Count > 0)     // Находим мин. элемент в словаре, записываем в ответ и удаляем из словаря
                {
                    var min = dict.MinBy(x => x.Value);
                    dict.Remove(min.Key);
                    writer.WriteLine(min.Value);
                }
            }
        }
        foreach (var name in helpFiles)
            File.Delete(name);
    }
}
