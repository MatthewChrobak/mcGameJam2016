﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Data.Models.Towers;
using TowerDefense.Data.Models.Viruses;
using TowerDefense.Data.Models.Position;

namespace TowerDefense.Data.Models
{
    class Map
    {
        private Home home;
        private Tower[] towers;
        //private Virus[] viruses;
        private int tileSizeX;
        private int tileSizeY;
        private Position.Position spawnLocation;

    }
}