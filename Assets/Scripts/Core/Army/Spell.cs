using Battle.BattleArmy;
using Battle.BattleMap;
using Unity;
using UnityEngine;

namespace Core.Army
{
    public class Spell
    {
        private SpellType spellType;
        private int manaCost;
        private Target t;
        private int castRange;
        private ActiveSpell activeSpell;
        private PassiveSpell passiveSpell;
        private PassiveCondition passiveCondition;
        private Color bColor;

        public enum SpellType
        {
            PASSIVE,
            ACTIVE
        }

        public enum Target
        {
            ALL_ENEMY_UNITS,
            ENEMY_UNIT,
            ALLY_UNIT,
            CELL,
            SELF
        }


        public Spell(ActiveSpell activeSpell, int manaCost, Target target)
        {
            castRange = 5;
            spellType = SpellType.ACTIVE;
            this.activeSpell = activeSpell;
            this.manaCost = manaCost;
            t = target;
        }

        public Spell(ActiveSpell activeSpell, int manaCost, Target target, int CR)
        {
            castRange = CR;
            spellType = SpellType.ACTIVE;
            this.activeSpell = activeSpell;
            this.manaCost = manaCost;
            t = target;
        }

        public Spell(PassiveSpell passiveSpell, PassiveCondition condition, Target target)
        {
            castRange = (int) 1e9;
            spellType = SpellType.PASSIVE;
            this.passiveSpell = passiveSpell;
            passiveCondition = condition;
            manaCost = 0;
            t = target;
        }

        public void setColor(Color c)
        {
            bColor = c;
        }

        public Color getColor()
        {
            return bColor;
        }


        public virtual bool Use(Position p, uCell c)
        {
            if (!canUse(p, c.GetComponent<uCell>().getPos()))
            {
                return false;
            }

            c.GetComponent<uCell>().useSpell(bColor, this);
            return true;
        }

        public virtual bool Use(Position userPos, uBattleUnitsStack b)
        {
            return false;
        }

        public virtual bool Use(Position userPos, uBattleArmy a)
        {
            return false;
        }


        public virtual bool canUse(Position user, Position target)
        {
            return user.getDis(target) <= castRange;
        }

        public SpellType getSpellType()
        {
            return spellType;
        }

        public string getSpellName()
        {
            if (spellType == SpellType.PASSIVE)
            {
                return passiveSpell.getSpellName();
            }

            return activeSpell.getSpellName();
        }

        public int getManaCost()
        {
            return manaCost;
        }

        public Target getSpellTarget()
        {
            return t;
        }

        public bool isSummonBear()
        {
            return spellType == SpellType.ACTIVE && activeSpell == ActiveSpell.SUMMON_BEAR;
        }

        public virtual bool Use(Position userPos, Position position, GameObject battle, int activeBusCount, int i)
        {
            return false;
        }

        public virtual int getDamage()
        {
            return 0;
        }
    }
}