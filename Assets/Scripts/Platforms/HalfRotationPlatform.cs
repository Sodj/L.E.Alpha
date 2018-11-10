using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfRotationPlatform : MonoBehaviour {
	static int POSITION_BOTTOM = 0;
	static int POSITION_CENTER = 1;
	static int POSITION_RIGHT = 2;

	public float start = 4;
    public float end = 4;
	public float speed = 4f;
	
	private Vector2 targetPos;
	private Vector2 centerPostion;
	private Vector2 topRightEnd;
	private Vector2 bottomLeftEnd;
	private int previousPostion;
	private int movingTo;

	// Use this for initialization
	void Start () {
		centerPostion = transform.position;
        // To the right of the original position
		topRightEnd = new Vector2(centerPostion.x + start, centerPostion.y);
        // Under the original position
		bottomLeftEnd = new Vector2(centerPostion.x, centerPostion.y - end);
		// Initial move
		movingTo = POSITION_RIGHT;
		targetPos =  moveToRight();
	}
	
	// Update is called once per frame
	void Update () {
		if(movingTo == POSITION_RIGHT && transform.position.x >= topRightEnd.x){
			targetPos = moveToLeft();
		}else if(movingTo == POSITION_CENTER){
			if(previousPostion == POSITION_RIGHT && transform.position.x <= centerPostion.x){ // Coming from the right
				targetPos = moveDown();
			}else if(previousPostion == POSITION_BOTTOM && transform.position.y >= centerPostion.y){ // Coming from the bottom
				targetPos = moveToRight();
			}
		}else if(movingTo == POSITION_BOTTOM && transform.position.y <= bottomLeftEnd.y){
			targetPos = moveUp();
		}
		transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
	}
	
	Vector2 moveUp() {
		previousPostion = POSITION_BOTTOM;
		movingTo = POSITION_CENTER;
		return centerPostion;
	}

	Vector2 moveToRight() {
		previousPostion = POSITION_CENTER;
		movingTo = POSITION_RIGHT;
		return topRightEnd;
	}

	Vector2 moveDown() {
		previousPostion = POSITION_CENTER;
		movingTo = POSITION_BOTTOM;
		return bottomLeftEnd;
	}

	Vector2 moveToLeft() {
		previousPostion = POSITION_RIGHT;
		movingTo = POSITION_CENTER;
		return centerPostion;
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) other.transform.parent = this.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) other.transform.parent = null;
    }
}
