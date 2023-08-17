using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameOver : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void ShowGameOverPanel()
    {
        panel.SetActive(true);
    }
}
