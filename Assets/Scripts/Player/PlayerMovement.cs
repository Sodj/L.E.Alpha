using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float jumpForce = 7;
    public float speed = 5;
    private float moveInput;
    public Rigidbody2D rb;

    private bool isGrounded;
    public float checkRadius = 0.1f;
    public Transform feetPos;
    public LayerMask whatIsGround; // baby don't hurt me .. don't hurt me .. no more

    public float maxJumpTime;
    public float jumpTime = 0.2f;
    private bool isJumping;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update() {
        // Check if player is on ground .. true if the 'feet position' overlaps with a 'ground' by a minimum of 'checkRadius'
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal"); // if pressing right: 1 if pressing left: -1 else 0
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        // Jump on 'space' down
		if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTime = maxJumpTime;
        }

        // Go higher while 'space' is still down
        if(isJumping && Input.GetKey(KeyCode.Space)){
            if(jumpTime > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTime -= Time.deltaTime;
            }
            else isJumping = false;
        }

        // Disable double jump
        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
        }

        // Flip character when moving
        if(moveInput < 0) transform.eulerAngles = new Vector3(0,180,0);
        else if(moveInput > 0) transform.eulerAngles = new Vector3(0,0,0);

        // Reset after falling
        if(transform.position.y < -8){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }
    }

    // For physics actions
	void FixedUpdate() {

		// if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
        //     rb.AddForce(transform.up * jumpForce);
        // }
	}
}
