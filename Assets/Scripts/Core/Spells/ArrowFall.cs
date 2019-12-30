using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using Unity;
using UnityEngine;

namespace Core.Spells
{
    public class ArrowFall : Spell
    {
        private int spellRange;

        public ArrowFall() : base(ActiveSpell.ARROW_FALL, 40, Target.CELL)
        {
            setColor(Color.red);
            damage = 40;
        }


        private int damage;

        public override int getDamage()
        {
            return damage;
        }
    }
}