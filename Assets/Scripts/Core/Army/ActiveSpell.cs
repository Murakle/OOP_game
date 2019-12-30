namespace Core.Army
{
    public enum ActiveSpell
    {
        BERN_GROUND,
        BOOST,
        HEAL,
        HEX,
        PUMPKIN_BOMB,
        RAGE,
        SUMMON_BEAR,
        BLESSING,
        BAT_ATTACK,
        EAGLE_ROAR,
        REGEN_MANA,
        ARROW_FALL,
        ACID_CLOUD
    }


    public static class ActiveSpellMethods
    {
        public static string getSpellName(this ActiveSpell activeSpell)
        {
            switch (activeSpell)
            {
                case ActiveSpell.BERN_GROUND:
                    return "Bern Ground";
                case ActiveSpell.BOOST:
                    return "Boost";
                case ActiveSpell.HEAL:
                    return "Heal";
                case ActiveSpell.HEX:
                    return "Hex";
                case ActiveSpell.PUMPKIN_BOMB:
                    return "Pumpkin BOMB";
                case ActiveSpell.RAGE:
                    return "Rage";
                case ActiveSpell.SUMMON_BEAR:
                    return "Summon Bear";
                case ActiveSpell.BLESSING:
                    return "Blessing";
                case ActiveSpell.BAT_ATTACK:
                    return "Bat Attack";
                case ActiveSpell.EAGLE_ROAR:
                    return "Eagle Roar";
                case ActiveSpell.REGEN_MANA:
                    return "Regen Mana";
                case ActiveSpell.ARROW_FALL:
                    return "Arrow fall";
                case ActiveSpell.ACID_CLOUD:
                    return "Acid cloud";
                default:
                    return "NULL";
            }
        }
    }
}