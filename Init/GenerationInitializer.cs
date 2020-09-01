using System;
using System.IO;

namespace GameOfLife.Init
{
    class GenerationInitializer : IGenerationInitializer
    {
        public Generation Init()
        {
            using var file = new StreamReader(File.OpenRead("state.txt"));
            var size = Convert.ToInt32(file.ReadLine());

            Cell[,] state = new Cell[size, size];

            for (int i = 0; i < size + 1; i++)
            {
                for (int j = 0; j < size + 1; j++)
                {
                    var ch = (char) file.Read();
                    if (ch != 49 && ch != 48)
                    {
                        continue;
                    }
                    state[i, j] = (Cell) int.Parse(ch.ToString());
                }
            }

            return new Generation(size, state);
        }
    }
}