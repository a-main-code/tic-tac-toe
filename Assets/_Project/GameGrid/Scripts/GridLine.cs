using System;
using UnityEngine;

namespace GameGrid
{
    public class GridLine : MonoBehaviour
    {
        [SerializeField] private GridSlot _slotPrefab;

        public void Initialize(int lineId, int width, Action<GridSlot> onSlotClicked)
        {
            for (int i = 0; i < width; i++)
            {
                CreateSlot(new IntVector2(i, lineId), onSlotClicked);
            }
        }

        private void CreateSlot(IntVector2 coordinate, Action<GridSlot> onSlotClicked)
        {
            GridSlot slot = Instantiate<GridSlot>(_slotPrefab, transform);
            slot.Initialize(coordinate, onSlotClicked);
        }
    }
}
