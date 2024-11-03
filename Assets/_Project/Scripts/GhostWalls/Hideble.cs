using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideble : MonoBehaviour
{
    [SerializeField] private float _alfaChannal;

    public void Hide(Color color)
    {
        color.a = _alfaChannal;
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void Show(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
