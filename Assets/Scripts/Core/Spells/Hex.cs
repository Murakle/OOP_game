using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class Hex : Spell
    {
        
        public Hex() : base(ActiveSpell.HEX, 40, Target.ENEMY_UNIT)
        {
            
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}