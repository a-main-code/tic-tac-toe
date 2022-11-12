using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameGrid
{
    public class GridLine : MonoBehaviour
    {
        [SerializeField] private GridSlot _slotPrefab;
        private List<GridSlot> slots;

        public List<GridSlot> Slots => slots;

        public List<GridSlot> Initialize(int lineId, int width, Action<GridSlot> onSlotClicked)
        {
            slots = new();
            
            for (int i = 0; i < width; i++)
            {
                IntVector2 coordinate = new IntVector2(i, lineId);
                slots.Add(CreateSlot(coordinate, onSlotClicked));
            }
            return slots;
        }

        private GridSlot CreateSlot(IntVector2 coordinate, Action<GridSlot> onSlotClicked)
        {
            GridSlot slot = Instantiate<GridSlot>(_slotPrefab, transform);
            slot.Initialize(coordinate, onSlotClicked);
            return slot;
        }
    }
}
