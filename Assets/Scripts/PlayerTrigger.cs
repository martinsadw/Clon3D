using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
	[HideInInspector] public bool playerInsideTrigger;

	private BoxCollider trigger;

	void Start()
	{
		playerInsideTrigger = false;

		trigger = GetComponent<BoxCollider>();
		if (trigger == null || !trigger.isTrigger)
		{
			Debug.LogError("Missing Trigger");
		}
	}

	void OnTriggerEnter(Collider other)
	{
	    if (other.CompareTag("Player"))
		{
			playerInsideTrigger = true;
	    }
	}

	void OnTriggerExit(Collider other)
	{
	    if (other.CompareTag("Player"))
		{
			playerInsideTrigger = false;
	    }
	}
}
