using ConwaysGameOfLifeChallenge.Factories;
using ConwaysGameOfLifeChallenge.Models;
using ConwaysGameOfLifeChallenge.Service;
using System;
using System.Collections.Generic;

namespace ConwaysGameOfLifeChallenge
{
    public class PlayGameOfLife
    {
        /// <summary>
        /// Initiate playing the game, Set the BoardSize and the AliveNumbers and play 100 rounds.
        /// </summary>
        /// <param name="boardSize">This will be the height and width of the Playing field.</param>
        /// <param name="aliveNumbers">This will be the Alive cells at startup.</param>
        public void PlayGame(int boardSize, List<int> aliveNumbers)
        {
            BoardFactory boardFactory = new BoardFactory();

            Board board1 = boardFactory.Create(boardSize, aliveNumbers, true);
            Board board2 = boardFactory.Create(boardSize, aliveNumbers, false);

            for (int i = 0; i < 100; i++)
            {
                Console.Clear();
                switch (board1.UseNow)
                {
                    case true:
                        PrintBoard(board1);
                        break;
                    case false:
                        PrintBoard(board2);
                        break;
                }
                BoardService.AgeOne(board1, board2);
                board1.UseNow = !board1.UseNow;
                board2.UseNow = !board2.UseNow;
                Console.ReadKey();
            }
        }

        public static void PrintBoard(Board board)
        {
            int number = 0;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    char x = board.Cells[number].IsAlive ? 'X' : '_';
                    Console.Write(x);
                    number++;
                }
                Console.WriteLine();
            }
        }
    }
}
