using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionController : MonoBehaviour
{
	public float destructionSpeed;
	public float destructionDelay;

	[HideInInspector] public float curPos;

	void Start()
	{
		curPos = -2;
	}

	void Update()
	{
		if (destructionDelay > 0)
		{
			destructionDelay -= Time.deltaTime;
			curPos = 0;
		}

		curPos += destructionSpeed * Time.deltaTime;
	}
}
