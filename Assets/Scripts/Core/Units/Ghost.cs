using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Ghost : Unit
    {
        public Ghost() : base(new UnitBuilder()
                .UnitType(UnitType.GHOST)
                .AttackType(AttackType.MELEE)
                .AttackRange(1)
                .HitPoints(30)
                .Cost(30)
                .Attack(10)
                .Defence(5)
                .MovesCount(5)
                .Damage(new Range<int>(25, 35))
                .Mana(100)
            .Spells(new PumpkinBomb(), new BatAttack())
        )
        {
        }
    }
}