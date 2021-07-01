using System.Collections.Generic;

namespace ConwaysGameOfLifeChallenge.Models
{
    public class Board
    {
        public int Size { get; set; }
        public bool UseNow { get; set; }
        public IList<Cell> Cells { get; set; } = new List<Cell>();
    }
}
