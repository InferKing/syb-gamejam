using System;
using UnityEngine;

public class InputManager : MonoBehaviour, IService
{
    public event Action KeyEPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyEPressed?.Invoke();
        }
    }
}
