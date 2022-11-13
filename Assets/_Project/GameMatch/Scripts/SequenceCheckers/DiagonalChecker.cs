using GameGrid;
using UnityEngine;

namespace GameMatch
{
    public abstract class DiagonalChecker : SequentialChecker
    {
        protected abstract int Direction { get; }

        public override GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix)
        {
            int y_size = slotsMatrix.Y_size;
            int x_size = slotsMatrix.X_size;
            return GetSequentialSlots(targetSlot, slotsMatrix, Mathf.Min(x_size, y_size));
        }

        protected override IntVector2 GetFirstCoordinate(GridSlot targetSlot)
        {
            int x_coordinate = targetSlot.Coordinate.x - (targetSlot.Coordinate.y * Direction);
            return new IntVector2(x_coordinate, 0);
        }

        protected override IntVector2 GetNextCoordinate(GridSlot targetSlot)
        {
            IntVector2 nextCoordinate = new IntVector2(targetSlot.Coordinate);
            
            nextCoordinate.x += Direction;
            nextCoordinate.y += 1;

            return nextCoordinate;
        }
    }
}
