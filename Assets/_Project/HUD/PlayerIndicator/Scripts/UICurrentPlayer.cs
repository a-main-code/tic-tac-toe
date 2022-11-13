using UnityEngine;
using GameMatch;
using GameGrid;

namespace HUD
{
    public class UICurrentPlayer : MonoBehaviour
    {
        [SerializeField] private MatchManager _matchManager;
        [SerializeField] private PlayerSymbol _playerSymbol;
        
        private void Awake()
        {
            _matchManager.OnCurrentPlayerChanged += SetPlayer;
        }

        private void SetPlayer(PlayerType player)
        {
            _playerSymbol.SetPlayer(player);
        }
    }
}
