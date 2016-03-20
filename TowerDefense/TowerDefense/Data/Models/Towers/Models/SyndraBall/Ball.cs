using System;
using TowerDefense.Graphics;
using TowerDefense.Graphics.Sfml;

namespace TowerDefense.Data.Models.Towers.Models.SyndraBall
{
    public class Ball : Position
    {
        private int yOffset;
        private int YStep;
        private int LastUpdate;
        private int AnimStepTick = 100;
        private const int yBuffer = 45;
        private const int xBuffer = 20;

        public Ball(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        private int[] Steps = new int[] {
            0, 1, 2, 4, 7, 5, 3, 2, 1, 0, -1, -2, -3, -5, -7, -4, -2, -1
        };

        public void Update() {
            if (LastUpdate + AnimStepTick < Environment.TickCount) {

                this.yOffset += Steps[++YStep % Steps.Length];

                LastUpdate = Environment.TickCount;
            }
        }

        public void Draw() {
            var surface = ((Sfml)GraphicsManager.Graphics).GetSurface("syndraball", SurfaceTypes.Tower);
            surface.TextureRect = new SFML.Graphics.IntRect((YStep % 8) * 64, 0, 64, 128);
            surface.Position = new SFML.System.Vector2f(this.X * 60 - xBuffer, this.Y * 59 + this.yOffset - yBuffer);
            ((Sfml)GraphicsManager.Graphics).DrawObject(surface);
        }
    }
}
