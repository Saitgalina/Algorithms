internal class Program
{
    private static void Main(string[] args)
    {
        MyHashTable<int,string> ht = new MyHashTable<int,string>(10);
        string[] names = new string[] {"Anna","Bob","Linda", "Monica", "Alex", "Polina", "Nicolay","Anna2", "Georiy","Diana","Sasha"};
        for (int i = 0; i < names.Length; i++)
        {
            ht.Insert(i, names[i]);
        }
        Console.ReadLine();
    }
   

    public class MyHashTable<TKey, TValue>  // хеш таблица с разрешением коллизий методом цепочек
    {
        private readonly List<Cell<TKey, TValue>>[] table; 

        public MyHashTable(int size)
        {
            table = new List<Cell<TKey, TValue>>[size];
            for (var i = 0; i < table.Length; i++)  
                table[i] = new List<Cell<TKey, TValue>>();
        }

        public void Insert(TKey key, TValue value)
        {
            if (IsHaveKey(key))     
                throw new Exception("Этот уключ уже есть");
            var hash = GetHash(key);
            table[hash].Add(new Cell<TKey, TValue>(key, value));
        }

        public TValue Search(TKey key) 
        {
            var hash = GetHash(key);
            var cells = table[hash];
            foreach (var item in cells)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }

            throw new Exception("Этого ключа нет в таблице");
        }

        public void Remove(TKey key) 
        {
            if (!IsHaveKey(key))
                throw new Exception("Этого ключа нет в таблице");
            var hash = GetHash(key);
            var cells = table[hash];
            for (var i = 0; i < cells.Count; i++)
            {
                if (cells[i].Key.Equals(key))
                    cells[i] = null;
            }
        }

        private int GetHash(TKey key)   
        {
            var value = key.GetHashCode();
            return value  % table.Length;
        }

        public bool IsHaveKey(TKey key)   
        {
            var hash = GetHash(key);
            var cells = table[hash];
            foreach (var item in cells)
                if (item.Key?.Equals(key) ?? false)
                    return true;

            return false;
        }
    }

    public class Cell<TKey, TValue>   //чисто ячейка
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public Cell(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}