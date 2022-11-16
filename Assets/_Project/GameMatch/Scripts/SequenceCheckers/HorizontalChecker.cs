using GameGrid;

namespace GameMatch
{
    public class HorizontalChecker : LineChecker
    {
        private IntVector2 _nextCoordinateSum = new IntVector2(1, 0);

        protected override IntVector2 NextCoordinateSum => _nextCoordinateSum;

        protected override bool IsValidCheckCoordinate(IntVector2 coordinate, SlotsMatrix slotsMatrix)
        {
            return coordinate.x < slotsMatrix.X_size;
        }

        public override GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix)
        {
            return GetSequentialSlots(targetSlot, slotsMatrix, sequenceSize: slotsMatrix.X_size);
        }

        protected override IntVector2 GetFirstCoordinate(IntVector2 currentCoordinate)
        {
            return new IntVector2(0, currentCoordinate.y);
        }
    }
}
