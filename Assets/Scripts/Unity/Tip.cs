using System;
using TMPro;
using UnityEngine;

namespace Unity
{
    public class Tip : MonoBehaviour
    {
        public void SetText(string newTip)
        {
            Debug.Log(transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);

            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = newTip;
        }

        void FixedUpdate()
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            objPosition.z = 0;
            transform.position = objPosition;
        }
    }
}