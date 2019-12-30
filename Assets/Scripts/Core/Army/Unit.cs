using Core.Units;

namespace Core.Army
{
    public class Unit
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
        protected Spell[] spells;
        private int cost;

        public Unit(UnitType unitType, int HitPoints, int Attack, int Defence, Range<int> Damage, double Initiative,
            int MovesCount, AttackType AttackT, int AttackRange, int mana, int cost, params Spell[] spells)
        {
            this.unitType = unitType;
            this.hitPoints = HitPoints;
            this.attack = Attack;
            this.defence = Defence;
            this.damage = Damage;
            this.initiative = Initiative;
            this.movesCount = MovesCount;
            this.attackType = AttackT;
            this.attackRange = AttackRange;
            this.mana = mana;
            this.spells = spells;
            this.cost = cost;
        }

        public Unit(UnitType unitType, int HitPoints, int Attack, int Defence, Range<int> Damage, double Initiative,
            int MovesCount, AttackType AttackT, int AttackRange, params Spell[] spells)
        {
            this.unitType = unitType;
            this.hitPoints = HitPoints;
            this.attack = Attack;
            this.defence = Defence;
            this.damage = Damage;
            this.initiative = Initiative;
            this.movesCount = MovesCount;
            this.attackType = AttackT;
            this.attackRange = AttackRange;
            this.mana = 100;
            this.spells = spells;
            this.cost = 50;
        }

        public Unit(string name) : this(UnitType.NULL.setFromString(name))
        {
        }

        public Unit(UnitType type)
        {
            Unit res = type.getUnit();
            this.unitType = res.unitType;
            this.hitPoints = res.HitPoints;
            this.attack = res.Attack;
            this.defence = res.Defence;
            this.damage = res.Damage;
            this.initiative = res.Initiative;
            this.movesCount = res.MovesCount;
            this.attackType = res.AttackT;
            this.attackRange = res.AttackRange;
            this.mana = res.mana;
            this.spells = res.spells;
            this.cost = res.cost;
        }

        public Unit(UnitBuilder unitBuilder)
        {
            this.unitType = unitBuilder.getUnitType;
            this.hitPoints = unitBuilder.getHitPoints;
            this.attack = unitBuilder.getAttack;
            this.defence = unitBuilder.getDefence;
            this.damage = unitBuilder.getDamage;
            this.initiative = unitBuilder.getInitiative;
            this.movesCount = unitBuilder.getMovesCount;
            this.mana = unitBuilder.getMana;
            this.attackType = unitBuilder.getAttackType;
            this.attackRange = unitBuilder.getAttackRange;
            this.spells = unitBuilder.getSpells;
            this.cost = unitBuilder.getCost;
        }

        public int MovesCount
        {
            get { return movesCount; }
        }

        public int AttackRange
        {
            get { return attackRange; }
        }

        public Spell[] Spells
        {
            get { return spells; }
        }

        public AttackType AttackT
        {
            get { return attackType; }
        }

        public UnitType Type => unitType;

        public int HitPoints
        {
            get { return hitPoints; }
        }

        public int Mana
        {
            get { return mana; }
        }

        public int Attack
        {
            get { return attack; }
        }

        public int Defence
        {
            get { return defence; }
        }

        public Range<int> Damage
        {
            get { return damage; }
        }

        public int getCost()
        {
            return cost;
        }

        public double Initiative
        {
            get { return initiative; }
        }

        public int getSpellCount()
        {
            return spells.Length;
        }

        public int getActiveSpellCount()
        {
            int ans = 0;
            for (int i = 0; i < spells.Length; i++)
            {
                if (spells[i].getSpellType() == Spell.SpellType.ACTIVE)
                    ans++;
            }

            return ans;
        }

        public int getPassiveSpellCount()
        {
            int ans = 0;
            for (int i = 0; i < spells.Length; i++)
            {
                if (spells[i].getSpellType() == Spell.SpellType.PASSIVE)
                    ans++;
            }

            return ans;
        }

        public override string ToString()
        {
            return "Unit{" +
                   "Type=" + Type +
                   ", HitPoints=" + HitPoints +
                   ", Attack=" + Attack +
                   ", Defence=" + Defence +
                   ", Damage=" + Damage +
                   ", Initiative=" + Initiative +
                   ", MovesCount=" + MovesCount +
                   ", Mana=" + Mana +
                   ", AttackT=" + AttackT +
                   ", AttackRange=" + AttackRange +
                   ", Spells=" + spells +
                   '}';
        }

        public string getSpellName(int indx)
        {
            return spells[indx].getSpellName();
        }

        public int getSpellCost(int indx)
        {
            return spells[indx].getManaCost();
        }

        public Spell getSpell(int indx)
        {
            return spells[indx];
        }
    }
}