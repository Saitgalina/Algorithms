internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public class MyHashTable<TKey, TValue>
    {
        private readonly Cell<TKey, TValue>[] table;

        public MyHashTable(int size)
        {
            table = new Cell<TKey, TValue>[size];
        }

        public void Insert(TKey key, TValue value)
        {
            if (IsHaveKey(key))
                throw new Exception("This key already exists");
            var hash = GetHash(key);
            table[hash] = new Cell<TKey, TValue>(key, value);
        }

        public TValue Search(TKey key)
        {
            if (!IsHaveKey(key))
                throw new Exception("This key does not exist");

            var hash = GetHash(key);
            return table[hash].Value;
        }

        public void Remove(TKey key)
        {
            if (!IsHaveKey(key))
                throw new Exception("This key does not exist");

            var hash = GetHash(key);
            table[hash] = null;
        }

        private int GetHash(TKey key)
        {
            var hash = key.GetHashCode() % table.Length;
            //var er = Convert.ToInt32(key) / 2;
            if (table[hash] == null)
                return hash;
            if (!table[hash].Key.Equals(key))
            {
                while (table[hash] != null)
                {
                    hash++;
                    if (table[hash] == null)
                        return hash;
                    if (table[hash].Key.Equals(key))
                        return hash;
                }
            }

            return hash;
        }

        public bool IsHaveKey(TKey key)
        {
            foreach (var item in table)
            {
                if (item != null && item.Key.Equals(key))
                    return true;
            }

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