using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefense.Data.Models.Towers;
using TowerDefense.Data.Models.Viruses;

namespace TowerDefense.Data.Models.Maps
{
    public class Map
    {
        public delegate void virusDeathDel(Virus virus, bool isLifeLost);
        public event virusDeathDel virusDeath;
        public Tile[,] mapArray = new Tile[16, 11];
        // Map constants
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        public const int WIDTH = 16;
        public const int HEIGHT = 11;

        public Home Home;
        public List<Tower> Towers = new List<Tower>();
        public List<Virus> Viruses = new List<Virus>();
        public List<Virus> EnemiesInRange;
        public Position SpawnLocation { get; set; }
        public string SurfaceName;
        public PathFinding path = new PathFinding();
        public Directions[] dirs;
        public int MobCount;
        public int SpawnRate;
        private int LastSpawn;
        //Tower Position
        Position pos = new Position();

        // Tower radius markers
        int xMin;
        int xMax;
        int yMin;
        int yMax;


        public Map() {
            Home = new Home();
            // add handler for virus deaths
            virusDeath += (virus, isLifeLost) => {
                if (isLifeLost == true) {
                    if (Home.takeDamage()) {
                        Console.WriteLine("GAME OVER!!!!!!");
                    }
                }
                else
                {
                    DataManager.Board.AddMoney(virus.Money);
                    DataManager.Board.AddScore(virus.Score);
                }
                Viruses.Remove(virus);
                if (Viruses.Count <= 0) {
                    // TODO should determine virus type by wave number
                    SpawnManager.spawnWave(3, new Tindrider());
                }
            };
            // Spawn one wave on creation of the map
            SpawnManager.spawnWave(10, new Tindrider());
        }

        public void UpdateLogic() {
            for (int i = 0; i < Viruses.Count; i++) {
                var virus = Viruses[i];
                if (virus != null) {
                    // They got to the end
                    if (virus.Step >= dirs.Length) {
                        OnVirusDeath(virus, true);
                        //break;
                    }
                    
                    // TODO: virus.Step out of range exception
                    else virus.Move((Directions)dirs.GetValue(virus.Step));

                    foreach (var tower in Towers) {


                        // Check for attack speed or something. Connor seems to know.
                        if (tower.lastAttack + tower.AttackSpeed < Environment.TickCount)
                        {
                            if (Math.Abs(virus.Position.X - tower.X) <= tower.Range)
                            {
                                if (Math.Abs(virus.Position.Y - tower.Y) <= tower.Range)
                                {

                                    // Attack the virus
                                    Console.WriteLine("Commence attack operationss!!!");
                                    tower.AttackTarget(virus);

                                    // Update whatever we check above.
                                    tower.lastAttack = Environment.TickCount;
                                }
                            }
                        }
                        /*else
                        {
                            tower.lastAttack = ;
                        }*/
                        
                    }
                }
            }
        }

        public virtual void PopulateMap() {

        }

        public Virus prioritizeVirus(List<Virus> unsortedList) {
            List<Virus> sortedList = unsortedList.OrderBy(v => v.Step).ToList();

            return sortedList.LastOrDefault();
        }

        // Remove the virus from the list and spawn a new wave if none are left.
        public void OnVirusDeath(Virus virus, bool lifeLost = false) {
            if (virusDeath != null)
                virusDeath(virus, lifeLost);
        }
    }
}
