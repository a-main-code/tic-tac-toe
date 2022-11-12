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

        public GridSlot[] GetSequentialSlots(GridSlot targetSlot, GridSlot[][] slotsGrid)
        {
            return GetSequentialSlots(targetSlot, slotsGrid, slotsGrid.Length);
        }

        public GridSlot[] GetSequentialSlots(GridSlot targetSlot, GridSlot[][] slotsGrid, int sequenceSize)
        {
            if (targetSlot.PlayerType == PlayerType.None)
                return null;

            _cacheSlots.Clear();
            GridSlot currentSlot = GetFirstSlot(targetSlot, slotsGrid);

            for (int slotId = 0; slotId < sequenceSize; slotId++)
            {
                if (!IsFromSamePlayer(targetSlot, currentSlot))
                    return null;
                
                _cacheSlots.Add(currentSlot);
                currentSlot = GetNextSlot(currentSlot, slotsGrid);
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
            if (!IsInInterval(coordinate.y, 0, slotsGrid.Length) ||
                !IsInInterval(coordinate.x, 0, slotsGrid[coordinate.y].Length)
            )
                return null;
            
            GridSlot slot = slotsGrid[coordinate.y][coordinate.x];
            return slot;
        }

        private bool IsInInterval(int value, int minInclusive, int maxExclusive)
        {
            return value >= minInclusive && value < maxExclusive;
        }

        protected abstract IntVector2 GetFirstCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid);
        protected abstract IntVector2 GetNextCoordinate(GridSlot targetSlot, GridSlot[][] slotsGrid);
    }
}
