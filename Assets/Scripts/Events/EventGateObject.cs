using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGateObject : MonoBehaviour
{
	public EventGate eventGate;

	void OnDestroy()
	{
		eventGate.DecrementCounter();
	}
}
