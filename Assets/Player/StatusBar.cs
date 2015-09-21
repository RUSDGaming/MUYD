using UnityEngine;
using System.Collections;

public class StatusBar : MonoBehaviour
{


	public RectTransform backGround;
	public RectTransform foreGround;

	public float maxAmount;
	public float currentAmount;
	private float width;

	// Use this for initialization
	void Start ()
	{
		width = backGround.rect.width;
	}

	public void SetCurrentAmount (float amount)
	{
		currentAmount = amount;
		float thing = maxAmount - amount;
		float ratio = width / maxAmount;
		thing *= ratio;

		foreGround.sizeDelta = new Vector2 (-thing, 10);
		foreGround.anchoredPosition = new Vector3 (-thing / 2, 0, 0);
		//foreGround.right = maxAmount - amount;

	}
}
