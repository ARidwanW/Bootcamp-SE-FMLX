class Program
{
    static void Main()
    {
        Console.Write("Input Number: ");
        int inputUser = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i <= inputUser; i++)
        {
            if (i == 0)
            {
                Console.Write(i + " ");
            }
            else if (i % 3 == 0)
            {
                if (i % 5 == 0)
                {
                    Console.Write("foobar ");
                }
                else
                {
                    Console.Write("foo ");
                }
            }
            else if (i % 5 == 0)
            {
                Console.Write("bar ");
            }
            else
            {
                Console.Write(i + " ");
            }
        }
    }
}
