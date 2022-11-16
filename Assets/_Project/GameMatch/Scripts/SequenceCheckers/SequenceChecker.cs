using System.Collections.Generic;
using GameGrid;

namespace GameMatch
{
    public abstract class SequentialChecker
    {
        private static List<GridSlot> _cacheSlots = new();

        public abstract GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix);
        
        public GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix, int sequenceSize)
        {
            if (targetSlot.PlayerType == PlayerType.None)
                return null;

            _cacheSlots.Clear();
            IntVector2 nextCoordinate = GetFirstCoordinate(targetSlot.Coordinate);

            while (IsValidCheckCoordinate(nextCoordinate, slotsMatrix))
            {
                GridSlot currentSlot = slotsMatrix.GetSlot(nextCoordinate);
                nextCoordinate = GetNextCoordinate(nextCoordinate);
                if (!IsFromSamePlayer(targetSlot, currentSlot))
                {
                    _cacheSlots.Clear();
                    continue;
                }
                
                _cacheSlots.Add(currentSlot);
                bool isSequenceComplete = _cacheSlots.Count >= sequenceSize;

                if (isSequenceComplete)
                {
                    return _cacheSlots.ToArray();
                }
            }

            return null;
        }

        protected virtual bool IsValidCheckCoordinate(IntVector2 coordinate, SlotsMatrix slotsMatrix)
        {
            return coordinate.y < slotsMatrix.Y_size;
        }

        private bool IsFromSamePlayer(GridSlot targetSlot, GridSlot otherSlot)
        {
            return otherSlot != null && otherSlot.PlayerType == targetSlot.PlayerType;
        }

        protected abstract IntVector2 GetFirstCoordinate(IntVector2 currentCoordinate);
        protected abstract IntVector2 GetNextCoordinate(IntVector2 currentCoordinate);
    }
}
