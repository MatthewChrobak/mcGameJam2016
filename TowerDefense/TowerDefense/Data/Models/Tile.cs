using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Data.Models
{
    class Tile: Position
    {
        public Position Position { get; set; }
        public int Type { get; set; } // 0 for empty and 1 for path
    }
}
