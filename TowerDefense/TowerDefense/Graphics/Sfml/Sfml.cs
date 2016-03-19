using TowerDefense.Graphics.Sfml.Scenes;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.IO;
using SFML.System;
using TowerDefense.Data;

namespace TowerDefense.Graphics.Sfml
{
    public class Sfml : IGraphics
    {
        public SceneSystem SceneSystem { private set; get; }
        private RenderWindow DrawingSurface;
        private Font GameFont;
        private Color _backgroundColor;

        // The collection of all the graphics.
        private List<GraphicalSurface>[] _surface;

        #region Core System
        public Sfml() {
            // Load all the surfaces and the font.
            this.LoadSurfaces();
            this.LoadFont();

            // Create a new renderwindow that we can render graphics onto.
            this.DrawingSurface = new RenderWindow(new VideoMode(960, 640), "Title", Styles.Close);

            // Set the default background color for the drawing surface.
            this._backgroundColor = new Color(25, 25, 25);

            // Create event handlers for the drawing surface.
            this.CreateEventHandlers();
        }

        public void Destroy() {
            // Destroy the scene system.
            this.SceneSystem.Destroy();
            this.SceneSystem = null;

            // Loop through every collection that stores surfaces.
            foreach (var collection in this._surface) {
                // Loop through every surface in the collection, and 
                // dispose of the sprite.
                foreach (var surface in collection) {
                    surface.Sprite.Dispose();
                }

                // Then clear the collection.
                collection.Clear();
            }

            // Dispose of the game font.
            this.GameFont.Dispose();

            // Dispose of the drawing surface.
            this.DrawingSurface.Dispose();
        }

        private void CreateEventHandlers() {
            // Create a new scene system to handle the events.
            this.SceneSystem = new SceneSystem();

            // For mouse related events, just pass off the coords to the scene system.
            this.DrawingSurface.MouseButtonPressed += (sender, e) => {
                this.SceneSystem.MouseDown(e.Button.ToString().ToLower(), e.X, e.Y);
            };
            this.DrawingSurface.MouseButtonReleased += (sender, e) => {
                this.SceneSystem.MouseUp(e.Button.ToString().ToLower(), e.X, e.Y);
            };
            this.DrawingSurface.MouseMoved += (sender, e) => {
                this.SceneSystem.MouseMove(e.X, e.Y);
            };

            // For key related events, pass off the filtered keyname to the scene system.
            this.DrawingSurface.KeyPressed += (sender, e) => {
                this.SceneSystem.KeyDown(this.FilterKey(e));
            };

            // When the close button is pressed, set the game flag to 'closing' so 
            // the application can begin to close.
            this.DrawingSurface.Closed += (sender, e) => {
                switch (Game.State) {
                    case GameState.Game:
                        Game.SetGameState(GameState.MainMenu);
                        break;
                    default:
                        Game.SetGameFlag(GameFlag.Closing);
                        break;
                }
            };
        }

        private void LoadSurfaces() {
            // Initialize the array of collections.
            this._surface = new List<GraphicalSurface>[(int)SurfaceTypes.Length];

            // Initialize each collection in the array.
            for (int i = 0; i < (int)SurfaceTypes.Length; i++) {
                this._surface[i] = new List<GraphicalSurface>();
            }

            // From this point onward, load graphics into their respective collections.
            foreach (string file in Directory.GetFiles(GraphicsManager.TowerPath, "*.png")) {
                this._surface[(int)SurfaceTypes.Tower].Add(new GraphicalSurface(file));
            }

            foreach (string file in Directory.GetFiles(GraphicsManager.MapPath, "*.png")) {
                this._surface[(int)SurfaceTypes.Map].Add(new GraphicalSurface(file));
            }
        }

        private void LoadFont() {
            string fontFile = GraphicsManager.FontPath + "tahoma.ttf";

            // Make sure that the ttf file exists.
            if (File.Exists(fontFile)) {
                this.GameFont = new Font(fontFile);
            } else {
                throw new FileNotFoundException("Sfml: " + fontFile);
            }
        }

        public void Draw() {
            // Invoke the DoEvents for SFML so we can capture mouse and keyboard events.
            this.DrawingSurface.DispatchEvents();

            // Clear the drawing surface with the background color.
            this.DrawingSurface.Clear(this._backgroundColor);

            // Draw the actual game.
            this.DrawGame();

            // Draw the user interface.
            this.SceneSystem.Draw();

            // Update the drawing surface with that what has been drawn.
            this.DrawingSurface.Display();
        }

        public void DrawObject(object obj) {
            // Convert the given object to an SFML drawable object, and 
            // have the drawing surface render it.
            var surface = (Drawable)obj;
            this.DrawingSurface.Draw(surface);
        }

        public object GetFont() {
            return this.GameFont;
        }

        private string FilterKey(KeyEventArgs e) {
            string key = e.Code.ToString();

            // Make sure it's a single character.
            if (key.Length == 1) {
                // Are we hitting shift?
                if (e.Shift) {
                    key = key.ToUpper();
                } else {
                    key = key.ToLower();
                }
            } else {
                // If it's not a single character, explore other options.
                switch (key.ToLower()) {
                    case "space":
                        key = " ";
                        break;
                    case "backspace":
                        // Just keep it as it is.
                        break;
                    default:
                        // Don't risk it.
                        return string.Empty;
                }
            }

            // Return the filtered key.
            return key.ToLower();
        }

        private Sprite GetSurface(string tagName, SurfaceTypes type) {
            // Loop through the collection of the specified type.
            for (int i = 0; i < this._surface[(int)type].Count; i++) {
                // If the surface tag name is equal to the tag name specified, return the surface.
                if (this._surface[(int)type][i].Tag == tagName.ToLower()) {
                    return this._surface[(int)type][i].Sprite;
                }
            }

            // Return null if we couldn't find a surface with the tag specified.
            return null;
        }

        private int GetSurfaceIndex(string tagName, SurfaceTypes type) {
            // Loop through the collection of the specified type.
            for (int i = 0; i < this._surface[(int)type].Count; i++) {
                // If the surface tag name is equal to the tag name specified, return the surface.
                if (this._surface[(int)type][i].Tag == tagName.ToLower()) {
                    return i;
                }
            }

            // Return -1 if we couldn't find a surface with the tag specified.
            return -1;
        }
        #endregion


        private void RenderSample_DO_NOT_USE_THIS() {
            // Load a surface of a certain type.
            var surface = GetSurface("generic", SurfaceTypes.Tower);

            // Set the position on the screen.
            surface.Position = new Vector2f(100, 100);

            // Resize the surface.
            surface.Scale = new Vector2f(1, 1);

            // Rotate the surface.
            surface.Rotation = 1.0f;

            // Set a color overlay on the surface.
            surface.Color = Color.Green;

            // Draw the surface.
            DrawObject(surface);
        }


        private void DrawGame() {
            // All logic pertaining to drawing the game goes here.

            if (Game.State == GameState.Game) {
                // Draw the base map.
                var map = DataManager.Map;
                var mapSurface = GetSurface(map.SurfaceName, SurfaceTypes.Map);
                mapSurface.Position = new Vector2f(0, 0);
                mapSurface.Scale = new Vector2f((float)960 / mapSurface.Texture.Size.X, (float)640 / mapSurface.Texture.Size.Y);
                DrawObject(mapSurface);
            }
        }
    }
}
