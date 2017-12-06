using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestructionPlayer : MonoBehaviour
{
	public DestructionController destruction;
	public float destructionMaxDistance;

	void Start ()
	{

	}

	void Update ()
	{
		if (destruction.curPos < transform.position.z - destructionMaxDistance)
			destruction.curPos = transform.position.z - destructionMaxDistance;

		if (transform.position.y < -30.0f)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
