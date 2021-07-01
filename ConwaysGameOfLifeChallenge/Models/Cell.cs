using System.Collections.Generic;

namespace ConwaysGameOfLifeChallenge.Models
{
    public class Cell
    {
        public int Id { get; set; }
        public bool IsAlive { get; set; }
        public int Collumn { get; set; }
        public int Row { get; set; }
        public IList<Cell> Neighbours { get; set; } = new List<Cell>();
    }
}
