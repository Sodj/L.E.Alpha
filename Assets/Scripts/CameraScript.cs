using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public float width = 4;
    public float height = 2;
    private Vector3 targetPos;


    // Use this for initialization
    void Start () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
	
	// LateUpdate is called after Update
	void LateUpdate () {

        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // Move horizontally
        if (player.transform.position.x - transform.position.x >= width) {
            targetPos.x = player.transform.position.x - width;
        }
        else if (transform.position.x - player.transform.position.x >= width) {
            targetPos.x = player.transform.position.x + width;
        }

        // Move vertically
        if (player.transform.position.y - transform.position.y >= height) {
            targetPos.y = player.transform.position.y - height;
        }
        else if (transform.position.y - player.transform.position.y >= height) {
            targetPos.y = player.transform.position.y + height;
        }

        transform.position = targetPos;
    }
}
