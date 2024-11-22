using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameView : MonoBehaviour
{
    [SerializeField] private GameObject _endGameWindow;

    private void Start()
    {
        _endGameWindow.SetActive(false);
    }   
    
    public void ShowWindow()
    {
        _endGameWindow.SetActive(true);
    }
}
