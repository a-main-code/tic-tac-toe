using System;
using TMPro;

namespace HUD
{
    [Serializable]
    public class TextReference
    {
        public TextMeshProUGUI textComponent;
        public string text;

        public void ApplyText()
        {
            textComponent.text = text;
        }
    }
}
