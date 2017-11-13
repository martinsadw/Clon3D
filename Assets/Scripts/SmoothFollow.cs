using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
	public GameObject target;
	public Vector3 offset;

	public float maxDistance;
	public float minDistance;

	public float targetMovingDistance;
	public float targetMaxSpeed;

	public bool constrainX;
	public bool constrainY;
	public bool constrainZ;

	public bool followDirection;

	void Update()
	{
		if (followDirection)
		{
			transform.rotation = target.transform.rotation;
		}

		if (Input.GetKeyDown("a"))
		{
			targetMovingDistance -= 0.01f;
		}
		if (Input.GetKeyDown("s"))
		{
			targetMovingDistance += 0.01f;
		}

		Vector3 constrainedTarget = transform.position - (target.transform.position + offset);

		if (constrainX)
			constrainedTarget.x = 0;
		if (constrainY)
			constrainedTarget.y = 0;
		if (constrainZ)
			constrainedTarget.z = 0;

		bool outside = false;
		bool inside = false;

		float constrainedDistance = constrainedTarget.magnitude;
		float clampedDistance = constrainedDistance;
		if (constrainedDistance > maxDistance)
		{
			clampedDistance = maxDistance;
			outside = true;
		}
		if (constrainedDistance < minDistance)
		{
			clampedDistance = minDistance;
			inside = true;
		}

		constrainedTarget = constrainedTarget * (clampedDistance / constrainedDistance);

		float speed = 0;
		if (outside)
		{
			speed = targetMaxSpeed / (targetMovingDistance - maxDistance);
		}
		else if (inside)
		{

			speed = 20;
		}

		Vector3 dir = target.transform.position + offset + constrainedTarget - transform.position;

		transform.position += dir * speed * Time.deltaTime;
	}
}
