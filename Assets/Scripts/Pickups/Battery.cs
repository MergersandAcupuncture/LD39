using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Item {

    /// <summary>   The amount of juice this batter has, as a percentage of 100.</summary>
    public float juice = 5f;
    Collider2D col;

    private void OnTriggerEnter2D(Collider2D _col)
    {
        if(_col.CompareTag("Player"))
        {
            col = _col;
            PickUp();
        }
    }

    protected override void PickUp()
    {
        // Add some juice to phone
        // Not sure where the 'stats' will be 
        // Some stat manager?
        // StatManager.Instance.Phone.AddJuice(juice);
        // phone.addJuice ?
        col.GetComponent<PlayerStuff>().phone.AddJuice(juice);
        Debug.Log("The juice is loose!");
        base.PickUp();
    }
}
