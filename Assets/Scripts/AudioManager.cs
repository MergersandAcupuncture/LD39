using UnityEngine;
using System.Collections;

/// <summary>
/// Holds all of our audio files and has methods for each object to play its respective audio.
/// </summary>
///
/// <remarks>   David Jerome, 12/7/2016. </remarks>
///
/// <seealso cref="T:UnityEngine.MonoBehaviour"/>
public class AudioManager : MonoBehaviour
{
    /// <summary>   Checks if we exist in the scene. If we do NOT, then create Instance. </summary>
    void Awake()
    {
        // Check if Instance already exists
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if(SFXaudioSource == null)
            SFXaudioSource = GetComponents<AudioSource>()[0];
        if(BGaudioSource == null)
            BGaudioSource = GetComponents<AudioSource>()[1];

        initVol = BGaudioSource.volume;
    }


    /// <summary>   Holds all of our AudioClip objects. These will be deleted. </summary>
    [Header("Here are our Audio Clips")]
    [SerializeField]private AudioClip[] AudioClips;
    /// <summary>   Our static SFXaudioSource so we can access the sound files. </summary>
    [SerializeField]private  AudioSource SFXaudioSource;
    /// <summary>   Our static BGaudioSource so we can control background music. </summary>
    [SerializeField]private AudioSource BGaudioSource;
    /// <summary>   Store the vakye if the background audio volume.. </summary>
    float initVol;
    /// <summary>   Control the speed of the audio fade durations. </summary>
    float fadeSpeed = 0.25f;

    /// <summary>   Our _AudioManager Instance, for our singletone pattern. </summary>
    public static AudioManager Instance = null;


    /// <summary>   Play Bounce audio. <para>Index 0.</para> </summary>
    public void PlayBounceBlockAudio()
    {
        SFXaudioSource.clip = AudioClips[0];
        SFXaudioSource.Play();
    }

    /// <summary>   Play Button audio. <para>Index 1</para> </summary>
    public void PlayButtonAudio()
    {
        SFXaudioSource.clip = AudioClips[1];
        SFXaudioSource.Play();
    }

    /// <summary>   Play Border audio. <para>Index 2</para> </summary>
    public void PlayBorderAudio()
    {
        SFXaudioSource.clip = AudioClips[2];
        SFXaudioSource.Play();
    }

    /// <summary>   Play Accelerator audio. <para>Index 2</para> </summary>
    public void PlayAcceleratorAudio()
    {
        SFXaudioSource.clip = AudioClips[2];
        SFXaudioSource.Play();
    }

    /// <summary>   Play Portal audio. <para>Index 3</para> </summary>
    public void PlayPortalAudio()
    {
        SFXaudioSource.clip = AudioClips[3];
        SFXaudioSource.Play();
    }

    /// <summary>   Play Water In audio. <para>Index 4</para> </summary>
    public void PlayWaterAudioIn()
    {
        SFXaudioSource.clip = AudioClips[4];
        SFXaudioSource.Play();
    }

    /// <summary>   Play Win audio. <para>Index 5</para> </summary>
    public void PlayWinAudio()
    {
        SFXaudioSource.clip = AudioClips[5];
        SFXaudioSource.Play();
        StartCoroutine(PlayWinLoadIn());
    }

    /// <summary>   Play Spike audio. <para>Index 6</para> </summary>
    public void PlaySpikeAudio()
    {
        SFXaudioSource.clip = AudioClips[6];
        SFXaudioSource.Play();
    }

    /// <summary>   Play WinLevel audio (0.75 second delay). <para>Index 7</para> </summary>
    public IEnumerator PlayWinLoadIn()
    {
        yield return new WaitForSeconds(.75f);
        
        SFXaudioSource.clip = AudioClips[7];
        SFXaudioSource.Play();
        StartCoroutine(FadeOutAudio(SFXaudioSource.clip.length));
    }

    /// <summary>   Play LoseLevel audio (0.75 second delay). <para>Index 8</para> </summary>
    public IEnumerator PlayLoseLoadIn()
    {
        yield return new WaitForSeconds(.75f);

        SFXaudioSource.clip = AudioClips[8];
        SFXaudioSource.Play();
        StartCoroutine(FadeOutAudio(SFXaudioSource.clip.length));
    }

    /// <summary>   Play Water Out audio. <para>Index 9</para> </summary>
    public void PlayWaterAudioOut()
    {
        SFXaudioSource.clip = AudioClips[9];
        SFXaudioSource.Play();
    }


    IEnumerator FadeOutAudio(float fadeTime)
    {
        float fadeOutTime = fadeTime/1.5f;
       

        while(fadeOutTime > 0)
        {
            yield return null;
            fadeOutTime -= Time.deltaTime;
            BGaudioSource.volume -= Time.deltaTime* fadeSpeed;
        }
        StartCoroutine(FadeInAudio(fadeTime));
        yield break;
    }

    IEnumerator FadeInAudio(float fadeTime)
    {
        float fadeInTime = fadeTime / 2f;

        while(fadeInTime > 0)
        {
            yield return null;
            fadeInTime -= Time.deltaTime;
            if(BGaudioSource.volume < initVol)
                BGaudioSource.volume += Time.deltaTime * fadeSpeed;
        }
        BGaudioSource.volume = initVol;
        yield break;
    }
}