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
        [SerializeField] private TextMeshProUGUI _playerText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private CanvasGroup _canvasGroup;

        private const float TRANSITION_TIME = 1f;

        private void Awake()
        {
            OpenScreen(false);
            
            _matchManager.OnPlayerWin += PlayerWin;
            _restartButton.onClick.AddListener(Restart);
        }

        private void PlayerWin(PlayerType player)
        {
            OpenScreen(true);
            _playerText.text = player.ToFriendlyString();
        }

        private void OpenScreen(bool open)
        {
            float targetAlpha = open ? 1 : 0;
            _canvasGroup.DOFade(targetAlpha, TRANSITION_TIME);
            _canvasGroup.blocksRaycasts = open;
        }

        private void Restart()
        {
            ScenesManager.ReloadScene();
        }
    }
}
