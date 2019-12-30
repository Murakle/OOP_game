using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Battle.BattleMap;
using Core;
using Core.Army;
using UnityEngine;

namespace Battle.BattleArmy
{
    using Position = Position;

    public class BattleArmy : Army, IEnumerable
    {
        private List<BattleUnitsStack> cArmy;

        public BattleArmy(List<UnitsStack> army) //: base(army)
        {
            if (army.Count > 9)
            {
                Console.WriteLine("Max 9 BattleUnitStack");
            }

            cArmy = new List<BattleUnitsStack>();
            for (int i = 0; i < Math.Min(army.Count, 9); i++)
            {
                this.cArmy.Add(new BattleUnitsStack(army[i], new Position(0, i)));
            }
        }

        public BattleUnitsStack getBUS(int index)
        {
            if (index < cArmy.Count && index >= 0)
            {
                return cArmy[index];
            }

            throw new IndexOutOfRangeException("Wrong Index");
        }

        public void setcArmy(BattleUnitsStack[] army)
        {
            cArmy = new List<BattleUnitsStack>(army);
        }

        public BattleArmy(bool First, params UnitsStack[] army) //: base(army)
        {
            if (army.Length > 9)
            {
                Console.WriteLine("Max 9 UnitStack");
            }

            this.cArmy = new List<BattleUnitsStack>();
            for (int i = 0; i < Math.Min(army.Length, 9); i++)
            {
                if (army[i] == null)
                {
                }
                else
                {
                    if (First)
                    {
                        cArmy.Add(new BattleUnitsStack(army[i], new Position(i, 0)));
                    }
                    else
                    {
                        cArmy.Add(new BattleUnitsStack(army[i], new Position(i, 13)));
                    }
                }
            }
        }

        public BattleArmy(bool First, Army army) : this(First, army.getArmy())
        {
        }


        public BattleUnitsStack[] getcArmy()
        {
            return cArmy.ToArray();
        }

        public bool addBattleUnitStack(UnitsStack b, Position position)
        {
            if (cArmy.Count > 8)
            {
                return false;
            }
            else
            {
                cArmy.Add(new BattleUnitsStack(b, position));
                return true;
            }
        }
        
        public bool haveBattleUnitsStack()
        {
            return cArmy.Count > 0;
        }

        public void Clear()
        {
            List<int> forRemove = new List<int>();
            for (int i = 0; i < cArmy.Count; i++)
            {
                if (cArmy[i].Dead())
                {
                    forRemove.Add(i);
                }
            }

            for (int i = forRemove.Count - 1; i >= 0; i--)
            {
                cArmy.RemoveAt(forRemove[i]);
            }
        }

        public void Refresh()
        {
            for (int i = 0; i < cArmy.Count; i++)
            {
                cArmy[i].Refresh();
            }
        }

        public int Length()
        {
            return cArmy.Count;
        }

        public bool haveBUSwithPos(Position p)
        {
            foreach (BattleUnitsStack stack in cArmy)
            {
                if (stack.getcPos().Equals(p)) return true;
            }

            return false;
        }

        public void Remove(int indx)
        {
            cArmy.RemoveAt(indx);
        }

        public IEnumerator<BattleUnitsStack> GetEnumerator()
        {
            for (int i = 0; i < cArmy.Count; i++)
            {
                yield return cArmy[i];
            }
        }

        public override string ToString()
        {
            string res = "Army:\n";
            for (int i = 0; i < cArmy.Count; i++)
            {
                res += "     " + cArmy[i] + "\n";
            }

            return res;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < cArmy.Count; i++)
            {
                yield return cArmy[i];
            }
        }
    }
}