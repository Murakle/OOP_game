using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class AncientBonds : Spell
    {
        public AncientBonds() : base(PassiveSpell.ANCIENT_BONDS, PassiveCondition.ON_ATTACK, Target.ALLY_UNIT)
        {
        }

        
    }
}