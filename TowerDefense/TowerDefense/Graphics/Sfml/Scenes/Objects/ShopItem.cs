namespace TowerDefense.Graphics.Sfml.Scenes.Objects
{
    public class ShopItem : Image
    {
        public string Description;
        public string ItemName;
        public int ItemCost;
        public string HoverSurfaceName;

        public override void Draw() {
            if (this.HasFocus) {

                // Draw the title
                var lblTitle = new Label() {
                    Caption = this.ItemName,
                    Top = 500,
                    Left = 960,
                    Width = 300,
                    Height = 50
                };
                lblTitle.Draw();

                // Draw the description
                var lblDescription = new Label() {
                    Caption = this.Description,
                    Top = 530,
                    Left = 960,
                    Width = 300,
                    Height = 50
                };
                lblDescription.Draw();
            }
            base.Draw();
        }

        public override void MouseDown(int x, int y) {
            base.MouseDown(x, y);

            ((Sfml)GraphicsManager.Graphics).HoverSurfaceName = this.HoverSurfaceName;
        }
    }
}
