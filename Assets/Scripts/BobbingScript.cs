﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingScript : MonoBehaviour
{
	public Vector3 amplitude;
	public Vector3 frequency;
	public Vector3 phase;

	void Update()
	{
		Vector3 newPosition;
		newPosition.x = amplitude.x * Mathf.Sin(Mathf.PI * 2 * frequency.x * Time.fixedTime + phase.x);
		newPosition.y = amplitude.y * Mathf.Sin(Mathf.PI * 2 * frequency.y * Time.fixedTime + phase.y);
		newPosition.z = amplitude.z * Mathf.Sin(Mathf.PI * 2 * frequency.z * Time.fixedTime + phase.z);

		transform.localPosition = newPosition;
	}
}
