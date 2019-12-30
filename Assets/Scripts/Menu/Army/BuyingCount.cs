using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyingCount : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject slider;

    private void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = "" + (int) slider.GetComponent<Slider>().value + "   *   " +
                                               slider.GetComponent<Buying>().SelectedUnit.getCost() + "   =   " +
                                               slider.GetComponent<Buying>().SelectedUnit.getCost() *
                                               (int) slider.GetComponent<Slider>().value;
    }
}