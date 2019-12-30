using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class Boost : Spell
    {

        public Boost() : base(ActiveSpell.BOOST, 50, Target.ALLY_UNIT)
        {
            
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}