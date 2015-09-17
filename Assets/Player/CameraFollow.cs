using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

	// Use this for initialization
	public Transform playerTransform;
	public float maxDeltaX = 5;
	public float maxDeltaZ = 5;
	private float springyNess = 0f;
	Transform camTransform;
	// Use this for initialization
	void Start ()
	{
		camTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		

		float deltaX = camTransform.position.x - playerTransform.position.x;
		float deltaZ = camTransform.position.z - playerTransform.position.z;
		
		float x = camTransform.position.x;
		float z = camTransform.position.z;
		
		if (Mathf.Abs (deltaX) > maxDeltaX) {
			//	Debug.Log ("deltaX: " + deltaX);
			
			x = playerTransform.position.x + maxDeltaX * Mathf.Sign (deltaX);
			//Debug.Log (x);
		}
		
		if (Mathf.Abs (deltaZ) > maxDeltaZ) {
			z = playerTransform.position.z + maxDeltaZ * Mathf.Sign (deltaZ);
		}
		
		
		
		camTransform.position = new Vector3 (x, camTransform.position.y, z);
		//Debug.Log ("pos:" + transform.position);
	}


}
