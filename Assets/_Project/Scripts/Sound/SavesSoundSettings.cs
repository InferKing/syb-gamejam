using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavesSoundSettings : MonoBehaviour
{
   [SerializeField] private Slider _soundSlider;
   [SerializeField] private AudioManager _audioManager;
    private string _musicValueName = "Volume";
    private float _volume;

    private void Start()
    {
        _volume = PlayerPrefs.GetFloat(_musicValueName, 1f);
        _soundSlider.value = _volume;
    }

    private void SaveSliderValue(float value, string name)
    {
        PlayerPrefs.SetFloat(name, value);
    }

    private void Update()
    {
        _audioManager.musicAudioSource.volume = _soundSlider.value;
    }

    public void SetSoundValue()
    {
        _audioManager.musicAudioSource.volume = _soundSlider.value;
        SaveSliderValue(_soundSlider.value, _musicValueName);
        PlayerPrefs.Save();
    }

    public void SaveButtonClick()
    {
        SetSoundValue();
    }
}
