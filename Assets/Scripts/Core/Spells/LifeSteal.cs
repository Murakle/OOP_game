using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class LifeSteal : Spell
    {
        public LifeSteal() : base(PassiveSpell.LIFESTEAL, PassiveCondition.ON_ATTACK, Target.SELF)
        {
            
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}