using System;

namespace TowerDefense.Data.Models.Towers.Models
{
    public class WaveTower : Tower
    {

        public WaveTower() {
            this.Type = TowerType.WAVE;
            this.Cost = 60;
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
