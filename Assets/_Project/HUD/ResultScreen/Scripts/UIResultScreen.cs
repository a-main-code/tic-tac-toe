using UnityEngine;
using UnityEngine.UI;
using SceneManagement;
using GameMatch;
using GameGrid;
using DG.Tweening;

namespace HUD
{
    public class UIResultScreen : MonoBehaviour
    {
        [SerializeField] private MatchManager _matchManager;
        [SerializeField] private UIResultFeedbackArea _feedbackArea;
        [SerializeField] private Button _restartButton;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _transitionStrength = 1;
        [SerializeField] private AudioSource _audioSource;

        private const float TRANSITION_TIME = 0.4f;

        private void Awake()
        {
            OpenScreen(false);
            
            _matchManager.OnPlayerWin += PlayerWin;
            _restartButton.onClick.AddListener(Restart);
        }

        private void PlayerWin(PlayerType player)
        {
            Debug.Log($"<b>Player {player} won!</b>");
            OpenScreen(true);
            _feedbackArea.PlayerWin(player);
        }

        private void OpenScreen(bool open)
        {
            float targetAlpha = open ? 1 : 0;
            _canvasGroup.DOFade(targetAlpha, TRANSITION_TIME);
            _canvasGroup.blocksRaycasts = open;
            transform.DOShakeScale(TRANSITION_TIME, _transitionStrength);

            if (open)
            {
                _audioSource.Play();
            }
        }

        private void Restart()
        {
            ScenesManager.ReloadScene();
        }
    }
}
