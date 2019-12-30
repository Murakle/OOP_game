using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class Rage : Spell
    {
        
        public Rage() : base(ActiveSpell.RAGE, 50, Target.ALLY_UNIT)
        {
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}