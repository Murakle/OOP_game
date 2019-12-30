using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Angel : Unit
    {
        public Angel() : base(new UnitBuilder()
            .UnitType(UnitType.ANGEL)
            .AttackType(AttackType.RANGE)
            .AttackRange(5)
            .HitPoints(60)
            .Cost(50)
            .Attack(10)
            .Defence(5)
            .MovesCount(5)
            .Damage(new Range<int>(25, 35))
            .Mana(100)
            .Spells(new Heal() , new Blessing())
        )
        {
        }
    }
}