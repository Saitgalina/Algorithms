internal class Program
{
    private static void Main(string[] args)
    {
        MyStack<string> stack = new MyStack<string>();
        stack.Push("Anna");
        stack.Push("Nick");
        stack.Push("Alex");
        stack.Print();
        Console.WriteLine();
        Console.WriteLine(stack.Peek());
        Console.WriteLine();
        stack.Pop();
        stack.Print();
        Console.ReadLine();
    }
    public class MyStack<T>
    {
        MyDoubleLinkedList<T> stack;
        int top;
        int size;
        public MyStack()//создание стека
        {
            stack = new MyDoubleLinkedList<T>();
            top = -1;
        }
        public void Push(T elem)//добавить элемент (в начало двусвязного списка)
        {
            ++this.top;
            this.stack.AddToTop(elem);
            size++;
        }
        public void Delete()//удалить последний помещеный элемент
        {
            this.stack.Head = this.stack.Head.Next;
            this.size--;
        }
        public T Pop()//Вытащить последний помещеный элемент
        {
            T elem = this.stack.Head.Data;
            this.Delete();
            this.top--;
            return elem;
        }
        public void Print()
        {
            this.stack.Print();
        }
        public T Peek()//посмотреть первый элемент стека без удаления
        {
            return this.stack.Tail.Data;
        }
        public bool IsEmpty()
        {
            return this.top == -1;
        }

    }

    public class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Prev;
        public Node(T data, Node<T> next = null, Node<T> prev = null)
        {
            Data = data;
            Next = next;
            Prev = prev;
        }
    }
    public class MyDoubleLinkedList<T>
    {
        public Node<T>? Head;
        public Node<T>? Tail;
        int Size;

        public MyDoubleLinkedList()
        {
            Size = 0;
            Head = Tail = null;
        }
            
        public void AddToTheEnd(T data)
        {
            Node<T> node = new Node<T>(data);

            if(Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }
            Tail = node;
            Size++;
        }
        public void AddToTop(T data)
        {
            Node<T> node = new Node<T>(data);
            if(Head == null)
            {
                Head = node;
                Tail = node;
                Size++;
                return;
            }
            node.Next = Head;
            Head.Prev = node;
            Head = node;
            Size++;
        }
        public void RemoveFirst(T data)
        {
            if (Head == null || Size == 0)
                throw new Exception("Список пуст");
            else
            {
                Head = Head.Next;
            }
        }
        public void Print()
        {
            Node<T> current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        
    }
}