using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LEAlpha;

public class Acid : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Lib.TakeDamage(999);
            Debug.Log("player took 999 damage");
        }
    }
}
