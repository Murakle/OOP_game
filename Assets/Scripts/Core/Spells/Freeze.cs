using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class Freeze : Spell
    {
        public Freeze() : base(PassiveSpell.FREEZE, PassiveCondition.ON_GETTING_ATTACK, Target.ENEMY_UNIT)
        {
            
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}