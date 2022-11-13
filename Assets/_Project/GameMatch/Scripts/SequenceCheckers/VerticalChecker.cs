using GameGrid;

namespace GameMatch
{
    public class VerticalChecker : LineChecker
    {
        private IntVector2 _firstCoordinateMultiplier = new IntVector2(1, 0);
        private IntVector2 _nextCoordinateSum = new IntVector2(0, 1);

        protected override IntVector2 FirstCoordinateMultiplier => _firstCoordinateMultiplier;
        protected override IntVector2 NextCoordinateSum => _nextCoordinateSum;

        public override GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix)
        {
            return GetSequentialSlots(targetSlot, slotsMatrix, slotsMatrix.Y_size);
        }
    }
}
