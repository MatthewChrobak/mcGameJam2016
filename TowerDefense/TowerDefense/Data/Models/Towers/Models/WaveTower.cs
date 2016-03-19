using System;

namespace TowerDefense.Data.Models.Towers.Models
{
    public class WaveTower : Tower
    {
        public const int TowerCost = 60;

        public WaveTower() {
            this.Type = TowerType.WAVE;
            this.DamageDealt = 5;
            this.AttackSpeed = 1500;
            this.Range = 8;
            this.DamageType = TowerDamageType.SPLASH;
            this.VirusType = Viruses.VirusType.GROUND;
            this.Level = 1;
            this.UpgradeCost = 95;
            this.SurfaceName = "tower2";
        }

        public override void upgrade() {
            
        }
    }
}
