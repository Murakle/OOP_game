using Core.Units;

namespace Core.Army
{
    public enum UnitType
    {
        NULL,
        ANGEL,
        DRAGON,
        DRUID,
        ELF,
        GHOST,
        GRIFON,
        HYDRA,
        LICH,
        SHAMAN,
        TROLL,
        BEAR
    }

    public static class UnitTypeMethods
    {
        public static string getFilePath(this UnitType type)
        {
            switch (type)
            {
                case UnitType.ANGEL:
                    return "Units/Angel";
                case UnitType.DRAGON:
                    return "Units/Dragon";
                case UnitType.DRUID:
                    return "Units/Druid";
                case UnitType.ELF:
                    return "Units/Elf";
                case UnitType.GHOST:
                    return "Units/Ghost";
                case UnitType.GRIFON:
                    return "Units/Grifon";
                case UnitType.HYDRA:
                    return "Units/Hydra";
                case UnitType.LICH:
                    return "Units/Lich";
                case UnitType.SHAMAN:
                    return "Units/Shaman";
                case UnitType.TROLL:
                    return "Units/Troll";
                default:
                    return "Menu/plus";
            }
        }

        public static int getCost(this UnitType type)
        {
            switch (type)
            {
                case UnitType.ANGEL:
                    return new Angel().getCost();
                case UnitType.DRAGON:
                    return new Dragon().getCost();
                case UnitType.DRUID:
                    return new Druid().getCost();
                case UnitType.ELF:
                    return new Elf().getCost();
                case UnitType.GHOST:
                    return new Ghost().getCost();
                case UnitType.GRIFON:
                    return new Grifon().getCost();
                case UnitType.HYDRA:
                    return new Hydra().getCost();
                case UnitType.LICH:
                    return new Lich().getCost();
                case UnitType.SHAMAN:
                    return new Shaman().getCost();
                case UnitType.TROLL:
                    return new Troll().getCost();
                default:
                    return 0;
            }
        }

        public static UnitType setFromString(this UnitType type, string t)
        {
            UnitType res;
            switch (t)
            {
                case "ANGEL":
                    res = UnitType.ANGEL;
                    break;
                case "DRAGON":
                    res = UnitType.DRAGON;
                    break;
                case "DRUID":
                    res = UnitType.DRUID;
                    break;
                case "ELF":
                    res = UnitType.ELF;
                    break;
                case "GHOST":
                    res = UnitType.GHOST;
                    break;
                case "GRIFON":
                    res = UnitType.GRIFON;
                    break;
                case "HYDRA":
                    res = UnitType.HYDRA;
                    break;
                case "LICH":
                    res = UnitType.LICH;
                    break;
                case "SHAMAN":
                    res = UnitType.SHAMAN;
                    break;
                default:
                    res = UnitType.TROLL;
                    break;
            }
            type = res;
            return res;
        }

        public static Unit getUnit(this UnitType type)
        {
            switch (type)
            {
                case UnitType.ANGEL:
                    return new Angel();
                case UnitType.DRAGON:
                    return new Dragon();
                case UnitType.DRUID:
                    return new Druid();
                case UnitType.ELF:
                    return new Elf();
                case UnitType.GHOST:
                    return new Ghost();
                case UnitType.HYDRA:
                    return new Hydra();
                case UnitType.LICH:
                    return new Lich();
                case UnitType.SHAMAN:
                    return new Shaman();
                default:
                    return new Troll();
            }
        }
    }
}