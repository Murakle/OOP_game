using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using Unity;

namespace Core.Spells
{
    public class BatAttack : Spell
    {
        public BatAttack() : base(ActiveSpell.BAT_ATTACK, 50, Target.ALL_ENEMY_UNITS)
        {
            damage = 40;
        }

        public override bool Use(Position user, uBattleArmy a)
        {
            return true;
        }
        private int damage;

        public override int getDamage()
        {
            return damage;
        }
    }
}