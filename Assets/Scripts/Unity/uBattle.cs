using System;
using System.IO;
using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using Core.Units;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

namespace Unity
{
    using Battle = global::Battle.Battle;

    public class uBattle : MonoBehaviour
    {
        private GameObject map;
        private GameObject army1;
        private GameObject army2;

        private BattleUnitsStack activeBUS;
        private int activeSpell = -1;
        private Battle battle;

        [SerializeField] private GameObject CellPrefab;
        [SerializeField] private GameObject BUSPrefab;
        [SerializeField] private GameObject SpellsMenu;

        private void Awake()
        {
            Map m;
            BattleArmy a1;
            BattleArmy a2;

            string[] MapBits = PlayerPrefs.GetString("Map").Split(' ');
            string[] Army1Bits = PlayerPrefs.GetString("Army1").Split(' ');
            string[] Army2Bits = PlayerPrefs.GetString("Army2").Split(' ');

            int h = Convert.ToInt32(MapBits[0]);
            int w = Convert.ToInt32(MapBits[1]);


            int a1Size = Convert.ToInt32(Army1Bits[0]);
            int a2Size = Convert.ToInt32(Army2Bits[0]);

            UnitsStack[] A1 = new UnitsStack[a1Size];
            UnitsStack[] A2 = new UnitsStack[a2Size];

            for (int z = 1, i = 0; i < a1Size; i++, z++)
            {
                if (Army1Bits[z].Equals("0"))
                {
                    A1[i] = null;
                }
                else
                {
                    A1[i] = new UnitsStack(new Unit(Army1Bits[z + 1]), Convert.ToInt32(Army1Bits[z]));
                    z++;
                }
            }

            for (int z = 1, i = 0; i < a2Size; i++, z++)
            {
                if (Army2Bits[z].Equals("0"))
                {
                    A2[i] = null;
                }
                else
                {
                    A2[i] = new UnitsStack(new Unit(Army2Bits[z + 1]), Convert.ToInt32(Army2Bits[z]));
                    z++;
                }
            }

            a1 = new BattleArmy(true, A1);
            a2 = new BattleArmy(false, A2);
            m = new Map(h, w);
            map = GameObject.FindWithTag("Map");
            army1 = GameObject.FindWithTag("Units1");
            army2 = GameObject.FindWithTag("Units2");


            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    var cellClone = Instantiate(CellPrefab, map.transform);
                    cellClone.transform.name = "Cell(" + (i + 1) + "," + (j + 1) + ")";
                    char bit = MapBits[2][i * w + j];

                    m.setMapCell(i, j, bit == '1' ? CellContent.STONE : CellContent.FREE);
                }
            }

            foreach (BattleUnitsStack bus in a1.getcArmy())
            {
                int i = bus.getcPos().getX;
                int j = bus.getcPos().getY;

                var busClone = Instantiate(BUSPrefab, army1.transform);
                busClone.GetComponent<RectTransform>().localPosition = getPos(i, j);
                m.setMapCell(i, j, CellContent.UNIT1);
            }

            foreach (BattleUnitsStack bus in a2.getcArmy())
            {
                int i = bus.getcPos().getX;
                int j = bus.getcPos().getY;

                var busClone = Instantiate(BUSPrefab, army2.transform);
                busClone.GetComponent<RectTransform>().localPosition = getPos(i, j);
                m.setMapCell(i, j, CellContent.UNIT2);
            }

            map.GetComponent<uMap>().fill(m);
            army1.GetComponent<uBattleArmy>().fill(a1);
            army2.GetComponent<uBattleArmy>().fill(a2);
            battle = new Battle(a1, a2, m);
            activeBUS = battle.Begin(true);
            map.GetComponent<uMap>().Recolor();
            activeSpell = -1;
            SpellsMenu.GetComponent<BattleMenu>().RefreshSpells(activeBUS);
        }


        public void OnCellClick(Position p)
        {
            if (battle.getBattleState() != Battle.BattleState.FIRST_PLAYER_MOVE &&
                battle.getBattleState() != Battle.BattleState.SECOND_PLAYER_MOVE)
            {
                return;
            }

            bool madeMove = false;
            if (activeSpell == -1)
            {
                switch (battle.getMap().getMapCell(p.getX, p.getY).getContent())
                {
                    case CellContent.UNIT1:
                        if (battle.getBattleState() == Battle.BattleState.SECOND_PLAYER_MOVE)
                        {
                            BattleUnitsStack b1 = battle.order2.getFirst();
                            BattleUnitsStack b2 = battle.getBUSwithPos(1, p);

                            if (b2 == null)
                                return;
                            madeMove = Attack(b1, b2);
                        }
                        else
                            return;

                        break;
                    case CellContent.UNIT2:
                        if (battle.getBattleState() == Battle.BattleState.FIRST_PLAYER_MOVE)
                        {
                            BattleUnitsStack b1 = battle.order1.getFirst();
                            BattleUnitsStack b2 = battle.getBUSwithPos(2, p);
                            if (b2 == null)
                                return;
                            madeMove = Attack(b1, b2);
                        }
                        else
                            return;

                        break;
                    case CellContent.FREE:
                        BattleUnitsStack b = battle.getBattleState() == Battle.BattleState.FIRST_PLAYER_MOVE
                            ? battle.order1.getFirst()
                            : battle.order2.getFirst();
                        if (battle.getBattleState() == Battle.BattleState.FIRST_PLAYER_MOVE)
                        {
                            var bb = army1.GetComponent<uBattleArmy>().getUBUS(b.getcPos());
                            madeMove = bb.GetComponent<uBattleUnitsStack>().Move(p);
                        }
                        else
                        {
                            var bb = army2.GetComponent<uBattleArmy>().getUBUS(b.getcPos());
                            madeMove = bb.GetComponent<uBattleUnitsStack>().Move(p);
                        }

                        break;
                    case CellContent.STONE:
                        return;
                }
            }
            else
            {
                Spell s = activeBUS.getSpell(activeSpell);
                Spell.Target t = activeBUS.getType().getSpell(activeSpell).getSpellTarget();
                if (s.isSummonBear())
                {
                    madeMove = s.Use(map.GetComponent<uMap>().getCell(p).getPos(), p, gameObject, activeBUS.Count,
                        getBS() == Battle.BattleState.FIRST_PLAYER_MOVE ? 1 : 2);
                }
                else if (t == Spell.Target.CELL &&
                         !battle.getMap().getMapCell(p.getX, p.getY).gotSpell())
                {
                    madeMove = s.Use(activeBUS.getcPos(), map.GetComponent<uMap>().getCell(p));
                }
                else
                {
                    switch (battle.getMap().getMapCell(p.getX, p.getY).getContent())
                    {
                        case CellContent.FREE:
                            break;
                        case CellContent.UNIT1:
                            uBattleUnitsStack busAtP1 = army1.GetComponent<uBattleArmy>().getUBUS(p)
                                .GetComponent<uBattleUnitsStack>();
                            if (getBS() == Battle.BattleState.FIRST_PLAYER_MOVE && t == Spell.Target.ALLY_UNIT)
                            {
                                madeMove = s.Use(activeBUS.getcPos(), busAtP1);
                            }

                            if (getBS() == Battle.BattleState.SECOND_PLAYER_MOVE && t == Spell.Target.ENEMY_UNIT)
                            {
                                madeMove = s.Use(activeBUS.getcPos(), busAtP1);
                            }

                            break;
                        case CellContent.UNIT2:
                            uBattleUnitsStack busAtP2 = army2.GetComponent<uBattleArmy>().getUBUS(p)
                                .GetComponent<uBattleUnitsStack>();
                            if (getBS() == Battle.BattleState.SECOND_PLAYER_MOVE && t == Spell.Target.ALLY_UNIT)
                            {
                                madeMove = s.Use(activeBUS.getcPos(), busAtP2);
                            }

                            if (getBS() == Battle.BattleState.FIRST_PLAYER_MOVE && t == Spell.Target.ENEMY_UNIT)
                            {
                                madeMove = s.Use(activeBUS.getcPos(), busAtP2);
                            }

                            break;
                        case CellContent.STONE:
                            break;
                        default:
                            if (t == Spell.Target.ALL_ENEMY_UNITS)
                            {
                                if (getBS() == Battle.BattleState.FIRST_PLAYER_MOVE)
                                {
                                    madeMove = s.Use(activeBUS.getcPos(), army1.GetComponent<uBattleArmy>());
                                }
                                else
                                {
                                    madeMove = s.Use(activeBUS.getcPos(), army2.GetComponent<uBattleArmy>());
                                }
                            }

                            break;
                    }
                }
            }


            if (madeMove)
            {
                DoDamageFromCells();
                if (getBS() == Battle.BattleState.FIRST_PLAYER_MOVE)
                {
                    battle.order1.NormalMove();
                }
                else
                {
                    battle.order2.NormalMove();
                }

                battle.Refresh();
                CheckForEnd();


                if (getBS() != Battle.BattleState.END)
                {
                    activeSpell = -1;
                    activeBUS = battle.nextTern();
                    map.GetComponent<uMap>().Recolor();
                    SpellsMenu.GetComponent<BattleMenu>().RefreshSpells(activeBUS);
                }
            }
        }

        private void DoDamageFromCells()
        {
            int[,] damages = map.GetComponent<uMap>().getDamage();
            army1.GetComponent<uBattleArmy>().doDamageFromCells(damages);
            army2.GetComponent<uBattleArmy>().doDamageFromCells(damages);
        }

        public bool Attack(BattleUnitsStack bus1, BattleUnitsStack bus2)
        {
            if (!bus1.Attack(bus2)) return false;
            ClearArmyies();
            ClearMap();
            return true;
        }

        public void addUnit(BattleUnitsStack bus, int indx)
        {
            int i = bus.getcPos().getX;
            int j = bus.getcPos().getY;

            var busClone = Instantiate(BUSPrefab, indx == 1 ? army1.transform : army2.transform);
            busClone.GetComponent<RectTransform>().localPosition = getPos(i, j);
            (indx == 1 ? army1 : army2).GetComponent<uBattleArmy>().Add(bus, bus.getcPos());
            map.GetComponent<uMap>().addUnit(bus.getcPos(), indx);
        }

        public void ClearArmyies()
        {
            battle.Clear();
        }

        public void ClearMap()
        {
            battle.getMap().Clear(battle.getArmy(0), battle.getArmy(1));
        }


        public void CheckForEnd()
        {
            if (battle.order1.Free() || battle.order2.Free())
            {
                battle.End(battle.order1.Free(), battle.order2.Free());
                Debug.Log(battle.Br);
                SceneManager.LoadScene("MainMenu");
            }
        }

        public bool Near(Position p)
        {
            if (battle.getBattleState() == Battle.BattleState.FIRST_PLAYER_MOVE)
            {
                return battle.order1.getFirst().canMove(p);
            }

            return battle.order2.getFirst().canMove(p);
        }

        public Battle.BattleState getBS()
        {
            return battle.getBattleState();
        }

        public bool goodSpellUsing(Spell s, bool enemy, Cell c)
        {
            if (s.getSpellType() == Spell.SpellType.PASSIVE)
            {
            }
            else
            {
                Battle.BattleState bs = getBS();
                Spell.Target t = s.getSpellTarget();
                CellContent content = c.getContent();
                if (t == Spell.Target.CELL && content != CellContent.STONE || t == Spell.Target.ALL_ENEMY_UNITS ||
                    t == Spell.Target.SELF)
                    return true;
                return (!enemy || t != Spell.Target.ALLY_UNIT) && (enemy || t != Spell.Target.ENEMY_UNIT);
            }

            return false;
        }

        private Vector3 getPos(int i, int j)
        {
            return new Vector3(-715 + j * 110, 495 - (i + 1) * 110, 0);
        }

        private void MadeMove()
        {
        }

        public bool SpellClicked(int indx)
        {
            if (activeBUS.haveMana(activeBUS.getSpell(indx).getManaCost()))
            {
                activeSpell = indx;
                return true;
            }

            return false;
        }
    }
}