using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Druid : Unit
    {
        
        public Druid() : base(new UnitBuilder()
                .UnitType(UnitType.DRUID)
                .AttackType(AttackType.MELEE)
                .AttackRange(1)
                .HitPoints(70)
                .Cost(40)
                .Attack(10)
                .Defence(10)
                .MovesCount(5)
                .Damage(new Range<int>(25, 35))
                .Mana(100)
            .Spells(new SummonBear(), new AncientBonds())
        )
        {
        }
    }
}