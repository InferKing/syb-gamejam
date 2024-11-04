using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Podskaz : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _bus.Subscribe<TerminalPickedAndClosedSignal>(OnPickedTerminal);
    }

    void OnPickedTerminal(TerminalPickedAndClosedSignal signal)
    {
        
    }

    IEnumerator TypeText(string text)
    {
        string res = "";
        foreach (var item in text) 
        { 
            res += item;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
