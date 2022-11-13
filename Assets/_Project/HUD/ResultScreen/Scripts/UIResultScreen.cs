using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SceneManagement;
using GameMatch;
using GameGrid;
using DG.Tweening;

namespace HUD
{
    public class UIResultScreen : MonoBehaviour
    {
        [SerializeField] private MatchManager _matchManager;
        [SerializeField] private PlayerSymbol _playerSymbol;
        [SerializeField] private Button _restartButton;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _transitionStrength = 1;

        private const float TRANSITION_TIME = 0.4f;

        private void Awake()
        {
            OpenScreen(false);
            
            _matchManager.OnPlayerWin += PlayerWin;
            _restartButton.onClick.AddListener(Restart);
        }

        private void PlayerWin(PlayerType player)
        {
            OpenScreen(true);
            _playerSymbol.SetPlayer(player);
        }

        private void OpenScreen(bool open)
        {
            float targetAlpha = open ? 1 : 0;
            _canvasGroup.DOFade(targetAlpha, TRANSITION_TIME);
            _canvasGroup.blocksRaycasts = open;
            transform.DOShakeScale(TRANSITION_TIME, _transitionStrength);
        }

        private void Restart()
        {
            ScenesManager.ReloadScene();
        }
    }
}
