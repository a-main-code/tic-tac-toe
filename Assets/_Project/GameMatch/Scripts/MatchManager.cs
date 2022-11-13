using System;
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
        private WinChecker _winChecker = new();

        public PlayerType CurrentPlayer => _currentPlayer;

        public event UnityAction<PlayerType> OnCurrentPlayerChanged;


        private void Awake()
        {
            BuildGrid();            
            SelectFirstPlayer();
        }

        private void BuildGrid()
        {
            SlotsMatrix slotsMatrix = _grid.Initialize(_gridSize, OnSlotClicked);
            _winChecker.SetSlotsMatrix(slotsMatrix);
        }

        private void OnSlotClicked(GridSlot slotClicked)
        {
            WinCheck(HasFinished(slotClicked));
        }

        private bool HasFinished(GridSlot slotToMark)
        {
            slotToMark.SetPlayer(_currentPlayer);
            return _winChecker.HasFinished(slotToMark);
        }

        private void WinCheck(bool hasWin)
        {
            if (hasWin)
                Debug.Log($"Player {_currentPlayer} won!");
            else
                SwitchToNextPlayer();
        }

        private void SelectFirstPlayer()
        {
            int randomPlayerId = UnityEngine.Random.Range(0, PlayerTypeHelpers.Count);
            SetPlayer(randomPlayerId);
        }

        private void SwitchToNextPlayer()
        {
            int nextPlayerId = (int)_currentPlayer + 1;
            SetPlayer(nextPlayerId);
        }

        private void SetPlayer(int playerId)
        {
            _currentPlayer = (PlayerType)(playerId % PlayerTypeHelpers.Count);
            OnCurrentPlayerChanged?.Invoke(_currentPlayer);
        }
    }
}
