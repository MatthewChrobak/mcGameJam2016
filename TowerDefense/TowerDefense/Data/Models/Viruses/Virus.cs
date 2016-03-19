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


        private int LastMove;

        public void Move() {

            // Check to see if we can move again.
            if (LastMove + Speed < Environment.TickCount) {
                // Logic involving moving viruses here.

                // Set the current tickcount as our last move time.
                LastMove = Environment.TickCount;
            }
        }
    }
}
