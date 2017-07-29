using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


    // Has a particle system
    // Has some audio
    // Has an animator? spinning around?

	// Use this for initialization
	void Start () {
	    // Get particle system
        // Get audio? or auido manager.. who knows
        // Do we have an animation?	
	}
	
    protected virtual void PickUp()
    {
        // Base method to pick up an object

        // Destroy this object

        //Play particle
        //Play audio
        //Stop anim? something

        DestroyMe();

    }

    private void DestroyMe()
    {
        Debug.Log("Item destroyed");
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
