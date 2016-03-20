﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TowerDefense.Data.Models.Viruses;

namespace TowerDefense.Data.Models
{
    public static class SpawnManager
    {
        // Spawns a wave of the given virus.
        public static void spawnWave(int waveSize, Virus virus)
        {
            // Always Delay the spawn by 10 seconds
            Game.DelayInvoke(2000, () => {
                Object[,] map = DataManager.Map.mapArray;
                List<Virus> viruses = DataManager.Map.Viruses;
                virus.Position = DataManager.Map.SpawnLocation;
                Random rnd = new Random();
                // Viruses will spawn one second at a time
                Timer spawnTimer = new Timer(5000 + rnd.Next(500,3000));
                spawnTimer.Start();
                spawnTimer.Elapsed += (sender, args) =>
                {
                    viruses.Add(new Tindrider(virus.Position.X, virus.Position.Y));
                    waveSize--;
                    if (waveSize <= 0)
                    {
                        spawnTimer.Stop();
                    }
                };    
            });
            
        }


    }
}
