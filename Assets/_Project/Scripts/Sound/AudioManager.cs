using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _fallBoxSounds;
    [SerializeField] private List<AudioClip> _clickSounds;
    [SerializeField] private List<AudioClip> _stepsSounds;

    [SerializeField]
    private AudioClip AMBIENT;
    [SerializeField]
    private AudioClip POGONYA;

    [SerializeField] private AudioClip _setOffTerminalSound;
    [SerializeField] private AudioClip _setOnTerminalSound;
    [SerializeField] private AudioClip _MainThemeMusic;
    [SerializeField] private AudioClip _MainMenuMusic;
    [SerializeField] private AudioClip _RunToBoxMusic;

    public static AudioManager Instance { get; private set; }

    public AudioSource musicAudioSource;
    public AudioSource soundEffectAudioSource;

    private EventBus _bus;
    private bool _isPlayingSteps = false;

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
            //InitBus();
        }
        //StartCoroutine(GetBus());
    }

    private void Start()
    {
        if (_bus == null)
        {
            InitBus();
        }
    }

    public void PlayAmbient()
    {
        PlayMusic(AMBIENT);
    }

    public void PlayPogonya()
    {
        PlayMusic(POGONYA);
    }

    public void InitBus()
    {
        try
        {
            _bus = ServiceLocator.Instance.Get<EventBus>();
            _bus.Subscribe<StepSoundSignal>(PlayStepsSound);
            _bus.Subscribe<BoxFallSoundSignal>(PlayBoxFallSound);
            _bus.Subscribe<SetOffTerminalSignal>(PlaySetOffTerminal);
            _bus.Subscribe<SetOnTerminalSignal>(PlaySetOnTerminal);
            _bus.Subscribe<RunToBoxSignal>(PlayRunToBoxMusic);
            _bus.Subscribe<ClickSignal>(ClickSound);
            _bus.Subscribe<TerminalPickedAndClosedSignal>(OnPicked);
            _bus.Subscribe<SuccessTaskSignal>(OnSuccess);
            _bus.Subscribe<FailedTaskSignal>(OnFailed);
        }
        catch { }
    }

    private void OnPicked(TerminalPickedAndClosedSignal signal)
    {
        PlayPogonya();
    }

    private void OnSuccess(SuccessTaskSignal signal)
    {
        PlayAmbient();
    }

    private void OnFailed(FailedTaskSignal s)
    {
        PlayAmbient();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.volume = PlayerPrefs.GetFloat("Volume", 1f);
        musicAudioSource.Stop();
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    private void PlayBoxFallSound(BoxFallSoundSignal signal)
    {
        soundEffectAudioSource.PlayOneShot(_fallBoxSounds[Random.Range(0, _fallBoxSounds.Count)]);
    }

    private void ClickSound(ClickSignal signal)
    {
        soundEffectAudioSource.PlayOneShot(_clickSounds[Random.Range(0, _clickSounds.Count)]);
    }

    private void PlaySetOnTerminal(SetOnTerminalSignal signal)
    {
        soundEffectAudioSource.PlayOneShot(_setOnTerminalSound);
    }

    private void PlaySetOffTerminal(SetOffTerminalSignal signal)
    {
        soundEffectAudioSource.PlayOneShot(_setOffTerminalSound);
    }

    private void PlayStepsSound(StepSoundSignal signal)
    {
        if (!_isPlayingSteps)
        {
            StartCoroutine(PlaySteps());
        }
    }

    private void PlayRunToBoxMusic(RunToBoxSignal signal)
    {
        soundEffectAudioSource.PlayOneShot(_RunToBoxMusic);
    }

    private IEnumerator GetBus()
    {
        
        yield return new WaitForSeconds(Time.deltaTime);
        try
        {
            _bus = ServiceLocator.Instance.Get<EventBus>();
            Debug.Log("Subscribed");
        }
        catch { }
    }

    private void PlayLoseMissionSound()
    {

    }

    private IEnumerator PlaySteps()
    {
        _isPlayingSteps = true;
        soundEffectAudioSource.PlayOneShot(_stepsSounds[Random.Range(0, _stepsSounds.Count)]);
        yield return new WaitForSeconds(0.3f);
        _isPlayingSteps = false;
    }

    //private IEnumerator ChangeMusic(AudioSource source, AudioClip clip)
    //{
    //    float volume = PlayerPrefs.GetFloat("Volume", 1f);
    //    source.volume = volume;
    //    for (float i = volume; i > 0f; i -= Time.deltaTime)
    //    {
    //        source.volume = i;
    //        yield return null;
    //    }
    //    source.Stop();
    //    source.clip = clip;
    //    source.volume = volume;
    //    source.Play();
    //}
}