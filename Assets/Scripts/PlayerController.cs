using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	//Player Movement
	[SerializeField] private float movSpeed;
	[SerializeField] private InputAction MoveAction;
	private new Rigidbody2D rigidbody2D;
	private Vector2 move;

	//Player Life
	[SerializeField] private int maxHealth;
	private int currentHealth;

	public int CurrentHealth
	{
		get { return currentHealth; }
		set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
	}

	public int MaxHealth
	{
		get { return maxHealth; }
		private set { maxHealth = value; } // O setter é privado para prevenir alterações externas
	}

	// Variables related to temporary invincibility
	public float timeInvincible = 2.0f;
	bool isInvincible;
	float damageCooldown;


	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		MoveAction.Enable();

		CurrentHealth = maxHealth;
	}

	void Update()
	{
		move = MoveAction.ReadValue<Vector2>(); 
		
		if (isInvincible)
		{
			damageCooldown -= Time.deltaTime;
			if (damageCooldown < 0)
			{
				isInvincible = false;
			}
		}
	}

	void FixedUpdate()
	{
		Vector2 position = (Vector2)transform.position + movSpeed * Time.deltaTime * move;
		rigidbody2D.MovePosition(position);
	}

	public void ChangeHealth(int amount)
	{
		if (amount < 0)
		{
			if (isInvincible)
			{
				return;
			}
			isInvincible = true;
			damageCooldown = timeInvincible;
		}
		
		CurrentHealth += amount;
		Debug.Log(CurrentHealth); 
	}
}
