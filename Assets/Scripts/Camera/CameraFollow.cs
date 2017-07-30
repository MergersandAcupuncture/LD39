using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeX;
    public float smoothTimeY;

    public Transform player;


	// Use this for initialization
	void Start () {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity.x, smoothTimeX * Time.deltaTime);
        float posY = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocity.y, smoothTimeY * Time.deltaTime);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
