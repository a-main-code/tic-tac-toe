using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMatch;
using GameGrid;
using TMPro;

namespace Menu
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
