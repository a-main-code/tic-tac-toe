using UnityEngine;
using GameGrid;

namespace HUD
{
    public class UIResultFeedbackArea : MonoBehaviour
    {
        [SerializeField] private PlayerSymbol _playerSymbol;
        [NonReorderable] [SerializeField] private TextReference[] _tieTextsReferences;

        public void PlayerWin(PlayerType player)
        {
            if (player != PlayerType.None)
            {
                _playerSymbol.SetPlayer(player);
            }
            else
            {
                ApplyTexts();
            }
        }

        private void ApplyTexts()
        {
            foreach (var textReference in _tieTextsReferences)
            {
                textReference.ApplyText();
            }
        }
    }
}
