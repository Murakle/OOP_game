using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using Unity;
using UnityEngine;

namespace Core.Spells
{
    public class BernGround : Spell
    {
        public BernGround() : base(ActiveSpell.BERN_GROUND, 33, Target.CELL)
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