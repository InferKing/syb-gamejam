using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudio : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> _clips;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _source.PlayOneShot(_clips[Random.Range(0, _clips.Count)]);
    }
}
