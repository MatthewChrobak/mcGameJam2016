using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Data.Models
{
    public class PathTile: Tile
    {
        public int Type { get; set; } // 0 for path, 1 teleporter
        public List<Viruses.Virus> viruses { get; set; }

        public PathTile(int x, int y, int type)
        {
            Position p = new Position(x, y);
            this.X = x;
            this.Y = y;
            Type = type;
            viruses = new List<Viruses.Virus>();
        }

        public void addVirus(Viruses.Virus v)
        {
            viruses.Add(v);
        }
    }
}
