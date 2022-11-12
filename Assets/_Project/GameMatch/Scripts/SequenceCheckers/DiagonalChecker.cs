using GameGrid;

namespace GameMatch
{
    public abstract class DiagonalChecker : SequentialChecker
    {
        protected abstract int Direction { get; }

        protected override IntVector2 GetFirstCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            int x_coordinate = targetSlot.Coordinate.x - (targetSlot.Coordinate.y * Direction);
            return new IntVector2(x_coordinate, 0);
        }

        protected override IntVector2 GetNextCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            IntVector2 nextCoordinate = new IntVector2(targetSlot.Coordinate);
            
            nextCoordinate.x += Direction;
            nextCoordinate.y += 1;

            return nextCoordinate;
        }
    }
}
