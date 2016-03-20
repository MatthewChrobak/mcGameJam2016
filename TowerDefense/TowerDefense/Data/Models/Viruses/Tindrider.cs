namespace TowerDefense.Data.Models.Viruses
{
    class Tindrider:Virus
    {
        public Tindrider()
        {
            this.Name = "TinRider";
            this.Speed = 200;
            this.Type = VirusType.TINRIDER;
            this.Health = 150;
            this.MaxHealth = 150;
            this.Level = 1;
            this.Money = 40;
            this.Score = 10;
            this.MovementSpeed = 1;
            this.Surface = "tindrider";
        }

        public Tindrider(int x, int y) : this()
        {
            this.Position.X = x;
            this.Position.Y = y; 
        }
    }
}
