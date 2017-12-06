using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotatingSpeed = 50f;

	void Update()
	{
		transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
	    if (other.CompareTag("Player"))
		{
			Destroy(gameObject);
	    }
	}
}
