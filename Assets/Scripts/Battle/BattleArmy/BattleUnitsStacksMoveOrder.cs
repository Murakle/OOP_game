using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using UnityEngine;

namespace Battle.BattleArmy
{
    public class BattleUnitsStacksMoveOrder
    {
        private List<BattleUnitsStack> cOrder;
        private int notInWaitOrder;

        public BattleUnitsStacksMoveOrder(BattleArmy Army)
        {
            BattleUnitsStack[] units = Army.getcArmy();
            Array.Sort(units);
            cOrder = new List<BattleUnitsStack>(units);
            notInWaitOrder = units.Length;
        }


        public BattleUnitsStack NormalMove()
        {
            Clear();
            if (cOrder.Count > 0)
            {
                BattleUnitsStack res = cOrder[0];
                cOrder.RemoveAt(0);
                notInWaitOrder--;
                return res;
            }
            else
            {
                Debug.Log(cOrder);
                Debug.Log("No more BattleUnitsStack");
                throw new IndexOutOfRangeException("No more BattleUnitsStack");
            }
        }

        public bool canWait()
        {
            return notInWaitOrder > 0;
        }

        public BattleUnitsStack Wait()
        {
            Clear();
            if (cOrder.Count > 0)
            {
                if (!canWait())
                {
                    Debug.Log("Wrong move command(can't wait");
                    return null;
                }

                BattleUnitsStack f = cOrder.First();

                cOrder.RemoveAt(0);
                notInWaitOrder--;
                cOrder.Insert(notInWaitOrder, f);
                return f;
            }
            else
            {
                throw new IndexOutOfRangeException("No more BattleUnitsStack");
            }
        }

        public BattleUnitsStack getFirst()
        {
            Clear();
            if (cOrder.Count > 0)
            {
                return cOrder.First();
            }

            Debug.Log(cOrder);
            throw new IndexOutOfRangeException("No more BattleUnitsStack");
        }

        public void removeFirst()
        {
            cOrder.RemoveAt(0);
        }

        public bool Free()
        {
            Clear();
            return cOrder.Count <= 0;
        }

        public int size()
        {
            return cOrder.Count;
        }

        public override string ToString()
        {
            string res = "Order:{";
            int i = 0;
            foreach (BattleUnitsStack bus in cOrder)
            {
                if (notInWaitOrder == i)
                {
                    res += " ^|^ ";
                }

                i++;
                res += bus.getTypeShort() + "; ";
            }

            return res;
        }

        public void Clear()
        {
            while (cOrder.Count > 0 && cOrder[0].Dead())
            {
                cOrder.RemoveAt(0);
            }
        }
    }
}