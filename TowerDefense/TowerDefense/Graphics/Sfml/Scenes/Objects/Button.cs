﻿using System;
using SFML.Graphics;

namespace TowerDefense.Graphics.Sfml.Scenes.Objects
{
    public class Button : SceneObject
    {
        public string Caption;
        public Color TextColor = SFML.Graphics.Color.Black;
        public uint FontSize = 12;

        public override void Draw() {
            // Draw the surface if we have one.
            base.Draw();

            // Draw the button's caption.
            base.RenderCaption(this.Caption, this.FontSize, this.TextColor);
        }

        internal static void cmdStageSelect_MouseDown(int arg1, int arg2) {
            Game.SetGameState(GameState.StageSelect);
        }

        internal static void cmdBackButton_MouseDown(int arg1, int arg2) {
            Game.SetGameState(GameState.MainMenu);
        }

        internal static void cmdStage1_MouseDown(int arg1, int arg2) {
            throw new NotImplementedException();
        }
    }
}
