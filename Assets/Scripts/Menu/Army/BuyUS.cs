using System;
using Core.Army;
using Core.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Army
{
    public class BuyUS : MonoBehaviour
    {
        [SerializeField] private UnitType type;
        private Transform Mag;

        private void Awake()
        {
            Mag = transform.parent;
            Sprite unit;
            int price = type.getCost();
            unit = Resources.Load<Sprite>(type.getFilePath());


            transform.GetChild(1).GetComponent<Text>().text = "" + price;

            transform.GetChild(0).GetComponent<Image>().sprite = unit;
        }

        private void OnMouseDown()
        {
            Mag.GetComponent<Magazine>().UnselectAll();
            Select();
            Mag.GetComponent<Magazine>().Selected(type);
        }

        public void Select()
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.red;
        }

        public void Unselect()
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
    }
}