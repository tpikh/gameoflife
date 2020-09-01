using System;

namespace GameOfLife
{
    class Generation
    {
        private readonly int boardSize;

        private Cell[,] state;
        public Cell[,] State => state;
        public int BoardSize => boardSize;

        public Generation(int boardSize)
        {
            this.boardSize = boardSize;
            this.state = new Cell[boardSize, boardSize];
        }

        public Generation(int boardSize, Cell[,] generationState)
        {
            this.boardSize = boardSize;
            this.state = generationState;
        }


        public void NextGeneration()
        {
            var nextGen = new Cell[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    var aliveNeighbors = CountNeighbors(i, j);
                    nextGen[i, j] = GetNextCellState(i, j, aliveNeighbors);
                }
            }

            state = nextGen;
        }

        private int CountNeighbors(int i, int j)
        {
            var aliveNeighbors = 0;

            for (int k = Math.Max(0, i - 1); k <= Math.Min(boardSize - 1, i + 1); k++)
            {
                for (int l = Math.Max(0, j - 1); l <= Math.Min(boardSize - 1, j + 1); l++)
                {
                    if (k == i && l == j)
                    {
                        continue;
                    }
                    var neighbor = State[k, l];
                    if (neighbor == Cell.Alive)
                    {
                        aliveNeighbors++;
                    }
                }
            }

            return aliveNeighbors;
        }

        private Cell GetNextCellState(int i, int j, int aliveNeighbors)
        {
            if (State[i, j] == Cell.Alive && aliveNeighbors < 2)
            {
                return Cell.Dead;
            }
            else if (State[i, j] == Cell.Alive && (aliveNeighbors == 2 || aliveNeighbors == 3))
            {
                return Cell.Alive;
            }
            else if (State[i, j] == Cell.Alive && aliveNeighbors > 3)
            {
                return Cell.Dead;
            }
            else if (State[i, j] == Cell.Dead && aliveNeighbors == 3)
            {
                return Cell.Alive;
            }

            return Cell.Dead;
        }
    }
}
