using System;
using UnityEngine;

public class InputManager : MonoBehaviour, IService
{
    public event Action KeyEPressed;
    [SerializeField] private GameObject _menuCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyEPressed?.Invoke();
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
}
