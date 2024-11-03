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
    [SerializeField]
    private List<CharacterData> _characters;

    private Dictionary<CharacterData, CharacterTask> _usedTasks = new();
    private EventBus _bus;

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
#if UNITY_EDITOR
        Debug.LogWarning("Can't find new task");
#endif
        return null;
    }
}
