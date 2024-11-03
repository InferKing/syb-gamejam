using UnityEngine;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private List<AudioClip> _fallBoxSounds;
    [SerializeField] private AudioClip _stepsSound;
    [SerializeField] private AudioClip _setOffTerminalSound;
    [SerializeField] private AudioClip _setOnTerminalSound;
    [SerializeField] private AudioClip _MainThemeMusic;
    [SerializeField] private AudioClip _MainMenuMusic;
    [SerializeField] private AudioClip _RunToBoxMusic;

    private EventBus _bus;

    void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<StepSoundSignal>(PlayStepsSound);
        _bus.Subscribe<BoxFallSoundSignal>(PlayBoxFallSound);
        _bus.Subscribe<SetOffTerminalSignal>(PlaySetOffTerminal);
        _bus.Subscribe<SetOnTerminalSignal>(PlaySetOnTerminal);
        _bus.Subscribe<RunToBoxSignal>(PlayRunToBoxMusic);
    }

    private void PlayMainTheme()
    {

    }

    private void PlayMenuTheme()
    {
        
    }

    private void PlayBoxFallSound(BoxFallSoundSignal signal)
    {
        _audioSource.PlayOneShot(_fallBoxSounds[Random.Range(0, _fallBoxSounds.Count)]);
    }

    private void PlaySetOnTerminal(SetOnTerminalSignal signal)
    {
        _audioSource.PlayOneShot(_setOnTerminalSound);
    }

    private void PlaySetOffTerminal(SetOffTerminalSignal signal)
    {
        _audioSource.PlayOneShot(_setOffTerminalSound);
    }

    private void PlayStepsSound(StepSoundSignal signal)
    {
        _audioSource.PlayOneShot(_stepsSound);
    }

    private void PlayRunToBoxMusic(RunToBoxSignal signal)
    {

    }
}
