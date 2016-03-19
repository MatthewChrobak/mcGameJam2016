using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Data.Models
{
    public class NonPathTile
    {
        public Position Position { get; set; }
        public Towers.Tower Tower { get; set; }

        public NonPathTile(int x, int y)
        {
            Position p = new Position(x, y);
            Position = p;
            Tower = null;
        }
    }
}
