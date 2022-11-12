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

        public GridSlot[] GetSequentialSlots(GridSlot targetSlot, GridSlot[][] slotsGrid, int sequenceSize)
        {
            _cacheSlots.Clear();
            GridSlot currentSlot = GetFirstSlot(targetSlot, slotsGrid);

            for (int slotId = 0; slotId < sequenceSize; slotId++)
            {
                if (!IsFromSamePlayer(targetSlot, currentSlot))
                    return null;
                
                _cacheSlots.Add(currentSlot);
                currentSlot = GetNextSlot(targetSlot, slotsGrid);
            }

            return _cacheSlots.ToArray();
        }

        private bool IsFromSamePlayer(GridSlot targetSlot, GridSlot otherSlot)
        {
            return otherSlot != null && otherSlot.PlayerType == targetSlot.PlayerType;
        }

        private GridSlot GetFirstSlot(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            return GetSlot(GetFirstCoordinate(targetSlot, slotsGrid), slotsGrid);
        }

        private GridSlot GetNextSlot(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            return GetSlot(GetNextCoordinate(targetSlot, slotsGrid), slotsGrid);
        }

        private GridSlot GetSlot(IntVector2 coordinate, GridSlot[][] slotsGrid)
        {
            if (coordinate.y >= slotsGrid.Length || coordinate.x >= slotsGrid[coordinate.y].Length)
                return null;
            
            return slotsGrid[coordinate.x][coordinate.y];
        }

        protected abstract IntVector2 GetFirstCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid);
        protected abstract IntVector2 GetNextCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid);
    }
}
