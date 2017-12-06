using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	public Transform respawnPoint;

	void OnTriggerEnter(Collider other)
	{
	    if (other.CompareTag("Player"))
		{
			PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();

			if (!health.respawning)
			{
				other.gameObject.transform.position = respawnPoint.position;
				health.TakeDamage(1);
				health.respawning = true;
			}
	    }
	}
}
