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
            Stack2<int> stack = new Stack2<int>();

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack.Peek());

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

        }
    }
}