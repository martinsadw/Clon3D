using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrap : MonoBehaviour
{
	public Item item;
	public List<GameObject> spawnersList;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Player")
		{
			Inventory playerInventory = other.gameObject.GetComponent<Inventory>();

			playerInventory.AddItem(item);
			Destroy(gameObject);

			foreach (GameObject spawner in spawnersList)
				spawner.SetActive(true);
		}
	}
}
