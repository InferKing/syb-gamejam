using UnityEngine;

public class TerminalUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _root;

    public void Open()
    {
        _root.SetActive(true);
    }

    public void Close()
    {
        _root.SetActive(false);
    }
}
