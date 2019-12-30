using System;
using System.Collections;
using System.Collections.Generic;
using Battle.BattleArmy;
using TMPro;
using Unity;
using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    [SerializeField] private GameObject uBattle;

    // Start is called before the first frame update
    private void Awake()
    {
//        for (int i = 0; i < transform.childCount; i++)
//        {
//            transform.GetChild(i).gameObject.SetActive(false);
//        }
    }

    public void RefreshSpells(BattleUnitsStack b)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < b.getSpellCount(); i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = b.getSpell(i).getSpellName();
            transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + b.getSpell(i).getManaCost();
        }
    }

    public void SpellClicked(int indx)
    {
        uBattle.GetComponent<uBattle>().SpellClicked(indx);
    }

    public void NextTern(BattleUnitsStack b)
    {
        int c = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < b.getType().getSpellCount(); i++)
        {
            Transform spell = transform.GetChild(i);
            spell.gameObject.SetActive(true);
            spell.GetChild(0).GetComponent<TextMeshProUGUI>().text = b.getType().getSpellName(i);
            spell.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + b.getType().getSpellCost(i);
        }
    }
}