using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{

	public float maxHealth = 100f;
	public float currentHealth = 100f;
	public float maxStamina = 100f;
	public float currentStamina = 100f;
	// when you use staima you wont be able to recovor to your full amount untill you eat something or go to bed. 
	public float recoverableStamina = 100f;
	public float staminaRecoverRate = 1f;


	public StatusBar healthBar;
	public StatusBar staminaBar;

	// Use this for initialization
	void Start ()
	{
		staminaBar.maxAmount = maxStamina;
		healthBar.maxAmount = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	
	}


	void FixedUpdate ()
	{
		currentStamina += staminaRecoverRate * Time.fixedDeltaTime;
		if (currentStamina > recoverableStamina) {
			currentStamina = recoverableStamina;
		}
		staminaBar.SetCurrentAmount (currentStamina);
	}

	public void DamagePlayer (float damage)
	{
		currentHealth -= damage;
		healthBar.SetCurrentAmount (currentHealth);
	}

	public void UseStamina (float ammount)
	{
		currentStamina -= ammount;
		maxStamina -= ammount / 10f;
		staminaBar.SetCurrentAmount (currentStamina);
	}
}
