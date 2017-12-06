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
		if (counter <= 0)
		{
			foreach (GameObject tiedObject in objectList)
			{
				Destroy(tiedObject);
			}
		}
	}

	public void IncrementCounter(int amount = 1)
	{
		counter += amount;
	}
}
