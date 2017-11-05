using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlScript : MonoBehaviour
{
	public float maxSpeed;
	public float accel;
	public float decel;

	private Vector3 curVel;

	void Start()
	{
		curVel = Vector3.zero;
	}

	void Update()
	{
		Vector3 direction = Vector3.zero;

		// NOTE(andre:2017-11-05): Mudar a direcao do movimento demora muito
		// Implementar uma logica para que caso o player tente se mover na
		// direcao contraria a do movimento a mudanca de direcao seja mais rapida
		if (Input.GetKey("up"))
		{
			direction += Vector3.forward;
		}
		if (Input.GetKey("down"))
		{
			direction += Vector3.back;
		}
		if (Input.GetKey("right"))
		{
			direction += Vector3.right;
		}
		if (Input.GetKey("left"))
		{
			direction += Vector3.left;
		}

		if (direction == Vector3.zero)
		{
			// reduz a velocidade
			float curSpeed = curVel.magnitude;

			if (curSpeed > 0)
			{
				curVel *= (Mathf.Max(curSpeed - decel, 0)) / curSpeed;
			}
		}
		else
		{
			// aumenta a velocidade
			curVel = Vector3.ClampMagnitude(curVel + direction * accel, maxSpeed);
		}

		transform.Translate(curVel * Time.deltaTime, Space.World);
		transform.LookAt(transform.position + curVel);
	}
}
