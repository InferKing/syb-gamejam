using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavesSoundSettings : MonoBehaviour
{
   [SerializeField] private Slider _soundSlider;
    [SerializeField] private AudioClip _soundClip;
    private string _musicValueName = "Volume";
    private float _volume;

    private void Start()
    {
        _volume = PlayerPrefs.GetFloat(_musicValueName, 1f);
        AudioManager.Instance.musicAudioSource.volume = _volume;
        AudioManager.Instance.PlayMusic(_soundClip);

        _soundSlider.value = _volume;
    }

    private void SaveSliderValue(float value, string name)
    {
        PlayerPrefs.SetFloat(name, value);
    }

    public void SetSoundValue()
    {
        AudioManager.Instance.musicAudioSource.volume = _soundSlider.value;
        SaveSliderValue(_soundSlider.value, _musicValueName);
        PlayerPrefs.Save();
    }

    public void SaveButtonClick()
    {
        SetSoundValue();
    }
}
