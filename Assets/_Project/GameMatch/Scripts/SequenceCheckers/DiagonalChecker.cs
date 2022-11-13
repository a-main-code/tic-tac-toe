using GameGrid;
using UnityEngine;

namespace GameMatch
{
    public abstract class DiagonalChecker : SequentialChecker
    {
        protected abstract int Direction { get; }

        public override GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix)
        {
            int sequenceSize = Mathf.Min(slotsMatrix.X_size, slotsMatrix.Y_size);
            return GetSequentialSlots(targetSlot, slotsMatrix, sequenceSize);
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
