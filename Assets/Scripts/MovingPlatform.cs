using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float distance;
    public bool horizontal = true;

    public bool Lshape = false;
    public float distance2;
    public float speed = 5;

    private string movingTo;
    private Vector2 targetPos;
    private Vector2 startPos;
    private bool isGoing;

    void Start() {
        startPos = new Vector2(transform.position.x, transform.position.y);
        isGoing = true;
    }

    void Update() {

        if(!Lshape && horizontal){
            // Reached the start
            if(transform.position.x <= startPos.x){
                // move right
                targetPos = new Vector2(startPos.x + distance, transform.position.y);
            }
            // Reached the end
            else if (transform.position.x >= startPos.x + distance){
                // move left
                targetPos = new Vector2(startPos.x, startPos.y);
            }
        }

        else if(!Lshape){
            // Reached the start
            if (transform.position.y <= startPos.y){
                // move up
                targetPos = new Vector2(startPos.x, transform.position.y + distance);
            }
            // Reached the end
            else if (transform.position.y >= startPos.y + distance){
                // move down
                targetPos = new Vector2(startPos.x, startPos.y);
            }
        }

        else if(Lshape){
            // Reached the start
            if (transform.position.y <= startPos.y){
                // move up
                isGoing = true;
                targetPos = new Vector2(startPos.x, transform.position.y + distance);
            }
            // Reached the turning point
            if (transform.position.x <= startPos.x && transform.position.y >= startPos.y + distance){
                // move left
                if (isGoing) targetPos = new Vector2(startPos.x + distance2, startPos.y + distance);
                // move down
                else targetPos = new Vector2(startPos.x, startPos.y);
            }
            // Reached the end
            if (transform.position.x >= startPos.x + distance2){
                // move right
                Debug.Log("reached the end");
                isGoing = false;
                targetPos = new Vector2(startPos.x, startPos.y + distance);
            }
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
