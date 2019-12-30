using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class HeadShot : Spell
    {

        public HeadShot() : base(PassiveSpell.HEADSHOT, PassiveCondition.ON_ATTACK, Target.ENEMY_UNIT)
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