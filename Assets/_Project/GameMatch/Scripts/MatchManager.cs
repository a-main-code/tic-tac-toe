using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameGrid;

namespace GameMatch
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private IntVector2 _gridSize;
        [SerializeField] private GridArea _grid;
        [SerializeField] private PlayerType _currentPlayer;

        public PlayerType CurrentPlayer => _currentPlayer;

        public event UnityAction<PlayerType> OnCurrentPlayerChanged;


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
            SetPlayer(UnityEngine.Random.Range(0, PlayerTypeHelpers.Count));
        }

        private void NextPlayer()
        {
            SetPlayer((int)_currentPlayer + 1);
        }

        private void SetPlayer(int playerId)
        {
            _currentPlayer = (PlayerType)(playerId % PlayerTypeHelpers.Count);
            OnCurrentPlayerChanged?.Invoke(_currentPlayer);
        }
    }
}
