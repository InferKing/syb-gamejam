using System;
using UnityEngine;

public class InputManager : MonoBehaviour, IService
{
    [SerializeField] private GameObject _menuCanvas;

    public event Action KeyEPressed;

    private bool _canPlayClick = false;

    private void Start()
    {
        EventBus bus = ServiceLocator.Instance.Get<EventBus>();

        bus.Subscribe<SetOnTerminalSignal>(OnSetOnTerminal);
        bus.Subscribe<SetOffTerminalSignal>(OnSetOffTerminal);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyEPressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(0) && _canPlayClick)
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new ClickSignal());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_menuCanvas.gameObject.activeSelf)
            {
                WorldMenuPause();
            }
            else
            {
                WorldMenuPlay();
            }
        }
    }

    public void WorldMenuPause()
    {
        _menuCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void WorldMenuPlay()
    {
        _menuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnSetOnTerminal(SetOnTerminalSignal signal)
    {
        _canPlayClick = true;
    }

    private void OnSetOffTerminal(SetOffTerminalSignal signal)
    {
        _canPlayClick = false;
    }
}
