using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;

	public float maxSpeed;
	public float accel;
	public float decel;

    public float maxJumpHeight;
    public float gravity;
    public float fallGravity;

    [HideInInspector] public float jumpSpeed;
	[HideInInspector] public Vector2 curVel;
	private float yVel;

	void Start()
	{
        controller = GetComponent<CharacterController>();

		curVel = Vector3.zero;
	}

	void Update()
	{
        jumpSpeed = Mathf.Sqrt(2 * gravity * maxJumpHeight);

		Vector2 moveDirection = Vector2.zero;

		// NOTE(andre:2017-11-05): Mudar a direcao do movimento demora muito
		// Implementar uma logica para que caso o player tente se mover na
		// direcao contraria a do movimento a mudanca de direcao seja mais rapida
		if (Input.GetKey("up"))
		{
			moveDirection += Vector2.up;
		}
		if (Input.GetKey("down"))
		{
			moveDirection += Vector2.down;
		}
		if (Input.GetKey("right"))
		{
			moveDirection += Vector2.right;
		}
		if (Input.GetKey("left"))
		{
			moveDirection += Vector2.left;
		}

		if (moveDirection == Vector2.zero)
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
			curVel = Vector2.ClampMagnitude(curVel + moveDirection * accel, maxSpeed);
		}

		if (controller.isGrounded)
		{
			if (Input.GetKey("z"))
			{
				yVel = jumpSpeed;
			}
			else
			{
				yVel = 0;
			}
		}
		else
		{
			if (Input.GetKey("z") && yVel > 0)
			{
	             yVel -= gravity * Time.deltaTime;
			}
			else
			{
	             yVel -= fallGravity * Time.deltaTime;
			}
		}

		Vector3 move = new Vector3(curVel.x, yVel, curVel.y);
		Vector3 lookDirection = new Vector3(curVel.x, 0, curVel.y);

		// transform.Translate(curVel * Time.deltaTime, Space.World);
		Debug.DrawLine(transform.position, transform.position + move * 0.3f);
		controller.Move(move * Time.deltaTime);
		transform.LookAt(transform.position + lookDirection);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (gameObject.CompareTag("Wall"))
		{
			// rigidbody.velocity = Vector3.zero;
		}
	}
}
