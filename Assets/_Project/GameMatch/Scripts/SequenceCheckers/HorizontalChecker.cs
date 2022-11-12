using GameGrid;

namespace GameMatch
{
    public class HorizontalChecker : LineChecker
    {
        private IntVector2 _firstCoordinateMultiplier = new IntVector2(0, 1);
        private IntVector2 _nextCoordinateSum = new IntVector2(1, 0);

        protected override IntVector2 FirstCoordinateMultiplier => _firstCoordinateMultiplier;
        protected override IntVector2 NextCoordinateSum => _nextCoordinateSum;
    }
}
