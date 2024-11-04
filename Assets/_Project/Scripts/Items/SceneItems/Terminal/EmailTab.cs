using System.Collections.Generic;
using UnityEngine;

public class EmailTab : TerminalTab
{
    [SerializeField]
    private EmailView _emailPrefab;
    [SerializeField]
    private Transform _whereSpawn;

    private Dictionary<NewTask, EmailView> views = new();

    public override void SetActiveTab(bool isActive, NewTask task)
    {
        base.SetActiveTab(isActive, task);

        foreach (var item in ServiceLocator.Instance.Get<GameModel>().resultTasks.Keys)
        {
            if (views.TryGetValue(item, out EmailView value))
            {
                value.UpdateView(item);
            }
            else
            {
                var go = Instantiate(_emailPrefab.gameObject);
                go.transform.SetParent(_whereSpawn, false);
                views[item] = go.GetComponent<EmailView>();
                views[item].UpdateView(item);
            }
        }
    }
}
