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
        [SerializeField] private PlayerType _currentPlayer;

        private void Awake()
        {
            BuildGrid();
            SelectFirstPlayer();
        }

        private void BuildGrid()
        {
            _grid.Initialize(_gridSize, OnSlotClicked);
        }

        private void OnSlotClicked(GridSlot slot)
        {
            // TODO: Regras quando é clicado no slot
        }

        private void SelectFirstPlayer()
        {
            bool isXPlayer = UnityEngine.Random.Range(0, 2) == 0;
            
            _currentPlayer = isXPlayer ?
                PlayerType.X :
                PlayerType.O;
        }
    }
}
