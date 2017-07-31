using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BlockFall : MonoBehaviour {

    // Use this for initialization
    void Awake(){
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
        if(trans.Length == 0)
            trans = GetComponentsInChildren<Transform>();
        if(colliders.Length == 0)
            colliders = GetComponentsInChildren<BoxCollider2D>();
        if(particles == null)
            particles = GetComponentInChildren<ParticleSystem>();
    }


    [SerializeField]Rigidbody2D rb;
    [SerializeField]Transform[] trans;
    [SerializeField]BoxCollider2D[] colliders;
    [SerializeField]ParticleSystem particles;
    bool hasTriggered;


	
	// Update is called once per frame
	void Update () {
		// dunno yet
	}

    /// <summary>
    /// Trigger the block to shake and then fall if the player enters
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col){
        Debug.Log("hit smth");
        if(col.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; //redundant now with a disbaled collider
            colliders[1].enabled = false;
            StartShake();
        }
    }

    /// <summary>
    /// The block will kill the player if he is hit. Then block can the be removed... or soemthing
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col){
        Debug.Log("kill smth");
        if(col.gameObject.CompareTag("Player"))
        {
            // KillPlayer()

            // The block can fade away or crumlbe or somthing..
            // Just to get rid of it?
            //colliders[0].enabled = false;

            AudioManager.Instance.PlayBounceBlockFallAudio();

            // Cant shake camera right now because of Camera Follow Script :(
            //RandomShake.Instance.PlayShakeCamera();
        }
    }

    /// <summary>
    /// Start the block shake coroutine and then teh block will fall
    /// </summary>
    void StartShake()
    {
        particles.Play();
        // Need to shake the block a little bit
        RandomShake.Instance.PlayShakeLeftToRight(trans[1]);
        //Then the block falls
        StartCoroutine(StartFall());
    }

    /// <summary>
    /// Block will fall straight down after a given duration.
    /// Duration is set in RandomShake script
    /// </summary>
    IEnumerator StartFall()
    {
        yield return new WaitForSeconds(RandomShake.Instance.duration);
        rb.isKinematic = false;
    }
}
