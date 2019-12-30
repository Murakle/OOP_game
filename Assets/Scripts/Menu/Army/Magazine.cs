using System;
using System.Collections;
using System.Collections.Generic;
using Core.Army;
using Menu.Army;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    private void OnEnable()
    {
        UnselectAll();
        transform.GetChild(0).GetComponent<BuyUS>().Select();
    }

    public void Selected(UnitType selected)
    {
        transform.parent.GetChild(1).GetComponent<Buying>().Selected(selected);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("ESCAPED");
            transform.parent.gameObject.SetActive(false);
        }
    }

    public void UnselectAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<BuyUS>().Unselect();
        }
    }
}