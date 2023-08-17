using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberTextIncreaser : MonoBehaviour
{
    [SerializeField] private GameObject pan;
    TMP_Text r;
    string s = "New line";
    public void OpenPanel()
    {
        r.text = s;
        pan.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        pan.gameObject.SetActive(false);
    }
}
