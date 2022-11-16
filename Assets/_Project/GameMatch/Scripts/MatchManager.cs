using UnityEngine;
using UnityEngine.Events;
using GameGrid;

namespace GameMatch
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private IntVector2 _gridSize;
        [SerializeField] private IntVector2 _minRandomSize;
        [SerializeField] private IntVector2 _maxRandomSize;
        [SerializeField] private GridArea _grid;
        [SerializeField] private PlayerType _currentPlayer;
        private WinChecker _winChecker = new();
        private static bool _canApplyRandomSize;

        public PlayerType CurrentPlayer => _currentPlayer;

        public event UnityAction<PlayerType> OnCurrentPlayerChanged;
        public event UnityAction<PlayerType> OnPlayerWin;


        private void Awake()
        {
            BuildGrid();
        }

        private void Start()
        {
            SelectFirstPlayer();
        }

        private void BuildGrid()
        {
            _grid.CreateSlots(GetGridSize(), OnSlotClicked);
            _winChecker.SetSlotsMatrix(_grid.GetSlotsMatrix());
        }

        private IntVector2 GetGridSize()
        {
            if (_canApplyRandomSize)
            {
                _gridSize.x = Random.Range(_minRandomSize.x, _maxRandomSize.x);
                _gridSize.y = Random.Range(_minRandomSize.y, _maxRandomSize.y);
            }
            else
            {
                _canApplyRandomSize = true;
            }
            return _gridSize;
        }

        private void OnSlotClicked(GridSlot slotClicked)
        {
            Debug.Log($"Player {_currentPlayer}: {slotClicked.Coordinate}");
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
            {
                OnPlayerWin?.Invoke(_currentPlayer);
            }
            else
            {
                if (!_winChecker.IsTie())
                {
                    SwitchToNextPlayer();
                }
                else
                {
                    OnPlayerWin?.Invoke(PlayerType.None);
                }
            }
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
