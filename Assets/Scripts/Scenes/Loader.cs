using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
	public GameObject mapManager;

	void Awake()
	{
		if (MapManager.instance == null)
			Instantiate(mapManager);
	}
}
