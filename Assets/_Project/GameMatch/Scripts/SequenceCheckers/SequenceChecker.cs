using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameGrid;
using System;

namespace GameMatch
{
    public abstract class SequentialChecker
    {
        private static List<GridSlot> _cacheSlots = new();

        public abstract GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix);
        
        protected GridSlot[] GetSequentialSlots(GridSlot targetSlot, SlotsMatrix slotsMatrix, int sequenceSize)
        {
            if (targetSlot.PlayerType == PlayerType.None)
                return null;

            _cacheSlots.Clear();
            GridSlot currentSlot = slotsMatrix.GetSlot(GetFirstCoordinate(targetSlot));

            for (int slotId = 0; slotId < sequenceSize; slotId++)
            {
                if (!IsFromSamePlayer(targetSlot, currentSlot))
                    return null;
                
                _cacheSlots.Add(currentSlot);
                currentSlot = slotsMatrix.GetSlot(GetNextCoordinate(currentSlot));
            }

            return _cacheSlots.ToArray();
        }

        private bool IsFromSamePlayer(GridSlot targetSlot, GridSlot otherSlot)
        {
            return otherSlot != null && otherSlot.PlayerType == targetSlot.PlayerType;
        }

        protected abstract IntVector2 GetFirstCoordinate(GridSlot targetSlot);
        protected abstract IntVector2 GetNextCoordinate(GridSlot targetSlot);
    }
}
