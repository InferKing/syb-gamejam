using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabOrders : TerminalTab
{
    [SerializeField]
    private Image _characterIcon;
    [SerializeField]
    private TMP_Text _description;

    public override void SetActiveTab(bool isActive)
    {
        base.SetActiveTab(isActive);


    }
}
