using System;
using System.Text;

namespace GameOfLife.Output
{
    class ConsoleBoardOutput : IBoardOutput
    {
        public void PrintBoard(Generation generation)
        {
            StringBuilder output = new StringBuilder();
            Console.Clear();
            for (int i = 0; i < generation.BoardSize; i++)
            {
                for (int j = 0; j < generation.BoardSize; j++)
                {
                    output.Append(generation.State[i, j] == Cell.Alive ? "\u2588" : "\u2591");
                }

                output.Append('\n');
            }

            Console.Write(output);
        }
    }
}