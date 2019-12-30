using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private Transform p;
    [SerializeField] private bool first;

    void OnEnable()
    {
        p = transform.parent;
        transform.GetComponent<TextMeshProUGUI>().text =
            "" + (first ? p.GetComponent<ArmySettings>().M1 : p.GetComponent<ArmySettings>().M2);
    }

    public void Refresh()
    {
        transform.GetComponent<TextMeshProUGUI>().text =
            "" + (first ? p.GetComponent<ArmySettings>().M1 : p.GetComponent<ArmySettings>().M2);
    }
}