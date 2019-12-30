using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Bear : Unit
    {
        public Bear() : base(new UnitBuilder()
            .UnitType(UnitType.BEAR)
            .AttackType(AttackType.MELEE)
            .AttackRange(1)
            .HitPoints(3)
            .Cost(0)
            .Attack(20)
            .Defence(10)
            .MovesCount(5)
            .Damage(new Range<int>(25, 35))
            .Mana(0)
            .Spells(new AncientBonds())
        )
        {
            
        }
    }
}