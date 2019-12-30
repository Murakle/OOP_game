using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Elf : Unit
    {
        public Elf() : base(new UnitBuilder()
                .UnitType(UnitType.ELF)
                .AttackType(AttackType.RANGE)
                .AttackRange(7)
                .HitPoints(50)
                .Cost(45)
                .Attack(20)
                .Defence(5)
                .MovesCount(4)
                .Damage(new Range<int>(45, 55))
                .Mana(100)
            .Spells(new HeadShot(), new ArrowFall())
        )
        {
        }
    }
}