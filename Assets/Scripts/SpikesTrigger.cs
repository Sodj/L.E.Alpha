using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrigger : MonoBehaviour {

    public GameObject spikes;
    public float distance;
    public float upSpeed;
    public float downSpeed;
    public bool isHidden;
    public Vector2 targetPos;

    void Start() {
        targetPos = new Vector2(spikes.transform.position.x, spikes.transform.position.y);
    }

    void Update() {
        // going up
        if(isHidden) spikes.transform.position = Vector2.MoveTowards(spikes.transform.position, targetPos, upSpeed * Time.deltaTime);
        // going down
        else spikes.transform.position = Vector2.MoveTowards(spikes.transform.position, targetPos, downSpeed * Time.deltaTime);

        // Reached top go down
        if(spikes.transform.position.y == targetPos.y) targetPos = new Vector2(spikes.transform.position.x, spikes.transform.position.y - distance);
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            spikes.transform.position = new Vector2(spikes.transform.position.x, spikes.transform.position.y + distance);
        }
    }
}
