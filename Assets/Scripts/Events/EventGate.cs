using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGate : MonoBehaviour
{
	public int counter;
	public List<GameObject> objectList;

	public void DecrementCounter(int amount = 1)
	{
		counter -= amount;
		Debug.Log("ccccc");
		if (counter <= 0)
		{
			Debug.Log("bbbbb");
			foreach (GameObject tiedObject in objectList)
			{
				Debug.Log("aaaaa");
				Destroy(tiedObject);
			}
		}
	}

	public void IncrementCounter(int amount = 1)
	{
		counter += amount;
	}
}
