namespace Core.Army
{
    public class UnitBuilder
    {
        private UnitType unitType;
        private int hitPoints;
        private int attack;
        private int defence;

        private Range<int> damage;

        private double initiative;

        private int movesCount;
        private int mana;
        private AttackType attackType;
        private int attackRange;
        private Spell[] spells;
        private int cost;


        public UnitBuilder UnitType(UnitType unitType)
        {
            this.unitType = unitType;
            return this;
        }

        public UnitBuilder HitPoints(int hitPoints)
        {
            this.hitPoints = hitPoints;
            return this;
        }

        public UnitBuilder Attack(int attack)
        {
            this.attack = attack;
            return this;
        }

        public UnitBuilder Defence(int defence)
        {
            this.defence = defence;
            return this;
        }

        public UnitBuilder Damage(Range<int> damage)
        {
            this.damage = damage;
            return this;
        }

        public UnitBuilder Initiative(double initiative)
        {
            this.initiative = initiative;
            return this;
        }

        public UnitBuilder MovesCount(int movesCount)
        {
            this.movesCount = movesCount;
            return this;
        }

        public UnitBuilder Mana(int mana)
        {
            this.mana = mana;
            return this;
        }

        public UnitBuilder AttackType(AttackType attackType)
        {
            this.attackType = attackType;
            return this;
        }

        public UnitBuilder AttackRange(int attackRange)
        {
            this.attackRange = attackRange;
            return this;
        }

        public UnitBuilder Cost(int cost)
        {
            this.cost = cost;
            return this;
        }

        public UnitBuilder Spells(params Spell[] spells)
        {
            this.spells = spells;
            return this;
        }

        public int getCost => cost;

        public Spell[] getSpells => spells;

        public int getAttackRange => attackRange;

        public AttackType getAttackType => attackType;

        public int getMana => mana;

        public int getMovesCount => movesCount;

        public double getInitiative => initiative;

        public Range<int> getDamage => damage;

        public int getDefence => defence;

        public int getAttack => attack;

        public int getHitPoints => hitPoints;

        public UnitType getUnitType => unitType;

        public Unit Build()
        {
            return new Unit(this);
        }
    }
}