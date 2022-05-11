using System.Collections.Generic;

namespace _8Queens
{
    public class MainViewModel 
    {
        const int MAX = 8;

        public int[,] Board;
        public List<List<Cell>> CellBoard = new();
        
        //ctor - builds the chessboard
        public MainViewModel()
        {
            CellBoard = new List<List<Cell>>(MAX);

            for (int i = 0; i < MAX; i++)
            {
                CellBoard.Add(new List<Cell>(MAX));

                for (int j = 0; j < MAX; j++)
                {
                    CellBoard[i].Add(new Cell());
                }
            }

            Board = new int[MAX, MAX];
        }
        public bool Solve(int col)
        {
            //if all queens are placed return true
            if (col >= MAX)
            {
                return true;
            }

            for (int row = 0; row < MAX; row++)
            {
                if (IsSafe(row, col))
                {
                    Board[row, col] = 1;
                    CellBoard[row][col].Value = 1;

                    if (Solve(col + 1))
                    {
                        return true;
                    }

                    Board[row, col] = 0;
                    CellBoard[row][col].Value = 0;
                }
            }
            return false;
        }

        bool IsSafe(int row, int col)
        {
            //from the left until the current col
            for (int i = 0; i < col; i++)
            {
                if (Board[row, i] == 1)
                {
                    return false;
                }
            }

            //upper diagonal
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (Board[i, j] == 1)
                {
                    return false;
                }
            }

            //lower diagonal
            for (int i = row, j = col; i < MAX && j >= 0; i++, j--)
            {
                if (Board[i, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

