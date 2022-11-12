namespace GameGrid
{
    public enum PlayerType
    {
        None = -1,
        X = 0,
        O = 1,
    }

    public static class PlayerTypeHelpers
    {
        public const int Count = 2;

        public static string ToFriendlyString(this PlayerType playerType)
        {
            return playerType == PlayerType.None ?
                "" :
                playerType.ToString();
        }
    }
}
