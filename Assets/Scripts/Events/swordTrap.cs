﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordTrap : MonoBehaviour
{
	public Item item;
	public List<GameObject> spawnersList;

	void OnTriggerEnter(Collider other)
	{
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
