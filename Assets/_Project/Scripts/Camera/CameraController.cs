using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private EventBus _bus;
    private CinemachineVirtualCamera _cinemachineCamera;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<PlayerEnterTerminalSignal>(GetCloserToPLayer);
        _bus.Subscribe<PlayerExitTerminalSignal>(GetAvayFromPlayer);
    }

    private void GetCloserToPLayer(PlayerEnterTerminalSignal signal)
    {
        
    }

    private void GetAvayFromPlayer(PlayerExitTerminalSignal signal)
    {

    }
}
