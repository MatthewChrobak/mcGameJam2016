using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefense.Data.Models.Towers;
using TowerDefense.Data.Models.Viruses;

namespace TowerDefense.Data.Models.Maps
{
    public class Map
    {
        public delegate void virusDeathDel(Virus virus);
        public event virusDeathDel virusDeath;
        public Tile[,] mapArray = new Tile[16, 11];
        // Map constants
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        public const int WIDTH = 16;
        public const int HEIGHT = 11;

        public Home Home;
        public List<Tower> Towers;
        public List<Virus> Viruses;
        public List<Virus> EnemiesInRange;
        public Position SpawnLocation{ get; set;}
        public string SurfaceName;
        public PathFinding path;
        public Directions[] dirs;
        public int MobCount;
        public int SpawnRate;
        private int LastSpawn;

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
            PopulateMap();
            this.SpawnLocation = new Position(0, 4);
            // add handler for virus deaths
            virusDeath += (virus) =>
            {
                if (Viruses.Count <= 0)
                {
                    Viruses.Remove(virus);
                    // TODO should determine virus type by wave number
                    SpawnManager.spawnWave(10, new TinRider());
                }
            };
            // Spawn one wave on creation of the map
            SpawnManager.spawnWave(10, new TinRider());
        }

        public void UpdateLogic()
        {
            // Loop through all viruses, and try and move them.
            for (int x = 0; x < 16; x++) {
                for (int y = 0; y < 11; y++) {
                    var tile = mapArray[x, y] as PathTile;
                    if (tile != null) {
                        foreach (var virus in tile.viruses) {
                            if (virus.Step >= dirs.Length) {
                                break;
                            }
                            virus.Move((Directions)dirs.GetValue(virus.Step));
                        }
                    }
                }
            }

            // Have we killed all the mobs?
            if (MobCount == 0) {
                DataManager.Board.Wave += 1;
                this.MobCount = DataManager.Board.Wave;
            } else if (MobCount > 0) {
                // Can we spawn a mob?
                if (LastSpawn + SpawnRate < Environment.TickCount) {

                    // Get the spawn location, and add a new virus to it.
                    var spawn = mapArray[SpawnLocation.X, SpawnLocation.Y] as PathTile;

                    if (spawn != null) {
                        spawn.viruses.Add(new TestVirus(SpawnLocation.X, SpawnLocation.Y));
                        MobCount = -1;
                        LastSpawn = Environment.TickCount;
                    }
                }
            } 

            // Loop through all towers, and try to target enemy
            foreach (var tower in Towers) {
                // Assign tower coordinates and refresh enemies in range list
                pos.X = tower.X;
                pos.Y = tower.Y;
                if(EnemiesInRange != null)
                {
                    EnemiesInRange.Clear();
                }
                

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
                        if(mapArray[x,y].GetType() == typeof(PathTile))
                        {
                            PathTile tempPathTile = (PathTile)mapArray[x, y];
                            EnemiesInRange.AddRange(tempPathTile.viruses);

                            // Determines highest priority and sets to fire
                            tower.CurrentTarget = prioritizeVirus(EnemiesInRange);
                            tower.shootAtTarget();
                        }
                    }
                }
            }
        }

        public virtual void PopulateMap() {

        }

        public Virus prioritizeVirus(List<Virus> unsortedList)
        {
            List<Virus> sortedList = unsortedList.OrderBy(v => v.Step).ToList();

            return sortedList.LastOrDefault();
        }

        // Remove the virus from the list and spawn a new wave if none are left.
        public void OnVirusDeath(Virus virus)
        {
            if (virusDeath != null)
                virusDeath(virus);
        }
    }
}
