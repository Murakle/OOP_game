using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Dragon : Unit
    {
        public Dragon() : base(new UnitBuilder()
            .UnitType(UnitType.DRAGON)
            .AttackType(AttackType.MELEE)
            .AttackRange(2)
            .HitPoints(80)
            .Cost(100)
            .Attack(20)
            .Defence(15)
            .MovesCount(6)
            .Damage(new Range<int>(55, 65))
            .Mana(100)
            .Spells(new BernGround(), new InnerFire())
        )
        {
        }
    }
}