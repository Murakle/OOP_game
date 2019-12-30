using System;
using Battle.BattleMap;
using Core;
using Core.Army;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Battle.BattleArmy
{
    using Position = Position;

    public class BattleUnitsStack : UnitsStack, IComparable<BattleUnitsStack>
    {
        private int cCount;
        private int cAttack;
        private int cDefence;
        private Range<int> cDamge;
        private double cInitiative;
        private int cMovesCount;
        private int cMana;
        private Position cPos;
        private int lastHP;

        public BattleUnitsStack(Unit unitType, int Count, Position Pos) : base(unitType, Count)
        {
            cCount = Count;
            cAttack = unitType.Attack;
            cDefence = unitType.Defence;
            cInitiative = unitType.Initiative + Random.Range(0.0f, 0.1f);

            cMovesCount = unitType.MovesCount;
            cDamge = unitType.Damage;
            lastHP = unitType.HitPoints;
            cMana = unitType.Mana;
            cPos = Pos;
        }

        public BattleUnitsStack(UnitsStack us, Position Pos) : this(us.Type, us.Count, Pos)
        {
        }

        public UnitType getTypeShort()
        {
            return Type.Type;
        }

        public Unit getType()
        {
            return unitType;
        }

        public bool Move(Position p)
        {
            if (!canMove(p)) return false;
            cPos = p;
            return true;
        }

        public bool canMove(Position p)
        {
            return cPos.getDis(p) <= cMovesCount;
        }

        public int getcCount()
        {
            return cCount;
        }

        public int getcAttack()
        {
            return cAttack;
        }

        public Range<int> getcDamage()
        {
            return cDamge;
        }

        public Position getcPos()
        {
            return cPos;
        }

        public double getRandomIncDamage()
        {
            double p = Random.Range(0.0f, 1.0f);
            return cDamge.From + (cDamge.To - cDamge.From) * p;
        }

        public int getcDefence()
        {
            return cDefence;
        }

        public double getcInitiative()
        {
            return cInitiative;
        }

        public int getcMovesCount()
        {
            return cMovesCount;
        }

        public int getLastHP()
        {
            return lastHP;
        }


        public bool Attack(BattleUnitsStack b)
        {
            int totalDamage = 0;
            if (cAttack > b.getcDefence())
            {
                totalDamage = (int) (cCount * getRandomIncDamage() * (1 + 0.05 * (cAttack - b.cDefence)));
            }
            else
            {
                totalDamage = (int) (cCount * getRandomIncDamage() / (1 + 0.05 * (b.cDefence - cAttack)));
            }

            int backDamage = 0;
            if (b.cAttack > cDefence)
            {
                backDamage = (int) (b.cCount * b.getRandomIncDamage() * (1 + 0.05 * (b.cAttack - cDefence)));
            }
            else
            {
                backDamage = (int) (b.cCount * b.getRandomIncDamage() / (1 + 0.05 * (cDefence - b.cAttack)));
            }

            if (canAttack(b))
            {
                Debug.Log(this.getTypeShort() + " Attacking " + b.getTypeShort() + " with " + totalDamage + " dmg");
                int bHP = b.Type.HitPoints;
                b.cCount -= totalDamage / bHP;
                b.lastHP -= totalDamage % bHP;
                if (b.lastHP <= 0)
                {
                    b.lastHP += bHP;
                    b.cCount--;
                }

                if (b.canAttack(this))
                {
                    Debug.Log(b.getTypeShort() + " Attacking Back " + getTypeShort() + " with " + backDamage + " dmg");
                    int cHP = Type.HitPoints;
                    cCount -= backDamage / cHP;
                    lastHP -= totalDamage % cHP;
                    if (lastHP <= 0)
                    {
                        lastHP += cHP;
                        cCount--;
                    }
                }

                return true;
            }

            return false;
        }

        public bool canAttack(BattleUnitsStack b)
        {
            return true;
        }


        public void Refresh()
        {
            cAttack = Type.Attack;
            cDefence = Type.Defence;
            cInitiative = Type.Initiative + Random.Range(0.0f, 0.1f);
            cMovesCount = Type.MovesCount;
            cDamge = Type.Damage;
        }

        public bool Block()
        {
            Debug.Log(getTypeShort() + " Blocking");
            cDefence = (int) (1.3 * cDefence);
            return true;
        }

        public bool wait()
        {
            Debug.Log(getTypeShort() + " Waiting");
            return true;
        }

        public bool Dead()
        {
            return cCount < 1 || (cCount == 1 && getLastHP() == 0);
        }

        public override string ToString()
        {
            return "BUS{" + Type.Type + "; Count=" + cCount + "; Attack=" + cAttack + "; Def=" + cDefence +
                   "; Init=" +
                   cInitiative + "; Pos=" + cPos + "; lastHP=" + lastHP + "; Mana=" + cMana + "}";
        }


        public int CompareTo(BattleUnitsStack other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return cInitiative.CompareTo(other.cInitiative);
        }

        public bool haveMana(int mana)
        {
            return mana <= cMana;
        }

        public Spell getSpell(int activeSpell)
        {
            if (activeSpell != -1)
            {
                return unitType.getSpell(activeSpell);
            }

            throw new IndexOutOfRangeException();
        }

        public int getSpellCount()
        {
            return unitType.getSpellCount();
        }

        public void doDamage(int d)
        {
            cCount -= d / getType().HitPoints;
            lastHP -= d % getType().HitPoints;
            if (lastHP <= 0)
            {
                lastHP += getType().HitPoints;
                cCount--;
            }
        }
    }
}