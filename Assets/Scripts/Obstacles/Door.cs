using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour {

    int nextLevel;
	// Use this for initialization
	void Awake () {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerStuff>().HasKey)
            {
                // Play some audio

                // Do soemthing cool

                //load next secene, yay (in three seconds...
                StartCoroutine(LoadNextLevel());
            }
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(nextLevel);
    }
}
