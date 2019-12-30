using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using Core.Units;
using JetBrains.Annotations;
using UnityEngine;

namespace Battle
{
    public class Battle
    {
        public BattleUnitsStacksMoveOrder order1;
        public BattleUnitsStacksMoveOrder order2;
        private BattleArmy.BattleArmy Army1;
        private BattleArmy.BattleArmy Army2;

        private Map map;
        private BattleState BS;
        private BattleResult BR;

        public enum BattleState
        {
            FIRST_PLAYER_MOVE,
            SECOND_PLAYER_MOVE,
            START,
            END
        }

        public enum BattleResult
        {
            DRAW,
            FIRST_WIN,
            SECOND_WIN,
            FIRST_GIVE_UP,
            SECOND_GIVE_UP
        }

        public enum GlobalMoves
        {
            UNIT_MOVE,
            GLOBAL_SPELL,
            GIVE_UP
        }

        public enum UnitMoves
        {
            WAIT,
            BLOCK,
            MOVE,
            ATTACK,
            USE_SPELL
        }

        public Battle(Army Army1, Army Army2)
        {
            BS = BattleState.START;
            this.Army1 = new BattleArmy.BattleArmy(true, Army1);
            this.Army2 = new BattleArmy.BattleArmy(false, Army2);
            Cell[,] q = new Cell[8, 14];
            foreach (BattleUnitsStack battleUnitsStack in this.Army1)
            {
                q[battleUnitsStack.getcPos().getX, battleUnitsStack.getcPos().getY] =
                    new Cell(CellContent.UNIT1);
            }

            foreach (BattleUnitsStack battleUnitsStack in this.Army2)
            {
                q[battleUnitsStack.getcPos().getX, battleUnitsStack.getcPos().getY] =
                    new Cell(CellContent.UNIT2);
            }

            map = new Map(8, 14, q);
        }

        public Battle(Army Army1, Army Army2, Cell[,] content)
        {
//            Debug.Log(Army1.ToString());
//            moves = new StreamReader("Assets/Moves.txt");
            BS = BattleState.START;
            this.Army1 = new BattleArmy.BattleArmy(true, Army1);
            this.Army2 = new BattleArmy.BattleArmy(false, Army2);
            Cell[,] q = content;
            foreach (BattleUnitsStack battleUnitsStack in this.Army1)
            {
                q[battleUnitsStack.getcPos().getX, battleUnitsStack.getcPos().getY] =
                    new Cell(CellContent.UNIT1);
            }

            foreach (BattleUnitsStack battleUnitsStack in this.Army2)
            {
                q[battleUnitsStack.getcPos().getX, battleUnitsStack.getcPos().getY] =
                    new Cell(CellContent.UNIT2);
            }

            map = new Map(8, 14, q);
        }

        public Battle(BattleArmy.BattleArmy army1, BattleArmy.BattleArmy army2, Map content)
        {
            BS = BattleState.START;
            Army1 = army1;
            Army2 = army2;
            map = content;
        }

        public BattleResult Br
        {
            get => BR;
            set => BR = value;
        }

        public BattleUnitsStack Begin(bool firstGoFirst)
        {
            Debug.Log("Start of battle");

            BS = (firstGoFirst ? BattleState.FIRST_PLAYER_MOVE : BattleState.SECOND_PLAYER_MOVE);
            order1 = new BattleUnitsStacksMoveOrder(Army1);
            order2 = new BattleUnitsStacksMoveOrder(Army2);
            return firstGoFirst ? order1.getFirst() : order2.getFirst();
        }

        public void End(bool firstEmpty, bool secondEmpty)
        {
            BS = BattleState.END;
            if (firstEmpty && secondEmpty)
            {
                BR = BattleResult.DRAW;
                return;
            }

            if (firstEmpty)
            {
                BR = BattleResult.SECOND_WIN;
            }
            else
            {
                BR = BattleResult.FIRST_WIN;
            }
        }

        public void Refresh()
        {
            if (order1.Free())
                order1 = new BattleUnitsStacksMoveOrder(Army1);
            if (order2.Free())
                order2 = new BattleUnitsStacksMoveOrder(Army2);
        }

        public BattleState getBattleState()
        {
            return BS;
        }

        public BattleUnitsStack getBUSwithPos(int army, Position p)
        {
            foreach (var BUS in (army == 1 ? Army1 : Army2))
            {
                if (BUS.getcPos() == p)
                {
                    return BUS;
                }
            }

            return null;
        }

        public Map getMap()
        {
            return map;
        }

        public BattleUnitsStack nextTern()
        {
            if (BS == BattleState.FIRST_PLAYER_MOVE)
            {
                BS = BattleState.SECOND_PLAYER_MOVE;
                return order2.getFirst();
            }

            BS = BattleState.FIRST_PLAYER_MOVE;
            return order1.getFirst();
        }

        public BattleArmy.BattleArmy getArmy(int indx)
        {
            return (indx == 1 ? Army1 : Army2);
        }

        public void Clear()
        {
            Army1.Clear();
            Army2.Clear();
        }
    }
}