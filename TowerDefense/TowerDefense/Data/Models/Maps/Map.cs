using System.Collections.Generic;
<<<<<<< HEAD
using TowerDefense.Data.Models.Towers;
using TowerDefense.Data.Models.Viruses;

namespace TowerDefense.Data.Models.Maps
{
    public class Map
    {
        //Tile[,] mapArray = new Position[16, 11] { { new NonPathTile(0, 0), new NonPathTile(0, 1), new NonPathTile(0, 2), new NonPathTile(0, 3), new PathTile(0, 4, 0), new NonPathTile(0, 5), new NonPathTile(0, 6), new NonPathTile(0, 2) } }
        public object[,] mapArray; = new Position[16,11];
        public int[] simpleMapArray;
        // Map constants
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        public const int WIDTH = 16;
        public const int HEIGHT = 11;

        public Home Home;
        public Tower[] Towers;
        public List<Virus> Viruses;
        public Position SpawnLocation;
=======
using TowerDefense.Data.Models.Towers;
using TowerDefense.Data.Models.Viruses;


namespace TowerDefense.Data.Models.Maps
{
    public class Map
    {
        //Position[,] mapArray = new Position [16,11] { {new Tile(0 ,0 ,0), new Tile(0 ,1 ,0), new Tile(0 ,2 ,0), new Tile(0 ,3 ,0), new Tile(0, 4, 1), new Tile(0, 5, 0), new Tile(0, 6, 0), new Tile(0, 2, 0) }   }

        // Map constants
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        public const int WIDTH = 16;
        public const int HEIGHT = 11;

        public Home Home;
        public List<Tower> Towers;
        public List<Virus> Viruses;
        public Position SpawnLocation;
>>>>>>> origin/master
        public string SurfaceName;
        public PathFinding path;
        public Directions[] dirs;

        public Map(int mapNumber)
        {
            path = new PathFinding();
<<<<<<< HEAD
            dirs = path.getPath(1);
        }

        public void UpdateLogic() {

            // Loop through all viruses, and try and move them.
            foreach (var virus in Viruses) {
                virus.Move((Directions)dirs.GetValue(virus.Step));
                virus.Step++;
            }
        }

        public void populateMap()
        {
            simpleMapArray = new int[] {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,
                                        0,2,0,0,1,1,1,0,0,0,2,1,1,0,0,0,0,
                                        0,1,1,0,0,0,1,0,0,0,0,0,1,1,1,1,0,
                                        0,0,1,0,0,0,1,1,1,0,0,0,0,0,0,1,0, // 2ns last 1 is the diagonal
                                        0,0,1,1,0,0,0,0,1,0,0,0,0,0,0,1,0,
                                        0,0,0,1,0,0,0,0,1,1,0,0,0,0,1,1,0,
                                        0,1,1,1,0,0,0,0,0,1,0,0,0,0,1,0,0,
                                        0,1,0,0,0,1,1,1,1,1,0,0,0,0,1,1,0,
                                        0,1,0,0,0,1,0,0,0,0,0,0,2,0,0,1,0,
                                        0,2,0,0,0,1,1,1,0,0,0,0,1,0,0,1,0,
                                        0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,1,0,};
            int index = 0;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 11; y++)
                {
                    int tile = simpleMapArray[index];
                    if ( tile == 0)
                    {
                        mapArray[x, y] = new NonPathTile(x, y);
                            index++;
                    }
                    else if(tile == 1)
                    {
                        mapArray[x, y] = new PathTile(x, y, 1);
                    }
                    else if(tile == 2)
                    {
                        mapArray[x, y] = new PathTile(x, y, 2);
                    }
                }
            }
        }
    }
}
=======
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
>>>>>>> origin/master
