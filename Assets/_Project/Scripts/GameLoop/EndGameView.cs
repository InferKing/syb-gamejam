using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameView : MonoBehaviour
{
    [SerializeField] private GameObject _endGameWindow;
    [SerializeField] private GameObject _loreWindow;

    private void Start()
    {
        _endGameWindow.SetActive(false);
    }   
    
    public void ShowWindow()
    {
        _endGameWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        _loreWindow.SetActive(false);
        Time.timeScale = 1;
    }
}
