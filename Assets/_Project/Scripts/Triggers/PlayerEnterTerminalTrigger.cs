using UnityEngine;

public class PlayerEnterTerminalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInteractableFinder finder))
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new PlayerEnterTerminalSignal());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInteractableFinder finder))
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new PlayerExitTerminalSignal());
        }
    }
}
