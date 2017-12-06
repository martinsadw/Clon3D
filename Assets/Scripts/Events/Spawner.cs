using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public int numEnemies;
	public GameObject enemyPrefab;
	public PlayerTrigger targetTrigger;
	public float delay;

	private EventGateObject eventGateObject;

	// Use this for initialization
	void OnEnable()
	{
		eventGateObject = GetComponent<EventGateObject>();
		StartCoroutine(SpawnEnemies());
	}

	protected IEnumerator SpawnEnemies()
	{
		while (numEnemies > 0)
		{
			GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
			AreaFollow areaFollow = enemy.GetComponent<AreaFollow>();
			areaFollow.targetTrigger = targetTrigger;
			if (eventGateObject)
			{
				EventGateObject enemyEventGateObject = enemy.AddComponent(typeof(EventGateObject)) as EventGateObject;
				enemyEventGateObject.eventGate = eventGateObject.eventGate;
			}

			--numEnemies;

			yield return new WaitForSeconds(delay);
		}
		Destroy(gameObject);
	}
}
