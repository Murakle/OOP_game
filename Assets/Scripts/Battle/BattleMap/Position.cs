using System;

namespace Battle.BattleMap
{
    public class Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX => x;

        public int getY => y;

        public int getDis(Position p)
        {
            return Math.Abs(p.getX - x) + Math.Abs(p.getY - y);
        }

        public override string ToString()
        {
            return "(" + getX + ", " + getY + ")";
        }

        public bool Equals(Position p)
        {
            return (x == p.x && y == p.y);
        }
    }
}