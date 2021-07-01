using System.Collections.Generic;

namespace ConwaysGameOfLifeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGameOfLife gameOfLife = new();

            gameOfLife.PlayGame(50, new List<int>() { 10, 60, 110, 109, 58 });
        }
    }
}
