using UnityEngine;

public class EmailTab : TerminalTab
{
    [SerializeField]
    private GameObject _emailPrefab;

    public override void SetActiveTab(bool isActive, NewTask task)
    {
        base.SetActiveTab(isActive, task);


    }
}
