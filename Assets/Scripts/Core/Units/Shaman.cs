using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Shaman : Unit
    {
        
        public Shaman() : base(new UnitBuilder()
                .UnitType(UnitType.SHAMAN)
                .AttackType(AttackType.RANGE)
                .AttackRange(4)
                .HitPoints(60)
                .Cost(60)
                .Attack(10)
                .Defence(5)
                .MovesCount(5)
                .Damage(new Range<int>(25, 35))
                .Mana(100)
            .Spells(new Hex(), new RegenMana())
        )
        {
        }
    }
}