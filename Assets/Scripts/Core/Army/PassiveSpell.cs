namespace Core.Army
{
    public enum PassiveSpell
    {
        FREEZE,
        HEADSHOT,
        HEAD_TWIN,
        INNER_FIRE,
        DOUBLE_DAMAGE,
        ANCIENT_BONDS,
        LIFESTEAL
    }

    public enum PassiveCondition
    {
        ON_ATTACK,
        ON_GETTING_ATTACK,
    }

    public static class PassiveSpellMethods
    {
        public static string getSpellName(this PassiveSpell passiveSpell)
        {
            switch (passiveSpell)
            {
                case PassiveSpell.FREEZE:
                    return "Freeze";
                case PassiveSpell.HEADSHOT:
                    return "Headshot";
                case PassiveSpell.HEAD_TWIN:
                    return "Head Twin";
                case PassiveSpell.INNER_FIRE:
                    return "Inner Fire";
                case PassiveSpell.DOUBLE_DAMAGE:
                    return "Double Damage";
                case PassiveSpell.ANCIENT_BONDS:
                    return "Ancient Bonds";
                case PassiveSpell.LIFESTEAL:
                    return "Life Steal";
                default:
                    return "NULL";
            }
        }
    }
}