namespace Battle.BattleMap
{
    public enum CellContent
    {
        FREE = 0,
        STONE, //1
        UNIT1, //2
        UNIT2, //3
    }

    public static class CCM
    {
        public static string ConvertToString(this CellContent c)
        {
            switch (c)
            {
                case CellContent.FREE:
                    return "Free";
                case CellContent.STONE:
                    return "Stone";
                case CellContent.UNIT1:
                    return "Unit 1";
                case CellContent.UNIT2:
                    return "Unit 2";
                default:
                    return "undefined";
            }
        }
    }
}