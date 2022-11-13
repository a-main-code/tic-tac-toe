namespace GameGrid
{
    public class SlotsMatrix
    {
        private GridSlot[][] _slotsMatrix;

        public int X_size => _slotsMatrix[_slotsMatrix.Length - 1].Length;
        public int Y_size => _slotsMatrix.Length;

        public SlotsMatrix(GridSlot[][] slotsMatrix)
        {
            _slotsMatrix = slotsMatrix;
        }

        public GridSlot GetFirstSlotOf(PlayerType playerType)
        {
            for (int y = 0; y < _slotsMatrix.Length; y++)
            {
                for (int x = 0; x < _slotsMatrix[y].Length; x++)
                {
                    var slot = _slotsMatrix[y][x];
                    if (slot.PlayerType == playerType)
                        return slot;
                }
            }
            return null;
        }

        public GridSlot GetSlot(IntVector2 coordinate)
        {
            if (!IsInInterval(coordinate.x, 0, X_size) ||
                !IsInInterval(coordinate.y, 0, Y_size)
            )
                return null;
            
            GridSlot slot = _slotsMatrix[coordinate.y][coordinate.x];
            return slot;
        }

        private bool IsInInterval(int value, int minInclusive, int maxExclusive)
        {
            return value >= minInclusive && value < maxExclusive;
        }
    }
}
