using System.Collections.Generic;
using TowerDefense.Data.Models.Towers;
using TowerDefense.Data.Models.Viruses;

namespace TowerDefense.Data.Models.Maps
{
    public class Map
    {
        public Tile[,] mapArray = new Tile[16, 11];
        public int[] simpleMapArray;
        // Map constants
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        public const int WIDTH = 16;
        public const int HEIGHT = 11;

        public Home Home;
        public List<Tower> Towers;
        public List<Virus> Viruses;
        public Position SpawnLocation{ get; set;}
        public string SurfaceName;
        public PathFinding path;
        public Directions[] dirs;

        //Tower Position
        Position pos;

        // Tower radius markers
        int xMin;
        int xMax;
        int yMin;
        int yMax;


        public Map()
        {
            path = new PathFinding();
            dirs = path.getPath(1);
            Towers = new List<Tower>();
            Viruses = new List<Virus>();
            pos = new Position();
        }

        public void UpdateLogic()
        {

            // Loop through all viruses, and try and move them.
            foreach (var virus in Viruses)
            {
                virus.Move((Directions)dirs.GetValue(virus.Step));
                virus.Step++;
            }

            // Loop through all towers, and try to target enemy
            foreach (var tower in Towers)
            {
                // Assign tower coordinates
                pos.X = tower.X;
                pos.Y = tower.Y;

                // Make sure range check does not exceed upper bound
                if (pos.Y - tower.Range < 0)
                    yMin = 0;
                else
                    yMin = pos.Y - tower.Range;

                // Make sure range check does not exceed lower bound
                if (pos.Y + tower.Range > WIDTH)
                    yMax = WIDTH;
                else
                    yMax = pos.Y + tower.Range;

                // Make sure range check does not exceed left bound
                if (pos.X - tower.Range < 0)
                    xMin = 0;
                else
                    xMin = pos.X - tower.Range;

                // Make sure range check does not exceed right bound
                if (pos.X + tower.Range > HEIGHT)
                    xMax = HEIGHT;
                else
                    xMax = pos.X + tower.Range;


                for (int y = yMin; y < yMax; y++)
                {
                    for (int x = xMin; x < xMax; x++)
                    {

                    }
                }
            }
        }

        public void populateMap()
        {
            simpleMapArray = new int[] {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,
                                        0,2,0,0,1,1,1,0,0,0,2,1,1,0,0,0,
                                        0,1,1,0,0,0,1,0,0,0,0,0,1,1,1,1,
                                        0,0,1,0,0,0,1,1,1,0,0,0,0,0,0,1, // 2nd last 1 is the diagonal
                                        0,0,1,1,0,0,0,0,1,0,0,0,0,0,0,1,
                                        0,0,0,1,0,0,0,0,1,1,0,0,0,0,1,1,
                                        0,1,1,1,0,0,0,0,0,1,0,0,0,0,1,0,
                                        0,1,0,0,0,1,1,1,1,1,0,0,0,0,1,1,
                                        0,1,0,0,0,1,0,0,0,0,0,0,2,0,0,1,
                                        0,2,0,0,0,1,1,1,0,0,0,0,1,0,0,1,
                                        0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,1,};
            int index = 0;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 11; y++)
                {
                    int tile = simpleMapArray[index];
                    if (tile == 0)
                    {
                        mapArray[x, y] = new NonPathTile(x, y);
                        index++;
                    }
                    else if (tile == 1)
                    {
                        mapArray[x, y] = new PathTile(x, y, 1);
                        index++;
                    }
                    else if (tile == 2)
                    {
                        mapArray[x, y] = new PathTile(x, y, 2);
                        index++;
                    }
                }
            }
        }
    }
}
