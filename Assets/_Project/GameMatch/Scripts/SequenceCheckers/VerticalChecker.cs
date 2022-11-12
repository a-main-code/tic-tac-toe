using GameGrid;

namespace GameMatch
{
    public class VerticalChecker : SequentialChecker
    {
        protected override IntVector2 GetFirstCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            return new IntVector2(targetSlot.Coordinate.x, 0);
        }

        protected override IntVector2 GetNextCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            return new IntVector2(targetSlot.Coordinate.x, targetSlot.Coordinate.y + 1);
        }
    }
}
