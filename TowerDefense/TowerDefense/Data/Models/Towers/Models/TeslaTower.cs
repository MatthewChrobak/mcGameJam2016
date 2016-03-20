using System;
using TowerDefense.Data.Models.Viruses;

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
            this.DamageDealt = 75;
            this.AttackSpeed = 1500;
            this.Range = 1;
            this.DamageType = TowerDamageType.SINGLE;
            this.VirusType = Viruses.VirusType.TINRIDER;
            this.Level = 1;
            this.UpgradeCost = 75;
            this.Surface = SurfaceName;

            this.AnimationStepTick = 350;
            this.AnimationState = -1;
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

        public override void CustomDraw() {

        }

        public override sbyte GetAnimation() {

            if (LastAnimation + AnimationStepTick < Environment.TickCount) {
                switch (AnimationState) {
                    case -1:
                        AnimationState = 0;
                        break;
                    case 0:
                        AnimationState = 1;
                        break;
                    case 1:
                        NextStep = 1;
                        AnimationState += NextStep;
                        break;
                    case 2:
                        AnimationState += NextStep;
                        break;
                    case 3:
                        NextStep = -1;
                        AnimationState += NextStep;
                        break;
                }

                LastAnimation = Environment.TickCount;
            }



            return this.AnimationState;
        }

        public override void AttackTarget(Virus victim) {
            victim.takeDamage(DamageDealt);
        }
    }
}
