using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
