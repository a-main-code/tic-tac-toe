using GameGrid;

namespace GameMatch
{
    public class HorizontalChecker : LineChecker
    {
        private IntVector2 _nextCoordinateSum = new IntVector2(1, 0);

        protected override IntVector2 NextCoordinateSum => _nextCoordinateSum;

        public override GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix)
        {
            return GetSequentialSlots(targetSlot, slotsMatrix, slotsMatrix.X_size);
        }

        protected override IntVector2 GetFirstCoordinate(GridSlot targetSlot)
        {
            return new IntVector2(0, targetSlot.Coordinate.x);
        }
    }
}
