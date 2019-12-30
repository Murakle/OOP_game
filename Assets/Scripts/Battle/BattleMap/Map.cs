using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Battle.BattleArmy;
using UnityEngine;

namespace Battle.BattleMap
{
    public class Map : IEnumerable<Cell>
    {
        private int HH;
        private int WW;
        private Cell[,] map;


        public void Clear(BattleArmy.BattleArmy army1, BattleArmy.BattleArmy army2)
        {
            for (int i = 0; i < HH; i++)
            {
                for (int j = 0; j < WW; j++)
                {
                    if (!army1.haveBUSwithPos(new Position(i, j)) && !army2.haveBUSwithPos(new Position(i, j)))
                    {
                        map[i, j].setContent(CellContent.FREE);
                    }
                    else
                    {
                        if (army1.haveBUSwithPos(new Position(i, j)))
                            map[i, j].setContent(CellContent.UNIT1);
                        else if (army2.haveBUSwithPos(new Position(i, j)))
                            map[i, j].setContent(CellContent.UNIT2);
                    }
                }
            }
        }

        public int getHH()
        {
            return HH;
        }

        public int getWW()
        {
            return WW;
        }

        public Cell getMapCell(int x, int y)
        {
            return map[x, y];
        }

        public void setMapCell(int x, int y, CellContent c)
        {
            map[x, y] = new Cell(c);
        }

        public Map(int h, int w, Cell[,] map)
        {
            HH = h;
            WW = w;
            this.map = map;
            if (h != map.GetLength(0) || (h > 0 && map.GetLength(1) != w))
            {
                throw new System.ArgumentException("Map size not equal to h, w ");
            }
        }

        public Map(int h, int w)
        {
            HH = h;
            WW = w;
            map = new Cell[h, w];
            for (int i = 0; i < HH; i++)
            {
                for (int j = 0; j < WW; j++)
                {
                    map[i, j] = new Cell(CellContent.FREE);
                }
            }
        }

        public int getDis(BattleUnitsStack b, Position p)
        {
            return p.getDis(b.getcPos());
        }

        IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
        {
            for (int i = 0; i < WW; i++)
            {
                for (int j = 0; j < HH; j++)
                {
                    yield return map[j, i];
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < WW; i++)
            {
                for (int j = 0; j < HH; j++)
                {
                    yield return map[j, i];
                }
            }
        }
    }
}