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
        private SlotsMatrix _slotsMatrix;
        private SequentialChecker[] _sequenceCheckers = new SequentialChecker[]
        {
            new VerticalChecker(),
            new HorizontalChecker(),
            new MainDiagonalChecker(),
            new SecondaryDiagonalChecker(),
        };

        public PlayerType CurrentPlayer => _currentPlayer;

        public event UnityAction<PlayerType> OnCurrentPlayerChanged;


        private void Awake()
        {
            BuildGrid(
                winCheckCallback: (bool hasWin) => {
                    if (hasWin)
                        Debug.Log($"Player {_currentPlayer} won!");
                    else
                        SwitchToNextPlayer();
                });
            
            SelectFirstPlayer();
        }

        private void BuildGrid(Action<bool> winCheckCallback)
        {
            Action<GridSlot> onSlotClicked = (slotClicked) => winCheckCallback(HasFinished(slotClicked));
            _slotsMatrix = _grid.Initialize(_gridSize, onSlotClicked);
        }

        private bool HasFinished(GridSlot slotToMark)
        {
            slotToMark.SetPlayer(_currentPlayer);

            GridSlot[] slotsSequence = GetSequence(slotToMark);
            
            bool hasFinished = slotsSequence != null;
            return hasFinished;
        }

        private GridSlot[] GetSequence(GridSlot slot)
        {
            foreach (var sequenceChecker in _sequenceCheckers)
            {
                GridSlot[] sequence = sequenceChecker.GetSequentialSlots(slot, _slotsMatrix);
                if (sequence != null)
                {
                    return sequence;
                }
            }

            return null;
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
