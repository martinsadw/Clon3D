using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordTrap : MonoBehaviour
{
	public Item item;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Player")
		{
			Inventory playerInventory = other.gameObject.GetComponent<Inventory>();

			playerInventory.AddItem(item);
			Destroy(gameObject);

			// Spawn Enemies
		}
	}
}
