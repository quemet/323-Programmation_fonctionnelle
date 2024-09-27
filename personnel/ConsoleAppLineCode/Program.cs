using System;
using System.Threading;

namespace ConsoleAppLineCode
{
    class Code
    {
        public int linesOfCode { get; set; }

        public Code(int code)
        {
            linesOfCode = code;
        }
    }

    internal class Program
    {
        static int linesOfCode = 9210;
        static Random random = new Random();
        static Code code = new Code(9210);

        static void Main(string[] args)
        {
            Console.WriteLine($"Opening shop with {code.linesOfCode} lines in our program");
            Thread thread1 = new Thread(Bob);
            Thread thread2 = new Thread(Alice);

            // Start both threads
            thread1.Start();
            Thread.Sleep(300); // Alice starts her day a bit later
            thread2.Start();

            // Wait until both threads terminate
            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Closing shop with {code.linesOfCode} lines in our program");
            Console.ReadLine();
        }

        static void Bob()
        {
            int workingHours = 0;

            while (workingHours < 9) // He has a 9-hours day ahead of him
            {
                Thread.Sleep(1000); // Bob works for "1 hour"
                workingHours++;
                int BobProduction = random.Next(10, 50);
                Console.WriteLine($"Bob commits {BobProduction} lines of code.");
                code.linesOfCode += BobProduction;
            }
            Console.WriteLine($"Bob checks out, he claims the program has now {code.linesOfCode} lines");
        }

        // Method to be executed by thread2 - increments by 2 every 3 seconds
        static void Alice()
        {
            int workingHours = 0;
            while (workingHours < 7) // She has a 7-hours day ahead of her
            {
                Thread.Sleep(1000); // Alice works for "1 hour"
                workingHours++;
                int AliceProduction = random.Next(20, 80);
                Console.WriteLine($"Alice commits {AliceProduction} lines of code.");
                code.linesOfCode += AliceProduction;
            }
            Console.WriteLine($"Alice checks out, she claims the program has now {code.linesOfCode} lines");
        }
    }
}
