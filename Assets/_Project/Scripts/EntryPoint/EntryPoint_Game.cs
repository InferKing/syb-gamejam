using Model.Characters;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint_Game : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;

    private void Awake()
    {
        ServiceLocator.Initialize();
        ServiceLocator.Instance.Register(new EventBus());
        ServiceLocator.Instance.Register(_inputManager);

        PickedItems playerPickedItems = new(ServiceLocator.Instance.Get<EventBus>());
    }
}
