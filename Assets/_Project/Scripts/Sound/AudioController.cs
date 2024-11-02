using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _fallBoxSound;
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

    }

    private void PlaySetOnTerminal(SetOnTerminalSignal signal)
    {

    }

    private void PlaySetOffTerminal(SetOffTerminalSignal signal)
    {

    }

    private void PlayStepsSound(StepSoundSignal signal)
    {

    }

    private void PlayRunToBoxMusic(RunToBoxSignal signal)
    {

    }
}
