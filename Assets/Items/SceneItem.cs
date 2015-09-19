using UnityEngine;
using System.Collections;

public class SceneItem : MonoBehaviour
{

	public GameObject inventoryItem;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public GameObject getInventoryItem ()
	{
		GameObject item = GameObject.Instantiate (inventoryItem);
		return item;
	}
}
