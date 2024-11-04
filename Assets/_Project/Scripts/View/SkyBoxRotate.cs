using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotate : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    private void Update()
    {
        float value =_material.GetFloat("_Rotation");
        value += Time.deltaTime / 2;
        if (value > 360)
        {
            value = 0f;
        }
        _material.SetFloat("_Rotation", value);
    }
}
