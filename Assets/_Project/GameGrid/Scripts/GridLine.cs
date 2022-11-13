using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameGrid
{
    public class GridLine : MonoBehaviour
    {
        [SerializeField] private GridSlot _slotPrefab;
        private List<GridSlot> _slots = new();

        public GridSlot[] Slots => _slots.ToArray();

        public void CreateSlots(int width, int lineId, Action<GridSlot> onSlotClicked)
        {            
            for (int slotId = 0; slotId < width; slotId++)
            {
                IntVector2 coordinate = new IntVector2(slotId, lineId);
                
                GridSlot slot = CreateSlot(coordinate, onSlotClicked);
                _slots.Add(slot);
            }
        }

        private GridSlot CreateSlot(IntVector2 coordinate, Action<GridSlot> onSlotClicked)
        {
            GridSlot slot = Instantiate<GridSlot>(_slotPrefab, transform);
            slot.Initialize(coordinate, onSlotClicked);
            return slot;
        }
    }
}
