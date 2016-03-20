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
        public int MovementSpeed { get; set; }
        public int Step { get; private set; }
        public string Surface { get; set; }

        public int xOffset { get; private set; }
        public int yOffset { get; private set; }

        public Virus() {
            this.Position = new Position();
            this.Speed = 500;
        }

        public Virus(int x, int y) {
            this.Position = new Position(x, y);
        }


        private int LastMove;

        public void Move(Directions dir) {

            // Check to see if we can move again.
            if (LastMove + Speed < Environment.TickCount) {
                switch (dir)
                {
                    case Directions.UP:
                        this.Position = new Position(this.Position.X, this.Position.Y - 1);
                        break;
                    case Directions.DOWN:
                        this.Position = new Position(this.Position.X, this.Position.Y + 1);
                        break;
                    case Directions.RIGHT:
                        this.Position = new Position(this.Position.X + 1, this.Position.Y);
                        break;
                    case Directions.LEFT:
                        this.Position = new Position(this.Position.X - 1, this.Position.Y);
                        break;
                }


                this.Step++;

                // Set the current tickcount as our last move time.
                LastMove = Environment.TickCount;
            } else {
                int timeSince = Environment.TickCount - LastMove;

            }
        }
    }
}
