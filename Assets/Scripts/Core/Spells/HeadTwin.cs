using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class HeadTwin : Spell
    {

        public HeadTwin() : base(PassiveSpell.HEAD_TWIN, PassiveCondition.ON_GETTING_ATTACK, Target.SELF)
        {
            
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}