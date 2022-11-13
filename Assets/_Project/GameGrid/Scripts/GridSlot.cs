using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameGrid
{
    public class GridSlot : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private IntVector2 _coordinate;
        [SerializeField] private PlayerSymbol _playerSymbol;

        public PlayerType PlayerType => _playerSymbol.PlayerType;
        public IntVector2 Coordinate => _coordinate;

        private Action<GridSlot> onSlotClicked;

        private void Awake()
        {
            _button.onClick.AddListener(() => onSlotClicked.Invoke(this));
        }

        internal void Initialize(IntVector2 coordinate, Action<GridSlot> onSlotClicked)
        {
            _coordinate = coordinate;
            this.onSlotClicked = onSlotClicked;
        }

        public void SetPlayer(PlayerType playerType)
        {
            bool isFree = playerType == PlayerType.None;
            _button.interactable = isFree;
            _playerSymbol.SetPlayer(playerType);
        }
    }
}
