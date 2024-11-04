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

// ������ ����� ������ � ����������� ����� ��� ����
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
        return new NewTask(_characters[_characters.Count - 1].Task, _characters[_characters.Count - 1]);
    }
}
