using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _root;
    [SerializeField]
    private List<TerminalTab> _tabs;
    [SerializeField]
    private List<Button> _buttons;

    private NewTask _task;

    private void Start()
    {
        _buttons[0].onClick.AddListener(() => OpenTab(0));
        _buttons[1].onClick.AddListener(() => OpenTab(1));
    }

    public void Open()
    {
        _root.SetActive(true);

        OpenTab(0);
    }

    public void SetCharacterInfo(NewTask task)
    {
        _task = task;
    }

    public void Close()
    {
        _root.SetActive(false);
    }

    private void OpenTab(int index)
    {
        for (int i = 0; i < _tabs.Count; i++) 
        {
            _tabs[i].SetActiveTab(i == index, _task);
        }
    }
}
