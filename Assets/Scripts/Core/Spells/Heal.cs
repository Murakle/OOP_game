using Battle.BattleArmy;
using Core.Army;

namespace Core.Spells
{
    public class Heal : Spell
    {
        private int healingPerUnit;
        private int spellRange;

        public Heal() : base(ActiveSpell.HEAL, 30, Target.ALLY_UNIT)
        {
            healingPerUnit = 20;
        }

        public void Use(BattleUnitsStack target)
        {
            int count = target.getcCount();
            //heal;
        }
    }
}