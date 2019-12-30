using Core.Army;
using Core.Spells;

namespace Core.Units
{
    public class Hydra : Unit
    {
        public Hydra() : base(new UnitBuilder()
                .UnitType(UnitType.HYDRA)
                .AttackType(AttackType.MELEE)
                .AttackRange(2)
                .HitPoints(70)
                .Cost(100)
                .Attack(20)
                .Defence(20)
                .MovesCount(5)
                .Damage(new Range<int>(55, 65))
                .Mana(100)
            .Spells(new HeadTwin(), new AcidCloud())
        )
        {
        }
    }
}