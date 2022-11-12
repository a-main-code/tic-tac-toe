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
        private GridSlot[][] _slotsGrid;
        private SequentialChecker[] _sequenceCheckers = new SequentialChecker[]
        {
            new VerticalChecker(),
            new HorizontalChecker()
        };

        public PlayerType CurrentPlayer => _currentPlayer;

        public event UnityAction<PlayerType> OnCurrentPlayerChanged;


        private void Awake()
        {
            BuildGrid();
            SelectFirstPlayer();
        }

        private void BuildGrid()
        {
            _slotsGrid = _grid.Initialize(_gridSize, OnSlotClicked);
        }

        private void OnSlotClicked(GridSlot slot)
        {
            slot.SetPlayer(_currentPlayer);

            GridSlot[] slotsSequence = GetSequence(slot);
            bool hasFinished = slotsSequence != null;
            
            if (!hasFinished)
            {
                NextPlayer();
            }
            else
            {
                Debug.Log($"Player {_currentPlayer} won!");
            }
        }

        private GridSlot[] GetSequence(GridSlot slot)
        {
            foreach (var sequenceChecker in _sequenceCheckers)
            {
                GridSlot[] sequence = sequenceChecker.GetSequentialSlots(slot, _slotsGrid);
                if (sequence != null)
                {
                    return sequence;
                }
            }

            return null;
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
