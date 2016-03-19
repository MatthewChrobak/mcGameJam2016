namespace TowerDefense.Data.Models.Viruses
{
    public class PathFinding
    {
        public Directions[] getPath(int mapNumber) {
            switch (mapNumber) {
                case 1:
                    return new Directions[] { Directions.SOUTH, Directions.SOUTH, Directions.EAST, Directions.EAST, Directions.SOUTH,
            Directions.SOUTH, Directions.EAST, Directions.EAST, Directions.SOUTH, Directions.SOUTH, Directions.EAST,
            Directions.SOUTH, Directions.SOUTH, Directions.WEST, Directions.WEST, Directions.WEST, Directions.WEST, Directions.SOUTH,
            Directions.SOUTH, Directions.EAST, Directions.EAST, Directions.SOUTH, Directions.EAST, Directions.EAST, Directions.EAST,
            Directions.EAST, Directions.EAST, Directions.NORTH, Directions.NORTH, Directions.SOUTH, Directions.EAST, Directions.SOUTH,
            Directions.SOUTH, Directions.EAST, Directions.SOUTH, Directions.SOUTH, Directions.WEST, Directions.WEST, Directions.SOUTH,
            Directions.SOUTH, Directions.SOUTH, Directions.EAST, Directions.EAST, Directions.SOUTH, Directions.EAST, Directions.EAST,
            Directions.EAST, Directions.SOUTH, Directions.SOUTH, Directions.SOUTH, Directions.WEST, Directions.SOUTH, Directions.SOUTH,
            Directions.EAST, Directions.SOUTH, Directions.SOUTH, Directions.SOUTH, Directions.SOUTH };
            }

            return null;
        }
    }
}
