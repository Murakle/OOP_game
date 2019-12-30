using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Lich : Unit
    {
        public Lich() : base(new UnitBuilder()
            .UnitType(UnitType.LICH)
            .AttackType(AttackType.MELEE)
            .AttackRange(2)
            .HitPoints(90)
            .Cost(80)
            .Attack(20)
            .Defence(20)
            .MovesCount(4)
            .Damage(new Range<int>(45, 55))
            .Mana(100)
            .Spells(new Freeze(), new LifeSteal())
        )
        {
        }
    }
}