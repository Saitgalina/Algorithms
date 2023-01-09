using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        MyQueue<string> queue = new MyQueue<string>();
        queue.Add("Anna");
        queue.Add("Nick");
        queue.Add("Alex");
        queue.Print();
        Console.WriteLine();
        //Console.WriteLine(stack.Peek());
        //Console.WriteLine();
        //stack.Pop();
        //stack.Print();
        //Console.ReadLine();
    }
    public class MyQueue<T>
    {
        MyDoubleLinkedList<T> queue;
        int size = 0;

        public MyQueue()
        {
            queue = new MyDoubleLinkedList<T>();
        }
        public void Add(T data)
        {
            this.queue.AddToTheEnd(data);
            size++;
        }
        public T getFirst()
        {
            return this.queue.Head.Data;
        }
        public T getLast()
        {
            return this.queue.Tail.Data;
        }
        public void Print()
        {
            this.queue.Print();
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

            if (Head == null)
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
            if (Head == null)
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