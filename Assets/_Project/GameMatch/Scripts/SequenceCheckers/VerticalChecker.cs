using GameGrid;

namespace GameMatch
{
    public class VerticalChecker : LineChecker
    {
        private IntVector2 _nextCoordinateSum = new IntVector2(0, 1);

        protected override IntVector2 NextCoordinateSum => _nextCoordinateSum;

        public override GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix)
        {
            return GetSequentialSlots(targetSlot, slotsMatrix, sequenceSize: slotsMatrix.Y_size);
        }

        protected override IntVector2 GetFirstCoordinate(IntVector2 currentCoordinate)
        {
            return new IntVector2(currentCoordinate.x, 0);
        }
    }
}
