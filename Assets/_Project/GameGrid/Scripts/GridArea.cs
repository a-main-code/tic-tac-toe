using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameGrid
{
    public class GridArea : MonoBehaviour
    {
        [SerializeField] private GridLine _gridLinePrefab;

        public SlotsMatrix Initialize(IntVector2 gridSize, Action<GridSlot> onSlotClicked)
        {
            GridSlot[][] slotsGrid = new GridSlot[gridSize.y][];
            for (int lineId = 0; lineId < gridSize.y; lineId++)
            {
                GridLine line = CreateLine(gridSize.x, lineId, onSlotClicked);
                slotsGrid[lineId]  = line.Slots;
            }
            return new SlotsMatrix(slotsGrid);
        }

        private GridLine CreateLine(int width, int lineId, Action<GridSlot> onSlotClicked)
        {
            GridLine line = Instantiate<GridLine>(_gridLinePrefab, transform);
            line.Initialize(width, lineId, onSlotClicked);
            return line;
        }
    }
}
