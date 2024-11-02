using UnityEngine;
using TMPro;

public class TasksView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _bus.Subscribe<GameStateChangedSignal>(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameStateChangedSignal signal)
    {
        if (signal.state == GameState.NewTask)
        {
            _text.gameObject.SetActive(true);
            _text.text = "Появилось новое задание в терминале!";
        }
        else if (signal.state == GameState.InTerminal)
        {
            _text.gameObject.SetActive(false);
        }
        else if (signal.state == GameState.PickedInTerminal)
        {
            _text.gameObject.SetActive(false);
        }
        else if (signal.state == GameState.GetAll)
        {
            _text.gameObject.SetActive(true);
        }
    }
}
