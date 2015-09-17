using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	// Use this for initialization


	public float speed = 6.0F;
	public float jumpSpeed = 20.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	private float horizontal;
	private float vertical;
	private bool jump;
	private CharacterController controller;


	void Start ()
	{
		controller = GetComponent<CharacterController> ();
	}


	void Update ()
	{
		//if (controller.isGrounded) {
		Debug.Log ("update");
		if (Input.GetButton ("Jump")) {
			//Debug.Log ("got the jump button");
			jump = true;
		} else {
			jump = false;
		}
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");
		//Debug.Log ("Horizontal" + horizontal);
		//}
	}


	void FixedUpdate ()
	{

	
		float tempY = moveDirection.y;
		moveDirection = new Vector3 (horizontal, 0, vertical);
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;
		if (jump && controller.isGrounded) {
			Debug.Log ("Jumped");
			moveDirection.y = jumpSpeed;
			jump = false;
		} else {
			moveDirection.y = tempY;
		}
		if (jump) {
			moveDirection.y -= gravity / 2f * Time.fixedDeltaTime;
		} else {
			moveDirection.y -= gravity * Time.fixedDeltaTime;
		}
		controller.Move (moveDirection * Time.fixedDeltaTime);
		if (controller.isGrounded) {
			moveDirection.y = 0;
		}
	}
}
