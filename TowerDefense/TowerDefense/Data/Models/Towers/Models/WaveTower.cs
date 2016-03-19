using System;

namespace TowerDefense.Data.Models.Towers.Models
{
    public class WaveTower : Tower
    {
        public const int TowerCost = 60;
        public const string TowerName = "Syndra Tower";
        public const string TowerDescription = "Syndra is the current Jungle meta.";
        public const string ShopIcon = "icon2";
        public const string SurfaceName = "tower2";

        public WaveTower() {
            this.Type = TowerType.WAVE;
            this.DamageDealt = 5;
            this.AttackSpeed = 1500;
            this.Range = 8;
            this.DamageType = TowerDamageType.SPLASH;
            this.VirusType = Viruses.VirusType.GROUND;
            this.Level = 1;
            this.UpgradeCost = 95;
            this.Surface = SurfaceName;
        }

        public override void upgrade() {
            
        }
    }
}
