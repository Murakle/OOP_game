using System;
using Battle.BattleMap;
using Core.Army;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class uCell : MonoBehaviour
    {
        private GameObject Tip;
        private GameObject map;
        private Cell c;
        private Color BasicColor = Color.white;
        private Position p;
        private bool onFocus;
        private bool Underlined;


        public bool OnFocus()
        {
            return onFocus;
        }

        public void DeleteUnit()
        {
            c.setContent(CellContent.FREE);
            BasicColor = Color.white;
        }

        private void OnMouseEnter()
        {
            if (c.getContent() == CellContent.FREE)
            {
                ChangeColor(Color.green);
                onFocus = true;
            }
            else if (c.getContent() == CellContent.UNIT1 || c.getContent() == CellContent.UNIT2 ||
                     c.getContent() == CellContent.STONE)
            {
                ChangeColor(Color.red);
                onFocus = false;
            }

            Tip.SetActive(true);
//            Debug.Log((c.gotSpell() ? c.getSpellName() : c.getContent().ConvertToString()));
            Tip.GetComponent<Tip>().SetText("" + (c.gotSpell() ? c.getSpellName() : c.getContent().ConvertToString()));
        }

        private void OnMouseExit()
        {
            Tip.SetActive(false);
            ChangeColor(BasicColor);
            onFocus = false;
        }

        private void OnMouseDown()
        {
            GameObject battle = GameObject.Find("Battle");
            battle.GetComponent<uBattle>().OnCellClick(p);
            if (c.getContent() == CellContent.UNIT1 || c.getContent() == CellContent.UNIT2)
            {
                ChangeColor(Color.red);
            }
        }

        private void OnMouseUp()
        {
            if (c.getContent() == CellContent.UNIT1 || c.getContent() == CellContent.UNIT2)
            {
                ChangeColor(BasicColor);
            }
        }


        public void fill(Cell c, Position p)
        {
            Tip = GameObject.FindWithTag("Player");
            map = GameObject.FindWithTag("Map");
            this.c = c;
            this.p = p;
            Sprite cur = Resources.Load<Sprite>("grass");
            if (this.c.getContent() == CellContent.STONE)
            {
                cur = Resources.Load<Sprite>("stone");
            }

            transform.GetChild(0).GetComponent<Image>().sprite = cur;
        }


        public void fillContent(CellContent c)
        {
            this.c.setContent(c);
        }

        public void Underline(Battle.Battle.BattleState bs)
        {
            if (c.getContent() == CellContent.UNIT1 && bs == Battle.Battle.BattleState.SECOND_PLAYER_MOVE)
            {
                BasicColor = Color.red;
            }
            else if (c.getContent() == CellContent.UNIT2 && bs == Battle.Battle.BattleState.FIRST_PLAYER_MOVE)
            {
                BasicColor = Color.red;
            }
            else
            {
                BasicColor = (Color.magenta + BasicColor) / 2;
            }

            ChangeColor(BasicColor);
        }

        public void Clear()
        {
            if (c.gotSpell())
            {
                BasicColor = c.getSpellColor();
            }
            else
            {
                BasicColor = Color.white;
            }

            ChangeColor(BasicColor);
        }

        private void ChangeColor(Color c)
        {
            transform.GetChild(0).GetComponent<Image>().color = c;
        }

        public Position getPos()
        {
            return p;
        }

        public void useSpell(Color color, Spell s)
        {
            BasicColor = color;
            ChangeColor(color);
            c.setSpell(s);
        }
    }
}