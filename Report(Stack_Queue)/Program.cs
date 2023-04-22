namespace Report_Stack_Queue_
{
    internal class Program
    {
        void Queue()
        {
            Queue<int> queue = new Queue<int>();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("================Stack================");
            Stack2<int> stack = new Stack2<int>();

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }
            Console.WriteLine("================Stack_Peek================");
            Console.WriteLine(stack.Peek());
            Console.WriteLine("================Stack_Pop================");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }


            Console.WriteLine("================Queue================");
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 5; i++) queue.Enqueue(i);
            Console.WriteLine("================Queue_Peek================");
            Console.WriteLine(queue.Peek());
            Console.WriteLine("================Queue_Dequeue================");
            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());
        }
    }
}