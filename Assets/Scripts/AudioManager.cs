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
    public void PlayBounceBlockFallAudio()
    {
        SFXaudioSource.clip = AudioClips[0];
        SFXaudioSource.Play();
    }
}