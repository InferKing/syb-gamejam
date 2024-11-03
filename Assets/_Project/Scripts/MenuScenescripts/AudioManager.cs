using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicAudioSource;
    private EventBus _bus;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _fallBoxSounds;
    [SerializeField] private List<AudioClip> _clickSounds;
    [SerializeField] private AudioClip _stepsSound;
    [SerializeField] private AudioClip _setOffTerminalSound;
    [SerializeField] private AudioClip _setOnTerminalSound;
    [SerializeField] private AudioClip _MainThemeMusic;
    [SerializeField] private AudioClip _MainMenuMusic;
    [SerializeField] private AudioClip _RunToBoxMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<StepSoundSignal>(PlayStepsSound);
        _bus.Subscribe<BoxFallSoundSignal>(PlayBoxFallSound);
        _bus.Subscribe<SetOffTerminalSignal>(PlaySetOffTerminal);
        _bus.Subscribe<SetOnTerminalSignal>(PlaySetOnTerminal);
        _bus.Subscribe<RunToBoxSignal>(PlayRunToBoxMusic);
        _bus.Subscribe<ClickSignal>(ClickSound);
    }

    // проверить музон - j,
    // проверить коллизию с объектами для ящика, если скорость ящика больше чем 0.3f то вызвать звук падения
    // сделать слайдер для музона 
    // попробовать сохранить звук в плеер префс

    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickSound(new ClickSignal());
        }
    }

    public void PlayMainTheme()
    {

    }

    public void PlayMenuTheme()
    {

    }

    private void PlayBoxFallSound(BoxFallSoundSignal signal)
    {
        _audioSource.PlayOneShot(_fallBoxSounds[Random.Range(0, _fallBoxSounds.Count)]);
    }

    private void ClickSound(ClickSignal signal)
    {
        _audioSource.PlayOneShot(_clickSounds[Random.Range(0, _clickSounds.Count)]);
    }

    private void PlaySetOnTerminal(SetOnTerminalSignal signal)
    {
        _audioSource.PlayOneShot(_setOnTerminalSound);
        Debug.Log("звук теринала");
    }

    private void PlaySetOffTerminal(SetOffTerminalSignal signal)
    {
        _audioSource.PlayOneShot(_setOffTerminalSound);
    }


    private void PlayStepsSound(StepSoundSignal signal)
    {

    }

    private void PlayRunToBoxMusic(RunToBoxSignal signal)
    {

    }
}
