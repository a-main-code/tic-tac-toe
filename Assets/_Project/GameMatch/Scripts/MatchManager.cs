using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameGrid;

namespace GameMatch
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private GridSize _gridSize;
        [SerializeField] private GridArea _grid;

        private void Awake()
        {
            BuildGrid();
        }

        private void BuildGrid()
        {
            _grid.Initialize(_gridSize, OnSlotClicked);
        }

        private void OnSlotClicked(GridSlot slot)
        {
            
        }
    }
}
