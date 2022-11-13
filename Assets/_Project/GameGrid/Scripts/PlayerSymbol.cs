using UnityEngine;
using TMPro;
using DG.Tweening;

namespace GameGrid
{
    public class PlayerSymbol : MonoBehaviour
    {
        [SerializeField] private PlayersCustomizationData _customizationData;
        [SerializeField] private TextMeshProUGUI _playerText;
        [SerializeField] private PlayerType _playerType;
        
        public PlayerType PlayerType => _playerType;

        private void Awake()
        {
            SetPlayer(PlayerType);    
        }

        public void SetPlayer(PlayerType playerType)
        {
            _playerType = playerType;
            ApplyCustomization(_customizationData.GetCustomization(playerType));
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
