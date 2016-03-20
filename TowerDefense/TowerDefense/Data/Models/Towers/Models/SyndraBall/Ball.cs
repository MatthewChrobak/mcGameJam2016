﻿using System;
using System.Threading;
using TowerDefense.Graphics;
using TowerDefense.Graphics.Sfml;

namespace TowerDefense.Data.Models.Towers.Models.SyndraBall
{
    public class Ball : Position
    {
        private int yOffset;
        private int YStep;
        private int LastUpdate;
        private int LastAttackUpdate;
        private int AnimAttackTick = 16;
        private int AnimStepTick = 50;
        private const int yBuffer = 45;
        private const int xBuffer = 20;

        private bool FollowingTarget = false;
        private Viruses.Virus Victim;
        public bool GotVictim { private set; get; }

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

            if (LastUpdate + AnimAttackTick < Environment.TickCount) {
                if (FollowingTarget) {

                    int vicX = Victim.Position.X * 60 + Victim.xOffset;
                    int vicY = Victim.Position.Y * 59 + Victim.yOffset;

                    int distance = (int)Math.Sqrt(Math.Pow(vicX - this.X, 2) + Math.Pow(vicY - this.Y, 2));
                    int speed = 20;

                    if (this.X < vicX) {
                        this.X += speed;
                    } else if (this.X > vicX) {
                        this.X -= speed;
                    }

                    if (this.Y < vicY) {
                        this.Y += speed;
                    } else if (this.Y > vicY) {
                        this.Y -= speed;
                    }

                    if (Math.Abs(this.X - vicX) < 10) {
                        if (Math.Abs(this.Y - vicY) < 10) {
                            Victim.takeDamage(75);
                            GotVictim = true;
                        }
                    }
                }

                LastAttackUpdate = Environment.TickCount;
            }
        }

        public void Draw() {
            var surface = ((Sfml)GraphicsManager.Graphics).GetSurface("syndraball", SurfaceTypes.Tower);
            surface.TextureRect = new SFML.Graphics.IntRect((YStep % 8) * 64, 0, 64, 128);

            if (!FollowingTarget) {
                surface.Position = new SFML.System.Vector2f(this.X * 60 - xBuffer, this.Y * 59 + this.yOffset - yBuffer);
            } else {
                surface.Position = new SFML.System.Vector2f(this.X, this.Y);
            }

            ((Sfml)GraphicsManager.Graphics).DrawObject(surface);
        }

        public void FollowTarget(ref Viruses.Virus victim) {
            if (!FollowingTarget) {
                this.Victim = victim;
                this.X = X * 60;
                this.Y = Y * 59;
                FollowingTarget = true;
            }
        }
    }
}
