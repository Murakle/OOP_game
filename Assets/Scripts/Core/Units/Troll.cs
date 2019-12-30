using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Troll : Unit
    {
        public Troll() : base(new UnitBuilder()
            .UnitType(UnitType.TROLL)
            .AttackType(AttackType.MELEE)
            .AttackRange(2)
            .HitPoints(80)
            .Cost(60)
            .Attack(20)
            .Defence(5)
            .MovesCount(4)
            .Damage(new Range<int>(45, 55))
            .Mana(100)
            .Spells(new Rage(), new DoubleDamage())
        )
        {
        }
    }
}