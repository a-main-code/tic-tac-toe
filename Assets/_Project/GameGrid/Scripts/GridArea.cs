using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameGrid
{
    public class GridArea : MonoBehaviour
    {
        [SerializeField] private GridLine _gridLinePrefab;
        private List<GridLine> _lines = new();

        public SlotsMatrix CreateSlots(IntVector2 gridSize, Action<GridSlot> onSlotClicked)
        {
            CreateLines(lineWidth: gridSize.x, quantity: gridSize.y, onSlotClicked);
            return GetSlotsMatrix();
        }

        private void CreateLines(int lineWidth, int quantity, Action<GridSlot> onSlotClicked)
        {
            for (int lineId = 0; lineId < quantity; lineId++)
            {
                GridLine line = CreateLine(lineWidth, lineId, onSlotClicked);
                _lines.Add(line);
            }
        }

        private GridLine CreateLine(int width, int lineId, Action<GridSlot> onSlotClicked)
        {
            GridLine line = Instantiate<GridLine>(_gridLinePrefab, transform);
            line.Initialize(width, lineId, onSlotClicked);
            return line;
        }

        private SlotsMatrix GetSlotsMatrix()
        {
            GridSlot[][] slotsGrid = new GridSlot[_lines.Count][];
            
            for (int lineId = 0; lineId < _lines.Count; lineId++)
            {
                GridLine line = _lines[lineId];
                slotsGrid[lineId] = line.Slots;
            }
            return new SlotsMatrix(slotsGrid);
        }
    }
}
