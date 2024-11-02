using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterTerminalTrigger : MonoBehaviour
{
    private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInteractableFinder finder))
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new PlayerEnterTerminalSignal());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out PlayerInteractableFinder finder))
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new PlayerExitTerminalSignal());
        }
    }
}
