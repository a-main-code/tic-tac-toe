using System;

namespace GameGrid
{
    [Serializable]
    public class IntVector2
    {
        public int x;
        public int y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public IntVector2(IntVector2 toClone)
        {
            x = toClone.x;
            y = toClone.y;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public static IntVector2 operator *(IntVector2 vector1, IntVector2 vector2)
        {
            return new IntVector2(vector1.x * vector2.x, vector1.y * vector2.y);
        }

        public static IntVector2 operator +(IntVector2 vector1, IntVector2 vector2)
        {
            return new IntVector2(vector1.x + vector2.x, vector1.y + vector2.y);
        }
    }
}
