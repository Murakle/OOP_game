using System;
using Battle.BattleArmy;
using Battle.BattleMap;
using UnityEngine;

namespace Unity
{
    public class uMap : MonoBehaviour
    {
        private GameObject battle;

        private Map m;
        private Transform[,] cells;

        public void Recolor()
        {
            for (int i = 0; i < m.getHH(); i++)
            {
                for (int j = 0; j < m.getWW(); j++)
                {
                    gameObject.transform.GetChild(j + i * m.getWW()).GetComponent<uCell>().Clear();
                    if (battle.GetComponent<uBattle>().Near(new Position(i, j)))
                    {
                        gameObject.transform.GetChild(j + i * m.getWW()).GetComponent<uCell>()
                            .Underline(battle.GetComponent<uBattle>().getBS());
                    }
                }
            }
        }

        public uCell getCell(Position p)
        {
            return cells[p.getX, p.getY].GetComponent<uCell>();
        }

        public void fill(Map mm)
        {
            battle = GameObject.Find("Battle");
            m = mm;
            cells = new Transform[mm.getHH(), mm.getWW()];
            for (int i = 0; i < m.getHH(); i++)
            {
                for (int j = 0; j < m.getWW(); j++)
                {
                    cells[i, j] = transform.GetChild(j + i * m.getWW());
                    cells[i, j].GetComponent<uCell>()
                        .fill(m.getMapCell(i, j), new Position(i, j));
                }
            }
        }

        public void addUnit(Position p, int army)
        {
            cells[p.getX, p.getY].GetComponent<uCell>()
                .fillContent(army == 1 ? CellContent.UNIT1 : CellContent.UNIT2);
        }

        public void Refresh()
        {
            for (int i = 0; i < m.getHH(); i++)
            {
                for (int j = 0; j < m.getWW(); j++)
                {
                    CellContent c = m.getMapCell(i, j).getContent();
                }
            }
        }

        public Position ListenToAllCells(Position p)
        {
            for (int i = 0; i < m.getHH(); i++)
            {
                for (int j = 0; j < m.getWW(); j++)
                {
                    if (gameObject.transform.GetChild(j + i * m.getWW()).GetComponent<uCell>().OnFocus())
                    {
//                        gameObject.transform.GetChild(j + i * m.getWW()).GetComponent<uCell>()
//                            .fillContent(m.getMapCell(p.getX, p.getY).getContent());
//                        gameObject.transform.GetChild(p.getY + p.getX * m.getWW()).GetComponent<uCell>()
//                            .fillContent(CellContent.FREE);
//
//                        m.setMapCell(i, j, m.getMapCell(p.getX, p.getY).getContent());
//                        m.setMapCell(p.getX, p.getY, CellContent.FREE);

                        return new Position(i, j);
                    }
                }
            }

            return p;
        }

        public void DeleteUnitAt(Position p)
        {
            cells[p.getX, p.getY].GetComponent<uCell>().DeleteUnit();
            m.setMapCell(p.getX, p.getY, CellContent.FREE);
        }

        public void SwapCells(Position p1, Position p2)
        {
            CellContent content1 = m.getMapCell(p1.getX, p1.getY).getContent();
            CellContent content2 = m.getMapCell(p2.getX, p2.getY).getContent();
            gameObject.transform.GetChild(p1.getY + p1.getX * m.getWW()).GetComponent<uCell>()
                .fillContent(content2);
            gameObject.transform.GetChild(p2.getY + p2.getX * m.getWW()).GetComponent<uCell>()
                .fillContent(content1);

//            m.setMapCell(p1.getX, p1.getY, content1);
//            m.setMapCell(p2.getX, p2.getY, content2);
        }

        public int getWidth()
        {
            return m.getWW();
        }

        public int getHeight()
        {
            return m.getHH();
        }

        public int[,] getDamage()
        {
            int[,] res = new int[m.getHH(), m.getWW()];
            for (int i = 0; i < m.getHH(); i++)
            {
                for (int j = 0; j < m.getWW(); j++)
                {
                    if (m.getMapCell(i, j).gotSpell())
                    {
                        
                        res[i, j] = m.getMapCell(i, j).getSpellDamage();
                    }
                }
            }

            return res;
        }
    }
}