using UnityEngine;
using TMPro;


public class ShowStateView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_Text;

    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _bus.Subscribe<GameStateChangedSignal>(OnNewState);
    }

    private void OnNewState(GameStateChangedSignal signal)
    {
        m_Text.text = signal.state.ToString();
    }
}
