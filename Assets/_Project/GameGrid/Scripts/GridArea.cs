using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameGrid
{
    public class GridArea : MonoBehaviour
    {
        [SerializeField] private GridLine _gridLinePrefab;

        public void Initialize(GridSize gridSize, Action<GridSlot> onSlotClicked)
        {
            for (int i = 0; i < gridSize.height; i++)
            {
                CreateLine(i, gridSize.width, onSlotClicked);
            }
        }

        private void CreateLine(int lineId, uint width, Action<GridSlot> onSlotClicked)
        {
            GridLine line = Instantiate<GridLine>(_gridLinePrefab, transform);
            line.Initialize(lineId, width, onSlotClicked);
        }
    }
}
