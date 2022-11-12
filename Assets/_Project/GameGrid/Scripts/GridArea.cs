using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameGrid
{
    public class GridArea : MonoBehaviour
    {
        [SerializeField] private GridLine _gridLinePrefab;

        public void Initialize(IntVector2 gridSize, Action<GridSlot> onSlotClicked)
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                CreateLine(i, gridSize.y, onSlotClicked);
            }
        }

        private void CreateLine(int lineId, int width, Action<GridSlot> onSlotClicked)
        {
            GridLine line = Instantiate<GridLine>(_gridLinePrefab, transform);
            line.Initialize(lineId, width, onSlotClicked);
        }
    }
}
