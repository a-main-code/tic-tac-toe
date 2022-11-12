using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameGrid
{
    public class GridArea : MonoBehaviour
    {
        [SerializeField] private GridLine _gridLinePrefab;

        public List<GridSlot> Initialize(IntVector2 gridSize, Action<GridSlot> onSlotClicked)
        {
            List<GridSlot> slots = new();
            for (int i = 0; i < gridSize.x; i++)
            {
                GridLine line = CreateLine(i, gridSize.y, onSlotClicked);
                slots.AddRange(line.Slots);
            }
            return slots;
        }

        private GridLine CreateLine(int lineId, int width, Action<GridSlot> onSlotClicked)
        {
            GridLine line = Instantiate<GridLine>(_gridLinePrefab, transform);
            line.Initialize(lineId, width, onSlotClicked);
            return line;
        }
    }
}
