using TowerDefense.Data.Models.Towers;
using TowerDefense.Data.Models.Viruses;

namespace TowerDefense.Data.Models.Maps
{
    public class Map
    {
        // Map constants
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        public const int WIDTH = 16;
        public const int HEIGHT = 11;

        public Home Home;
        public Tower[] Towers;
        public Virus[] Viruses;
        public Position SpawnLocation;

    }
}
