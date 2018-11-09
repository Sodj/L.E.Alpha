using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LEAlpha;

public class Spikes : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){
            // Lib.TakeDamage(1);
            Debug.Log("player took 1 damage");
        }
    }
}
