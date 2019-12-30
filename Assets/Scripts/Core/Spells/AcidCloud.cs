using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using Unity;
using UnityEngine;

namespace Core.Spells
{
    public class AcidCloud : Spell
    {
        private int spellRange;


        public AcidCloud() : base(ActiveSpell.ACID_CLOUD, 50, Target.CELL)
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