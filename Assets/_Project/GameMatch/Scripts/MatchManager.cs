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
            slot.SetPlayer(_currentPlayer);
            NextPlayer();
        }

        private void SelectFirstPlayer()
        {
            _currentPlayer = (PlayerType)UnityEngine.Random.Range(0, PlayerTypeHelpers.Count);
        }

        private void NextPlayer()
        {
            int nextPlayerId = (int)_currentPlayer + 1;
            _currentPlayer = (PlayerType)(nextPlayerId % PlayerTypeHelpers.Count);
        }
    }
}
