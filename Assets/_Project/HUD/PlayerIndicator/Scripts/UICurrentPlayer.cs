using UnityEngine;
using GameMatch;
using GameGrid;
using TMPro;

namespace HUD
{
    public class UICurrentPlayer : MonoBehaviour
    {
        [SerializeField] private MatchManager _matchManager;
        [SerializeField] private TextMeshProUGUI _playerText;
        
        private void Awake()
        {
            _matchManager.OnCurrentPlayerChanged += SetPlayer;
        }

        private void SetPlayer(PlayerType player)
        {
            _playerText.text = player.ToFriendlyString();
        }
    }
}
