using System;
using System.Collections;
using System.Collections.Generic;
using Core.Army;
using Menu;
using UnityEngine;

public class ArmySettings : MonoBehaviour
{
    [SerializeField] private GameObject MM;
    private Transform[] units1;
    private Transform[] units2;
    [SerializeField] private int AllMoney;
    private int m1;
    private int m2;
    [SerializeField] private Transform money1;
    [SerializeField] private Transform money2;
    private bool selectedArmy;
    private int selectedCell;

    private void Awake()
    {
        m1 = AllMoney;
        m2 = AllMoney;
        money1.gameObject.SetActive(true);
        money2.gameObject.SetActive(true);
        units1 = new Transform[6];
        units2 = new Transform[6];
        for (int i = 0; i < 6; i++)
        {
            units1[i] = transform.GetChild(0).GetChild(i);
            units2[i] = transform.GetChild(1).GetChild(i);
            units1[i].GetComponent<MenuUS>().Indx = i;
            units2[i].GetComponent<MenuUS>().Indx = i;
        }
    }

    public void SelectedCell(bool firstArmy, int indx)
    {
        selectedArmy = firstArmy;
        selectedCell = indx;
        transform.GetChild(2).gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !transform.GetChild(2).gameObject.activeInHierarchy)
        {
            Debug.Log("ESCAPED");
            MM.SetActive(true);
            UnitsStack[] first = new UnitsStack[6];
            UnitsStack[] second = new UnitsStack[6];
            for (int i = 0; i < 6; i++)
            {
                first[i] = units1[i].GetComponent<MenuUS>().getUS();
                second[i] = units2[i].GetComponent<MenuUS>().getUS();
            }

            Army Army1 = new Army(first);
            Army Army2 = new Army(second);
            MM.GetComponent<MainMenu>().ArmySetter(Army1, Army2);
            gameObject.SetActive(false);
        }
    }

    public void Bought(UnitType t, int count, int price)
    {
        if (selectedArmy)
            m1 -= price;
        else
            m2 -= price;


        transform.GetChild(selectedArmy ? 0 : 1).GetChild(selectedCell).GetComponent<MenuUS>().Bought(t, count);
        transform.GetChild(3).GetComponent<Money>().Refresh();
        transform.GetChild(4).GetComponent<Money>().Refresh();
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public bool SelectedArmy
    {
        get => selectedArmy;
        set => selectedArmy = value;
    }

    public int getMoney()
    {
        return selectedArmy ? m1 : m2;
    }

    public int M1
    {
        get => m1;
        set => m1 = value;
    }

    public int M2
    {
        get => m2;
        set => m2 = value;
    }
}