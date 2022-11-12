using System;
using UnityEngine;

namespace GameGrid
{
    public class GridLine : MonoBehaviour
    {
        [SerializeField] private GridSlot _slotPrefab;

        public void Initialize(int lineId, uint width, Action<GridSlot> onSlotClicked)
        {
            for (int i = 0; i < width; i++)
            {
                CreateSlot(onSlotClicked);
            }
        }

        private void CreateSlot(Action<GridSlot> onSlotClicked)
        {
            GridSlot slot = Instantiate<GridSlot>(_slotPrefab, transform);
            slot.Initialize(onSlotClicked);
        }
    }
}
