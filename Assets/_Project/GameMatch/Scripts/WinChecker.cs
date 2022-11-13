using System;
using GameGrid;

namespace GameMatch
{
    public class WinChecker
    {
        private SlotsMatrix _slotsMatrix;

        private static SequentialChecker[] _winSequences = new SequentialChecker[]
        {
            new VerticalChecker(),
            new HorizontalChecker(),
            new MainDiagonalChecker(),
            new SecondaryDiagonalChecker(),
        };

        public void SetSlotsMatrix(SlotsMatrix slotsMatrix)
        {
            _slotsMatrix = slotsMatrix;
        }

        public bool HasFinished(GridSlot markedSlot)
        {
            GridSlot[] slotsSequence = GetSequence(markedSlot);            
            bool hasFinished = slotsSequence != null;
            return hasFinished;
        }

        private GridSlot[] GetSequence(GridSlot slot)
        {
            foreach (var sequenceChecker in _winSequences)
            {
                GridSlot[] sequence = sequenceChecker.GetSequentialSlots(slot, _slotsMatrix);
                if (sequence != null)
                {
                    return sequence;
                }
            }

            return null;
        }

        internal bool IsTie()
        {
            return _slotsMatrix.GetFirstSlotOf(PlayerType.None) == null;
        }
    }
}
