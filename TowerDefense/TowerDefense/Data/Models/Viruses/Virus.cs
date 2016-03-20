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
        public Directions Direction = Directions.DOWN;

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

            this.Direction = dir;

            // Check to see if we can move again.
            if (LastMove + Speed < Environment.TickCount) {

                this.xOffset = 0;
                this.yOffset = 0;

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

                // Check if the virus is standing on a teleporter. Hardcoded for now
                if(Step == 28)
                {
                    this.Position = new Position(1, 1);
                }
                if(Step == 40)
                {
                    this.Position = new Position(9, 1);
                }
                
            } else {
                int timeSince = Environment.TickCount - LastMove;
                int x = (int)(((float)timeSince / Speed) * 60);
                int y = (int)(((float)timeSince / Speed) * 59);

                switch (dir) {
                    case Directions.UP:
                        this.yOffset = -y;
                        this.xOffset = 0;
                        break;
                    case Directions.DOWN:
                        this.yOffset = y;
                        this.xOffset = 0;
                        break;
                    case Directions.LEFT:
                        this.xOffset = -x;
                        this.yOffset = 0;
                        break;
                    case Directions.RIGHT:
                        this.xOffset = x;
                        this.yOffset = 0;
                        break;
                }
            }
        }
    }
}
