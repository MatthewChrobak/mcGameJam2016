namespace TowerDefense.Data.Models.Towers.Models
{
    public class TeslaTower : Tower
    {
        public const int TowerCost = 50;
        public const string TowerName = "Tesla Tower";
        public const string TowerDescription = "Fires a single shot in a single bound.";
        public const string ShopIcon = "icon1";
        public const string SurfaceName = "tower1";

        public TeslaTower()
        {
            this.Type = TowerType.TESLA;
            this.DamageDealt = 5;
            this.AttackSpeed = 1000;
            this.Range = 10;
            this.DamageType = TowerDamageType.SINGLE;
            this.VirusType = Viruses.VirusType.TINRIDER;
            this.Level = 1;
            this.UpgradeCost = 75;
            this.Surface = SurfaceName;
        }

        public TeslaTower(int x, int y) : this() {
            this.X = x;
            this.Y = y;
        }

        public override void upgrade()
        {
            this.DamageDealt += 5;
            this.Level++;
            this.UpgradeCost += 75;
        }
    }
}
