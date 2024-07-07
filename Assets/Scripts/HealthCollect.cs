using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
	[SerializeField] private int addHealth;
	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController controller = other.GetComponent<PlayerController>();
		
		if (controller != null && controller.CurrentHealth < controller.MaxHealth)
		{
			controller.ChangeHealth(addHealth);
			Destroy(gameObject);
		}

	}
}
