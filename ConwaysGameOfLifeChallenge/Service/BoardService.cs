using ConwaysGameOfLifeChallenge.Models;
using System.Linq;

namespace ConwaysGameOfLifeChallenge.Service
{
    public static class BoardService
    {

        public static void AgeOne(ref Board board1, ref Board board2)
        {
            Board oldBoard = board1.UseNow ? board1 : board2;
            Board newBoard = board1.UseNow ? board2 : board1;

            for (int i = 0; i < oldBoard.Cells.Count; i++)
            {
                Cell cell = oldBoard.Cells[i];
                var numberOfAliveNeighbours = cell.Neighbours.Count(x => x.IsAlive == true);

                newBoard.Cells[i].IsAlive = IsAliveOrDead(cell.IsAlive, numberOfAliveNeighbours);
            }
        }

        private static bool IsAliveOrDead(bool IsAlive, int numberOfAliveNeighbours)
        {
            if (IsAlive)
            {
                if (numberOfAliveNeighbours < 2)
                {
                    IsAlive = false;
                }
                else if (numberOfAliveNeighbours > 3)
                {
                    IsAlive = false;
                }
            }
            else
            {
                if (numberOfAliveNeighbours == 3)
                {
                    IsAlive = true;
                }
            }

            return IsAlive;
        }
    }
}
