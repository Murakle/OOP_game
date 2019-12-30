using System;
using System.Collections;
using System.Collections.Generic;
using Core.Army;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUS : MonoBehaviour
{
    [SerializeField] private bool firstArmy;
    private int indx;

    public int Indx
    {
        get => indx;
        set => indx = value;
    }

    private bool empty = true;
    private UnitsStack US;

    public UnitsStack getUS()
    {
        return US;
    }

    private void OnMouseDown()
    {
        if (empty && !transform.parent.parent.GetChild(2).gameObject.activeSelf)
        {
            transform.parent.parent.GetComponent<ArmySettings>().SelectedCell(firstArmy, indx);
//            if (US != null)
//            {
//                empty = false;
//            }
        }
    }

    public void Bought(UnitType type, int count)
    {
        US = new UnitsStack(new Unit(type), count);
        empty = false;
        transform.GetChild(0).GetComponent<Image>().sprite = getFromName(US.Type.Type);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "" + count;
    }

    public Sprite getFromName(UnitType type)
    {
        Sprite unit;
        unit = Resources.Load<Sprite>(type.getFilePath());
        return unit;
    }
}