using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using Unity;
using UnityEngine;

namespace Core.Spells
{
    public class PumpkinBomb : Spell
    {
        public PumpkinBomb() : base(ActiveSpell.PUMPKIN_BOMB, 40, Target.CELL)
        {
            setColor(new Color(232, 126, 4, 1));
            damage = 40;
        }
        private int damage;

        public override int getDamage()
        {
            return damage;
        }
    }
}