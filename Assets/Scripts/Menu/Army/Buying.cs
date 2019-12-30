using System;
using System.Collections;
using System.Collections.Generic;
using Core.Army;
using Core.Units;
using UnityEngine;
using UnityEngine.UI;

public class Buying : MonoBehaviour
{
    private int count;

    public int Count
    {
        get => count;
        set => count = value;
    }

    private int maxCount;
    private Unit selectedUnit;

    public Unit SelectedUnit
    {
        get => selectedUnit;
        set => selectedUnit = value;
    }

    private void OnEnable()
    {
        Selected(UnitType.ANGEL);
    }

    public void Selected(UnitType type)
    {
        count = 0;
        selectedUnit = new Unit(type);
        transform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = getFromName(type);
        transform.GetComponent<Slider>().maxValue = getMaxCount();
        transform.GetComponent<Slider>().minValue = 0;
        transform.GetComponent<Slider>().value = 0;
    }

    public Sprite getFromName(UnitType type)
    {
        Sprite unit;
        unit = Resources.Load<Sprite>(type.getFilePath());
        return unit;
    }

    public int getMaxCount()
    {
        Transform p = transform.parent.parent;
        int m = p.GetComponent<ArmySettings>().getMoney();
        maxCount = m / selectedUnit.getCost();
        return maxCount;
    }

    public void Buy()
    {
        Transform p = transform.parent.parent;
        if ((int) transform.GetComponent<Slider>().value >= 1 &&
            transform.GetComponent<Slider>().value * selectedUnit.getCost() <=
            p.GetComponent<ArmySettings>().getMoney())
        {
            p.GetComponent<ArmySettings>()
                .Bought(selectedUnit.Type, (int) transform.GetComponent<Slider>().value,
                    (int) (transform.GetComponent<Slider>().value * selectedUnit.getCost()));
        }
        else
        {
            Debug.Log("NOt enough Money, shto stranno");
        }
    }
}