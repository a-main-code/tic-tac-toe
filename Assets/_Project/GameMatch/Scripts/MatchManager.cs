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
        public event UnityAction<PlayerType> OnPlayerWin;


        private void Awake()
        {
            BuildGrid();            
            SelectFirstPlayer();
        }

        private void BuildGrid()
        {
            _grid.CreateSlots(_gridSize, OnSlotClicked);
            _winChecker.SetSlotsMatrix(_grid.GetSlotsMatrix());
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
                OnPlayerWin?.Invoke(_currentPlayer);
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
