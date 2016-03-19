using TowerDefense.Data.Models.Maps;
using TowerDefense.Data.Models.Viruses;

namespace TowerDefense.Data.Models.Towers
{
    public abstract class Tower: Entity
    {
        //variables
        public TowerType Type { get; set; }
        public int DamageDealt { get; set; }
        public int AttackSpeed { get; set; }
        public int Range { get; set; }
        public TowerDamageType DamageType { get; set; } // Single or area splash
        public VirusType VirusType { get; set; } // Whether a ground or flying unit
        public int Level { get; set; } // 1-5 
        public int UpgradeCost { get; set; }
        public Map map;
        public string SurfaceName { get; set; }

        abstract public void upgrade();

        public Tower()
        {
            map = DataManager.Map;
        }

        public Virus Targeting() {

            for (int y = 0; y < this.Range; y++) {
                for (int x = 0; x < this.Range; x++) {
                    
                }
            }

            return null;
        }
    }
}
