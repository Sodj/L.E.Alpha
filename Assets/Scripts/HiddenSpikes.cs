using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpikes : MonoBehaviour {

    public GameObject spikes;
    public float maxY = 0.60f;
    public float upSpeed = 50.00f;
    public float downSpeed = 2.00f;
    private bool isHidden=true;
    private Vector2 targetPos;

    void Start() {
        targetPos = new Vector2(spikes.transform.position.x, spikes.transform.position.y);
    }

    void Update() {
        // Reached top go down
        if(spikes.transform.position.y == maxY) {
            isHidden = false;
            targetPos = new Vector2(spikes.transform.position.x, transform.position.y - 0.05f);
        }
        // Reached back down
        if(spikes.transform.position.y == transform.position.y) {
            isHidden = true;
            //targetPos = new Vector2(spikes.transform.position.x, transform.position.y);
        }

        spikes.transform.position = Vector2.MoveTowards(spikes.transform.position, targetPos, (isHidden? upSpeed : downSpeed) * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(isHidden && other.CompareTag("Player")){
            Debug.Log("player trigger");
            targetPos = new Vector2(spikes.transform.position.x, maxY);
        }
    }
}
