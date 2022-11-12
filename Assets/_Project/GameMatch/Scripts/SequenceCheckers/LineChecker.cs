using GameGrid;

namespace GameMatch
{
    public abstract class LineChecker : SequentialChecker
    {
        protected abstract IntVector2 FirstCoordinateMultiplier { get; }
        protected abstract IntVector2 NextCoordinateSum { get; }

        protected override IntVector2 GetFirstCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            return targetSlot.Coordinate * FirstCoordinateMultiplier;
        }

        protected override IntVector2 GetNextCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            return targetSlot.Coordinate + NextCoordinateSum;
        }
    }
}
