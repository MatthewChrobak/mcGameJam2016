using System;
namespace TowerDefense.Data.Models.Viruses
{
    public abstract class Virus
    {
        public Position Position { get;  set; }
        public VirusType Type { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Speed { get; set; }
        public int Money { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public float MovementSpeed { get; set; }
        public int Step { get; set; }


        private int LastMove;

        public void Move(Directions dir) {

            // Check to see if we can move again.
            if (LastMove + Speed < Environment.TickCount) {
                switch (dir)
                {
                    case Directions.NORTH:
                        break;
                    case Directions.SOUTH:
                        break;
                    case Directions.EAST:
                        break;
                    case Directions.WEST:
                        break;
                    case Directions.NORTHEAST:
                        break;
                    case Directions.NORTHWEST:
                        break;
                    case Directions.SOUTHEAST:
                        break;
                    case Directions.SOUTHWEST:
                        break;
                }


                // Set the current tickcount as our last move time.
                LastMove = Environment.TickCount;
            }
        }
    }
}
