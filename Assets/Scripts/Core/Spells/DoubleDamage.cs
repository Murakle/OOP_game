using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class DoubleDamage : Spell
    {
        public DoubleDamage() : base(PassiveSpell.DOUBLE_DAMAGE, PassiveCondition.ON_ATTACK, Target.SELF)
        {
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
        }
    }
}