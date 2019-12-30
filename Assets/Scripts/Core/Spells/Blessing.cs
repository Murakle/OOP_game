using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class Blessing : Spell
    {
        private int spellRange;

        public Blessing() : base(ActiveSpell.BLESSING, 40, Target.ALLY_UNIT)
        {
        }

        public void Use(BattleUnitsStack target)
        {
            
        }
    }
}