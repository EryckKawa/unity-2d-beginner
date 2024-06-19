using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float movSpeed;
	[SerializeField] private InputAction MoveAction;
	private new Rigidbody2D rigidbody2D;
	private Vector2 move;

	[SerializeField] private int maxHealth = 5;
	private int currentHealth;

	// Start is called before the first frame update
	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		MoveAction.Enable();

		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update()
	{
		move = MoveAction.ReadValue<Vector2>();
	}
	
	void FixedUpdate()
	{
		Vector2 position = (Vector2)transform.position + move * movSpeed * Time.deltaTime;
		rigidbody2D.MovePosition(position);
	}
	
	void ChangeHealth(int amount)
	{
		currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
	}
}
