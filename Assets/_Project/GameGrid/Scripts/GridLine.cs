using System;
using UnityEngine;

namespace GameGrid
{
    public class GridLine : MonoBehaviour
    {
        [SerializeField] private GridSlot _slotPrefab;
        private GridSlot[] slots;

        public GridSlot[] Slots => slots;

        public GridSlot[] Initialize(int width, int lineId, Action<GridSlot> onSlotClicked)
        {
            slots = new GridSlot[width];
            
            for (int i = 0; i < width; i++)
            {
                IntVector2 coordinate = new IntVector2(i, lineId);
                slots[i] = CreateSlot(coordinate, onSlotClicked);
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
