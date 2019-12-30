using System;

namespace Core.Army
{
    public class UnitsStack
    {
        protected Unit unitType;
        protected int count;

        public UnitsStack(Unit unitType, int Count)
        {
            this.unitType = unitType;
            if (Count < 0 || Count > 999999)
            {
                Console.WriteLine("Count should be in [0:999999]");
            }

            this.count = Count < 0 ? 0 : (Count <= 999999 ? Count : 999999);
        }

        public Unit Type
        {
            get { return unitType; }
        }

        public int Count
        {
            get { return count; }
        }

        public override string ToString()
        {
            return "UnitsStack{" +
                   "Type=" + unitType +
                   ", Count=" + count +
                   '}';
        }
    }
}