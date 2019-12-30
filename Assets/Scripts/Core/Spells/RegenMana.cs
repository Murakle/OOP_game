using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class RegenMana : Spell
    {
        
        public RegenMana() : base(ActiveSpell.REGEN_MANA, 40, Target.ALLY_UNIT)
        {
            
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}