using UnityEngine;
using System.Collections;

/// <summary>   A random shake. </summary>
///
/// <remarks>   David Jerome, 12/7/2016. </remarks>
public class RandomShake : MonoBehaviour
{
    /// <summary>   The original position of the object. </summary>
    private Vector3 initPos;

    /// <summary>  The Camera that holds this script. </summary>
    [Header("We will need the Camera for this")]
    public Transform myCamera;
    /// <summary>   The duration of the effect. </summary>
    public float duration = 0.3f;
    /// <summary>   The magnitude of the effect. </summary>
    public float magnitude = 0.25f;
    /// <summary>   The static instance of this class</summary>
    public static RandomShake Instance { get; set; } 


    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    /// <summary>   Play shake all. </summary>
    public void PlayShakeAll(Transform trans)
    {
        initPos = trans.position;

        StopAllCoroutines();

        StartCoroutine(ShakeAll(trans));
    }

    // -------------------------------------------------------------------------
    /// <summary>   Play shake up. </summary>
    public void PlayShakeUp()
    {
        // Stop if we are shaking.
        StopAllCoroutines();
        // Start shaking
        StartCoroutine("ShakeUp");
    }

    /// <summary>   Shake the back and forth on teh X axis. </summary>
    ///
    /// <returns>   An IEnumerator. </returns>
    IEnumerator ShakeAll(Transform trans)
    {
        float elapsed = 0.0f;
        float _magnitude = magnitude * .5f;

        Vector3 prevPosition = trans.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
            // map noise to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            x *= _magnitude * damper;
            x += initPos.x;

            trans.position = Vector3.Lerp(new Vector3(x, initPos.y, initPos.z), prevPosition, Time.deltaTime);
            prevPosition = trans.position;

            yield return null;
        }

        trans.position = initPos;
    }

    /// <summary>   Shake the camera up and down. </summary>
    ///
    /// <returns>   An IEnumerator. </returns>
    IEnumerator ShakeUp()
    {
        float elapsed = 0.0f;

        Vector4 prevPosition = myCamera.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
            // map noise to [-1, 1]
            float y = Random.value * 2.0f - 1.0f;

            y *= magnitude * damper;
            y += 1;

            myCamera.position = Vector3.Lerp(new Vector3(initPos.x, y, initPos.z), prevPosition, Time.deltaTime);
            prevPosition = myCamera.position;

            yield return null;
        }

        myCamera.position = initPos;
    }


    [ContextMenu("SetUpScene")]
    void SetUpScene()
    {
        duration = 0.3f;
        magnitude = 0.25f;
    }
}