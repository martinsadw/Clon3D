using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") ||
			other.gameObject.CompareTag("DestructibleWall"))
		{
			Destroy(other.gameObject);
		}
	}
}
