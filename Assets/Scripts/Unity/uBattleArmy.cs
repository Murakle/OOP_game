using System;
using System.Collections.Generic;
using Battle.BattleArmy;
using Battle.BattleMap;
using Core.Army;
using UnityEngine;

namespace Unity
{
    public class uBattleArmy : MonoBehaviour
    {
        private BattleArmy a;
        [SerializeField] private GameObject BUSPrefab;

        public void fill(BattleArmy a1)
        {
            a = a1;
            for (int i = 0; i < a.Length(); i++)
            {
                gameObject.transform.GetChild(i).GetComponent<uBattleUnitsStack>().fill(a.getBUS(i));
            }
        }

        public GameObject getUBUS(Position p)
        {
            GameObject res = null;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.childCount < i)
                {
                    Debug.Log("oooPs");
                }

                if (gameObject.transform.GetChild(i).GetComponent<uBattleUnitsStack>().getPos() == p)
                {
                    res = gameObject.transform.GetChild(i).gameObject;
                }
            }

            return res;
        }

        public void Delete(BattleUnitsStack b)
        {
            for (int i = 0; i < a.Length(); i++)
            {
                if (a.getcArmy()[i] == b)
                {
                    a.Remove(i);
                    Destroy(transform.GetChild(i).gameObject);
                    return;
                }
            }
        }

        public void Add(UnitsStack b, Position p)
        {
            a.addBattleUnitStack(b, p);
            transform.GetChild(transform.childCount - 1).GetComponent<uBattleUnitsStack>()
                .fill(a.getBUS(transform.childCount - 1));
        }

        public void doDamageFromCells(int[,] damages)
        {
            foreach (BattleUnitsStack bus in a)
            {
                int d = damages[bus.getcPos().getX, bus.getcPos().getY];
                if (d > 0)
                {
                    Debug.Log("Making damage(" + d + ") on [" + bus.getcPos() + "]");
                    bus.doDamage(d);
                }
            }
        }
    }
}