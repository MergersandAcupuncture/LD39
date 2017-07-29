using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item {

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
        col.GetComponent<PlayerStuff>().HasKey = true;
        Debug.Log("We have a key!");
        base.PickUp();
    }
}
