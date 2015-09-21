using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

	//public List<InventoryItem> items = new List<InventoryItem>();
	public List<GameObject> items = new List<GameObject> ();

	PlayerStats playerStats;


	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		playerStats = GetComponent<PlayerStats> ();
	}


	void Update ()
	{

		if (Input.GetButton ("Jump")) {		
			jump = true;
		} else {
			jump = false;
		}
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");


		if (Input.GetMouseButtonDown (0)) {
			// use item
			// limit atack speed
			if (playerStats.currentStamina >= 10) {
				playerStats.UseStamina (10);
			}
		}
	}

	void Attack ()
	{

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
	public float GetDamage ()
	{
		// if can attack
		return 10;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Item")) {
			SceneItem sceneItem = other.gameObject.GetComponent<SceneItem> ();
			GameObject go = sceneItem.getInventoryItem ();
			items.Add (go);
			
			GameObject.Destroy (other.gameObject);

		}
	}
}
