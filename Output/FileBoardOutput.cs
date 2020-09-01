using System.IO;
using System.Text;

namespace GameOfLife.Output
{
    class FileBoardOutput : IBoardOutput
    {
        public void PrintBoard(Generation generation)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(generation.BoardSize.ToString());
            for (int i = 0; i < generation.BoardSize; i++)
            {
                for (int j = 0; j < generation.BoardSize; j++)
                {
                    output.Append((int)generation.State[i, j]);
                }

                output.Append('\n');
            }

            using var fs = File.Open("state.txt", FileMode.Create);
            var bytes = Encoding.ASCII.GetBytes(output.ToString());
            fs.Write(bytes);
        }
    }
}