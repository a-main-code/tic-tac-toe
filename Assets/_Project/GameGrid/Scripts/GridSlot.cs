using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace GameGrid
{
    public class GridSlot : MonoBehaviour
    {
        [SerializeField] private PlayersCustomizationData _customizationData;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _playerText;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private PlayerType _playerType;
        [SerializeField] private IntVector2 _coordinate;

        public PlayerType PlayerType => _playerType;
        public IntVector2 Coordinate => _coordinate;

        private Action<GridSlot> onSlotClicked;

        private void Awake()
        {
            _button.onClick.AddListener(() => onSlotClicked.Invoke(this));
            SetPlayer(_playerType);
        }

        internal void Initialize(IntVector2 coordinate, Action<GridSlot> onSlotClicked)
        {
            _playerText.color = Color.white;
            _coordinate = coordinate;
            this.onSlotClicked = onSlotClicked;
        }

        public void SetPlayer(PlayerType playerType)
        {
            _playerType = playerType;
            bool isFree = playerType == PlayerType.None;

            ApplyCustomization(_customizationData.GetCustomization(playerType));
            _button.interactable = isFree;
        }

        private void ApplyCustomization(PlayerCustomizationModel playerCustomization)
        {
            SetText(playerCustomization.playerType.ToFriendlyString());
            _playerText.color = playerCustomization.markBackgroundColor;

            _playerText.transform.DOPunchScale(
                Vector3.one * 0.2f,
                _customizationData.animationTime,
                vibrato: _customizationData.vibrato,
                elasticity: _customizationData.elasticity);
        }

        private void SetText(string playerName)
        {
            _playerText.text = playerName;
        }
    }
}
