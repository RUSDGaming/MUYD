using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour
{

	public float health = 40f;

	PlayerController pc;

	public GameObject itemPrefab;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown ()
	{
		if (pc == null) {
			pc = GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<PlayerController> ();
			if (pc == null) {
				Debug.Log ("Couldnt find component");
			}
		}
		HurtRock (pc.GetDamage ());
	}

	void HurtRock (float damage)
	{
		health -= damage;

		if (health <= 0) {
			GameObject go = GameObject.Instantiate (itemPrefab);
			go.transform.position = this.gameObject.transform.position;
			GameObject.Destroy (this.gameObject);
		}
	}
}
