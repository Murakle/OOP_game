using System;
using System.Data;
using Battle.BattleArmy;
using Core.Army;
using Core.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.BattleMap
{
    public class Cell
    {
        private CellContent content;
        private bool haveSpell;
        private Spell usedSpell;


//        public Cell(CellContent content, BattleUnitsStack battleUnitsStack)
//        {
//            this.content = content;
//        }

        public Cell(CellContent content)
        {
            haveSpell = false;
            this.content = content;
        }

        public CellContent getContent()
        {
            return content;
        }

        public void setContent(CellContent c)
        {
            content = c;
        }

        public void setSpell(Spell s)
        {
            haveSpell = true;
            usedSpell = s;
        }

        public bool gotSpell()
        {
            return haveSpell;
        }

        public Color getSpellColor()
        {
            if (usedSpell == null)
            {
                throw new DataException();
            }

            return usedSpell.getColor();
        }

        public int getSpellDamage()
        {
            return usedSpell.getDamage();
        }

        public string getSpellName()
        {
            return usedSpell.getSpellName();
        }
    }

    
}