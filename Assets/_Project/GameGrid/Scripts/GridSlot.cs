using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameGrid
{
    public class GridSlot : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _playerText;
        [SerializeField] private PlayerType _playerType;
        [SerializeField] private IntVector2 _coordinate;

        public IntVector2 Coordinate => _coordinate;

        private Action<GridSlot> onSlotClicked;

        private void Awake()
        {
            _button.onClick.AddListener(() => onSlotClicked.Invoke(this));
            SetPlayer(_playerType);
        }

        internal void Initialize(IntVector2 coordinate, Action<GridSlot> onSlotClicked)
        {
            _coordinate = coordinate;
            this.onSlotClicked = onSlotClicked;
        }

        public void SetPlayer(PlayerType playerType)
        {
            _playerType = playerType;
            bool isFree = playerType == PlayerType.None;

            SetText(playerType.ToFriendlyString());
            _button.interactable = isFree;
        }

        private void SetText(string playerName)
        {
            _playerText.text = playerName;
        }
    }
}
