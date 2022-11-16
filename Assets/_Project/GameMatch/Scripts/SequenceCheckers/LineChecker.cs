using GameGrid;

namespace GameMatch
{
    public abstract class LineChecker : SequentialChecker
    {
        protected abstract IntVector2 NextCoordinateSum { get; }

        protected sealed override IntVector2 GetNextCoordinate(IntVector2 currentCoordinate)
        {
            return currentCoordinate + NextCoordinateSum;
        }
    }
}
