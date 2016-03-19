﻿using System.Collections.Generic;
using TowerDefense.Data.Models.Towers;
using TowerDefense.Data.Models.Viruses;

namespace TowerDefense.Data.Models.Maps
{
    public class Map
    {
        // Map constants
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        public const int WIDTH = 16;
        public const int HEIGHT = 11;

        public Home Home;
        public List<Tower> Towers;
        public List<Virus> Viruses;
        public Position SpawnLocation;
        public string SurfaceName;
        public PathFinding path;
        public Directions[] dirs;

        public Map(int mapNumber)
        {
            path = new PathFinding();
            dirs = path.getPath(mapNumber);
            Towers = new List<Tower>();
            Viruses = new List<Virus>();
        }

        public void UpdateLogic() {

            // Loop through all viruses, and try and move them.
            foreach (var virus in Viruses) {
                virus.Move((Directions)dirs.GetValue(virus.Step));
                virus.Step++;
            }

            // Loop through all towers, and try to target enemy
            foreach (var tower in Towers)
            {
                tower.Targeting();
            }
        }
    }
}
