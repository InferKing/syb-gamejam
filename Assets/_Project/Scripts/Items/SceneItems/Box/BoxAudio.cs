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
        var currentclip = _clips[Random.Range(0, _clips.Count)];
        _source.PlayOneShot(currentclip);
        Debug.Log(currentclip.name);
    }
}
