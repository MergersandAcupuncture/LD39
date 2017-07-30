using UnityEngine;

public class PlayerStuff : MonoBehaviour {

    [SerializeField]private bool hasKey;
    public Phone phone;
    

	void Awake () {
        phone = new Phone();
	}
	

	//void Update () {
		
	//}

    public bool HasKey {
        get { return hasKey; }
        set { hasKey = value; }
    }
}
