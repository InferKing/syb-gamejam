using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private EventBus _bus;
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;
    CinemachineComponentBase _componentBase;
    

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<PlayerEnterTerminalSignal>(GetCloserToPLayer);
        _bus.Subscribe<PlayerExitTerminalSignal>(GetAvayFromPlayer);

        _componentBase = _cinemachineCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }

    private void GetCloserToPLayer(PlayerEnterTerminalSignal signal)
    {
        if (_componentBase is CinemachineFramingTransposer)
        {
            (_componentBase as CinemachineFramingTransposer).m_CameraDistance = 6;
        }
        
    }

    private void GetAvayFromPlayer(PlayerExitTerminalSignal signal)
    {
        if (_componentBase is CinemachineFramingTransposer)
        {
            (_componentBase as CinemachineFramingTransposer).m_CameraDistance = 13;
        }
    }
}
