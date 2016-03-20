using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Data.Models.Viruses
{
    class TinRider:Virus
    {
        public TinRider()
        {
            this.Name = "TinRider";
            this.Speed = 1;
            this.Type = VirusType.TINRIDER;
            this.Health = 150;
            this.Level = 1;
            this.Money = 40;
            this.MovementSpeed = 1;
        }
    }
}
