using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
	public DestructionController destruction;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (transform.position.y < -30)
		{
			Destroy(gameObject);
		}

		if (destruction.curPos > transform.position.z)
		{
			if (Random.value < 0.005f + 0.01 * (destruction.curPos - transform.position.z))
			{
				rb.useGravity = true;
				rb.isKinematic = false;
			}
		}
	}
}


// z / speed = x
// z / 2speed = y
//
// x + (y-x)*t
// z/speed + (z/2speed - 2z/2speed) * t
// z/speed - (z/2speed)*t
