using Model.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTask
{
    public readonly CharacterTask task;
    public readonly CharacterData character;

    public NewTask(CharacterTask task, CharacterData character)
    {
        this.task = task;
        this.character = character;
    }
}

// выдает новые задачи и отслеживает какие уже были
public class TaskManager : MonoBehaviour
{
    private int _taskCount = 0;
    private Dictionary<CharacterData, CharacterTask> _usedTasks = new();
    private EventBus _bus;

    [SerializeField]
    private List<CharacterData> _characters;
    [SerializeField] 
    private EndGameView _endGameView;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
    }

    public NewTask GetNewTask()
    {
        foreach (var character in _characters)
        {
            if (!_usedTasks.ContainsKey(character))
            {
                _usedTasks[character] = character.Task;
                return new NewTask(_usedTasks[character], character);
            }
        }
        return new NewTask(_characters[_characters.Count - 1].Task, _characters[_characters.Count - 1]);
    }

    public NewTask GetNewTaskLimited()
    {
        if (_taskCount == _characters.Count)
        {
            _endGameView.ShowWindow();
            _taskCount = 0;
            return new NewTask(_characters[_taskCount].Task, _characters[_taskCount]);
        }
        else if (_taskCount == 0)
        {
            _taskCount++;
            return new NewTask(_characters[0].Task, _characters[0]);
        }
        else if(_taskCount < _characters.Count)
        {
            _taskCount++;
        }
            return new NewTask(_characters[_taskCount-1].Task, _characters[_taskCount-1]);
    }
}
