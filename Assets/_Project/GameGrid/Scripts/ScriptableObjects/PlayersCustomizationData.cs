using System.Linq;
using UnityEngine;

namespace GameGrid
{
    [CreateAssetMenu(fileName = "PlayersCustomization", menuName = "Players/Customization data")]
    public class PlayersCustomizationData : ScriptableObject
    {
        [NonReorderable]
        public PlayerCustomizationModel[] playersCustomizations;
        public float animationTime = 1f;
        public int vibrato = 10;
        public float elasticity = 1f;

        public PlayerCustomizationModel GetCustomization(PlayerType player)
        {
            return playersCustomizations.FirstOrDefault(customization => customization.playerType == player);
        }
    }
}
