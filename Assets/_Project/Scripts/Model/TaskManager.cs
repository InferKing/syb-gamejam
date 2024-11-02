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

    private Dictionary<CharacterData, List<CharacterTask>> _usedTasks = new();
    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
    }

    public NewTask GetNewTask()
    {
        foreach (var character in _characters)
        {
            if (_usedTasks.ContainsKey(character) && _usedTasks[character].Count < character.Tasks.Count)
            {
                if (_usedTasks[character].Count == 0)
                {
                    _usedTasks[character] = new();
                }
                _usedTasks[character].Add(character.Tasks[_usedTasks[character].Count]);
                return new NewTask(_usedTasks[character][^1], character);
            }
        }
        foreach (var character in _characters) 
        {
            if (!_usedTasks.ContainsKey(character)) 
            {
                _usedTasks[character] = new() { character.Tasks[0] };
                return new NewTask(character.Tasks[0], character);
            }
        }
#if UNITY_EDITOR
        Debug.LogWarning("Can't find new task");
#endif
        return null;
    }
}
