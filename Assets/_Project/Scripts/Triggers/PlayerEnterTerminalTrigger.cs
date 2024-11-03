using UnityEngine;

public class PlayerEnterTerminalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInteractableFinder finder))
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new PlayerEnterTerminalSignal());
            if (ServiceLocator.Instance.Get<GameModel>().State == GameState.NewTask)
            {
                ServiceLocator.Instance.Get<EventBus>().Invoke(new ResetSceneSignal());
            }
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
