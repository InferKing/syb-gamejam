using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameView : MonoBehaviour
{
    [SerializeField] private GameObject _endGameWindow;
    [SerializeField] private GameObject _loreWindow;
    [SerializeField] private GameObject _uiTerminal;

    private Coroutine _delay;


    private void Start()
    {
        _endGameWindow.SetActive(false);

        if (_delay != null)
        {
            StopCoroutine(_delay);
        }
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

    public void StartDelayShowWindow()
    {
       _delay = StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        //_endGameWindow.SetActive(true);
        yield return new WaitForSecondsRealtime(10f);
        ShowWindow();
        Time.timeScale = 0;
    }
}
