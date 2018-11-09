using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float leftX;
    public float rightX;
    public float speed = 5;
    private string movingTo;
    private Vector2 targetPos;

    void Start() {
        // move right
        movingTo = "right";
        targetPos = new Vector2(rightX, transform.position.y);
    }

    void Update() {

        // Reached the far right
        if(movingTo=="right" && transform.position.x == rightX){
            // move left
            movingTo = "left";
            targetPos = new Vector2(leftX, transform.position.y);
        }
        // Reached the far left
        else if(movingTo=="left" && transform.position.x == leftX){
            // move right
            movingTo = "right";
            targetPos = new Vector2(rightX, transform.position.y);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) other.transform.parent = this.transform;
    }

    private void OnCollisionExit2D(Collision2D other) {
       if(other.gameObject.CompareTag("Player")) other.transform.parent = null;
    }
}
