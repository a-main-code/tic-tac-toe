using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameGrid
{
    public class GridArea : MonoBehaviour
    {
        [SerializeField] private GridLine _gridLinePrefab;
        [SerializeField] private float _transitionTime = 0.1f;
        [SerializeField] private float _transitionStrength = 0.1f;
        [SerializeField] private AudioSource _audioSource;
        private List<GridLine> _lines = new();


        public void CreateSlots(IntVector2 gridSize, Action<GridSlot> onSlotClicked)
        {
            Action<GridSlot> gridRegisteredOnClick = (slot) => {
                this.OnSlotClicked(slot);
                onSlotClicked.Invoke(slot);
            };
            CreateLines(lineWidth: gridSize.x, quantity: gridSize.y, gridRegisteredOnClick);
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
            line.CreateSlots(width, lineId, onSlotClicked);
            return line;
        }

        public SlotsMatrix GetSlotsMatrix()
        {
            GridSlot[][] slotsGrid = new GridSlot[_lines.Count][];
            
            for (int lineId = 0; lineId < _lines.Count; lineId++)
            {
                GridLine line = _lines[lineId];
                slotsGrid[lineId] = line.Slots;
            }
            return new SlotsMatrix(slotsGrid);
        }

        private void OnSlotClicked(GridSlot slot)
        {
            transform.DOShakeScale(_transitionTime, _transitionStrength);
            _audioSource.Play();
        }
    }
}
