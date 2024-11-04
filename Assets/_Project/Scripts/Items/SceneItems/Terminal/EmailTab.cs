using System.Collections.Generic;
using UnityEngine;

public class EmailTab : TerminalTab
{
    [SerializeField]
    private EmailView _emailPrefab;

    private Dictionary<NewTask, EmailView> views = new();

    public override void SetActiveTab(bool isActive, NewTask task)
    {
        base.SetActiveTab(isActive, task);

        foreach (var item in ServiceLocator.Instance.Get<GameModel>().allTasks)
        {
            //if ()
        }
        
    }
}
