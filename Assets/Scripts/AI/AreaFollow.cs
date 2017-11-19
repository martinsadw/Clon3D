using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaFollow : MonoBehaviour
{
	public float speed;
	public PlayerTrigger targetTrigger;

	public float gravity = 20.0f;

	private GameObject target;
	// private Rigidbody rb;
	private CharacterController controller;

	void Start()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		if (players.Length > 1)
		{
			Debug.LogError("Multiple players found");
		}

		target = players[0];

		// rb = GetComponent<Rigidbody>();
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		if (targetTrigger.playerInsideTrigger)
		{
			Vector3 direction = Vector3.Normalize(target.transform.position - transform.position);
			direction *= speed;
			direction.y = -gravity;
			// transform.position += Vector3.Normalize(direction) * speed * Time.deltaTime;
			// rb.velocity = Vector3.Normalize(direction) * speed;
			controller.Move(direction * Time.deltaTime);
		}
	}
}
