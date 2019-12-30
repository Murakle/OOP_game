using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using Core.Units;
using Unity;
using UnityEngine;

namespace Core.Spells
{
    public class SummonBear : Spell
    {
        public SummonBear() : base(ActiveSpell.SUMMON_BEAR, 60, Target.CELL)
        {
        }

        public override bool Use(Position place, Position user, GameObject battle, int count, int indx)
        {
            if (!canUse(user, place))
            {
                return false;
            }

            battle.GetComponent<uBattle>()
                .addUnit(new BattleUnitsStack(new UnitsStack(new Bear(), count), place), indx);

            return true;
        }
    }
}