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

        protected override IntVector2 GetFirstCoordinate(IntVector2 currentCoordinate)
        {
            int x_coordinate = currentCoordinate.x - (currentCoordinate.y * Direction);
            return new IntVector2(x_coordinate, 0);
        }

        protected override IntVector2 GetNextCoordinate(IntVector2 currentCoordinate)
        {
            IntVector2 nextCoordinate = new IntVector2(currentCoordinate);
            
            nextCoordinate.x += Direction;
            nextCoordinate.y += 1;

            return nextCoordinate;
        }
    }
}
