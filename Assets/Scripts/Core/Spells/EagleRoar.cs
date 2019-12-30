using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class EagleRoar : Spell
    {
        public EagleRoar() : base(ActiveSpell.EAGLE_ROAR, 50, Target.ENEMY_UNIT)
        {
            
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}