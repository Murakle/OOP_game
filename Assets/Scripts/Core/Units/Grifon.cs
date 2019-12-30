using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Grifon : Unit
    {
        
        public Grifon() : base(new UnitBuilder()
                .UnitType(UnitType.GRIFON)
                .AttackType(AttackType.MELEE)
                .AttackRange(1)
                .HitPoints(30)
                .Cost(55)
                .Attack(15)
                .Defence(15)
                .MovesCount(10)
                .Damage(new Range<int>(35, 45))
                .Mana(100)
            //.Spells(Boost(), EagleRoar())
        )
        {
        }
    }
}