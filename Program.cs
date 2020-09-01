using System;
using System.Text;
using System.Threading;
using GameOfLife.Output;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var init = new GenerationInitializer();
            var gen = init.Init();


            var output = new ConsoleBoardOutput();
            output.PrintBoard(gen);

            Console.ReadKey();
            bool run = true;
            while (run)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    run = HandleKey(key, ref run);
                }

                gen.NextGeneration();
                output.PrintBoard(gen);

                Thread.Sleep(200);


            }
        }

        private static bool HandleKey(ConsoleKeyInfo key, ref bool run)
        {
            switch (key.Key)
            {
                case ConsoleKey.Spacebar:
                    Console.Read();
                    break;
                case ConsoleKey.Escape:
                    run = false;
                    break;
            }

            return run;
        }
    }
}



