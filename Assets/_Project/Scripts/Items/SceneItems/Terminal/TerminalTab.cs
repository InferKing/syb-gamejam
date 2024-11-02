using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalTab : MonoBehaviour
{
    [SerializeField]
    private GameObject _view;
    [SerializeField]
    private Image _imageTab;

    public bool Enabled { get; private set; } = false;

    public void SetActiveTab(bool isActive)
    {
        Enabled = isActive;

        _view.SetActive(isActive);
        _imageTab.color = isActive ? Color.blue : Color.white;
    }
}
