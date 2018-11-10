﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LEAlpha;

public class Saw : MonoBehaviour {

    public float leftX;
    public float rightX;
    public float speed;
    private string movingTo;
    private Vector2 targetPos;
    private int angle=0;

    void Start() {
        // move right
        movingTo = "right";
        targetPos = new Vector2(rightX, transform.position.y);
    }

    void Update() {
        transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
        angle = angle>=360? 0 : angle+5;

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

    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){
            Lib.TakeDamage(1);
            Debug.Log("player took 1 damage");
        }
    }
}
