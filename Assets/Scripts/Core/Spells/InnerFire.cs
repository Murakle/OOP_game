using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class InnerFire : Spell
    {
        public InnerFire() : base(PassiveSpell.INNER_FIRE, PassiveCondition.ON_ATTACK, Target.ENEMY_UNIT)
        {
            damage = 40;
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }

        private int damage;

        public override int getDamage()
        {
            return damage;
        }
    }
}