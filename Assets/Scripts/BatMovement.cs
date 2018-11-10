using UnityEngine;
using LEAlpha;

public class BatMovement : MonoBehaviour {

	public static int MOVE_UP = 1;
	public static int MOVE_Down = -1;
	public float topLimit = 4;
    public float bottomLimit = 4;
	public float speed = 4f;
	public Vector2 targetPos;
	
	private Vector2 centerPostion;
	private float bottomPos;
	private float topPos;

	private int movingTo;
	// Use this for initialization
	void Start () {
		centerPostion = transform.position;
		movingTo = MOVE_UP;
		topPos = centerPostion.y + topLimit;
		bottomPos = centerPostion.y - bottomLimit;

		targetPos =  moveUp();
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y >= topPos){
            targetPos = moveDown();
        }else if(transform.position.y <= bottomPos){
            targetPos =  moveUp();
        }

		transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
	}

	Vector2 moveUp(){
		movingTo = MOVE_UP;
		return new Vector2(transform.position.x, topPos);
	}

	Vector2 moveDown(){
		movingTo = MOVE_Down;
		return new Vector2(transform.position.x, bottomPos);
	}

	void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){
            Lib.TakeDamage(10);
        }
    }
}
