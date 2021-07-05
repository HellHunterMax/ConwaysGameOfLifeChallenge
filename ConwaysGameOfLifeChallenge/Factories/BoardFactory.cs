using ConwaysGameOfLifeChallenge.Models;
using System.Collections.Generic;

namespace ConwaysGameOfLifeChallenge.Factories
{
    public class BoardFactory
    {
        /// <summary>
        /// Creates a board with the chosen cells alive.
        /// </summary>
        /// <param name="size">The With and Hight of the board.</param>
        /// <param name="numbers">The Alive Cells should be given here starting from 0</param>
        /// <returns></returns>
        public Board Create(int size, IList<int> numbers, bool useNow)
        {
            int totalCells = size * size;
            Board board = new() { Size = size, UseNow = useNow };

            for (int i = 0; i < totalCells; i++)
            {
                Cell cell = new Cell()
                {
                    Id = i,
                    Row = (i / size),
                    Collumn = (i % size),
                    IsAlive = numbers.Contains(i) ? true : false
                };

                board.Cells.Add(cell);

            }
            for (int i = 0; i < board.Cells.Count; i++)
            {
                Cell cell = board.Cells[i];
                AddNeighbours(cell, board);
            }

            return board;
        }

        private static void AddNeighbours(Cell cell, Board board)
        {
            int number = cell.Id;
            int size = board.Size;
            int[] neighbours = new int[]
            {
                number - size - 1,
                number - size,
                number - size + 1,
                number -1,
                number +1,
                number + size - 1,
                number + size,
                number + size + 1
            };

            bool hasTop = cell.Row == 0 ? false : true;
            bool hasBottom = cell.Row == size - 1 ? false : true;
            bool hasLeft = cell.Collumn == 0 ? false : true;
            bool hasRight = cell.Collumn == size - 1 ? false : true;

            if (hasLeft && hasTop)
            {
                cell.Neighbours.Add(board.Cells[neighbours[0]]);
            }
            if (hasTop)
            {
                cell.Neighbours.Add(board.Cells[neighbours[1]]);
            }
            if (hasTop && hasRight)
            {
                cell.Neighbours.Add(board.Cells[neighbours[2]]);
            }
            if (hasLeft)
            {
                cell.Neighbours.Add(board.Cells[neighbours[3]]);
            }
            if (hasRight)
            {
                cell.Neighbours.Add(board.Cells[neighbours[4]]);
            }
            if (hasLeft && hasBottom)
            {
                cell.Neighbours.Add(board.Cells[neighbours[5]]);
            }
            if (hasBottom)
            {
                cell.Neighbours.Add(board.Cells[neighbours[6]]);
            }
            if (hasRight && hasBottom)
            {
                cell.Neighbours.Add(board.Cells[neighbours[7]]);
            }
        }
    }
}
