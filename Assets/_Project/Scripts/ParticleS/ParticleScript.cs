using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private ParticleSystem _particleSystem;

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
        {
            if (!_particleSystem.isPlaying)
            {
                _particleSystem.Play();
            }       
        }
        else
        {
            _particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
