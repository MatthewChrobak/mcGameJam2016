namespace TowerDefense.Data.Models.Towers.Models
{
    public class TeslaTower : Tower
    {
        public const int TowerCost = 50;

        public TeslaTower()
        {
            this.Type = TowerType.TESLA;
            this.DamageDealt = 5;
            this.AttackSpeed = 1000;
            this.Range = 10;
            this.DamageType = TowerDamageType.SINGLE;
            this.VirusType = Viruses.VirusType.GROUND;
            this.Level = 1;
            this.UpgradeCost = 75;
            this.SurfaceName = "tower1";
        }

        public override void upgrade()
        {
            this.DamageDealt += 5;
            this.Level++;
            this.UpgradeCost += 75;
        }
    }
}
