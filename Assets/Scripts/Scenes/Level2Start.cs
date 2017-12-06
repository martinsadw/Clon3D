using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Start : MonoBehaviour
{
	public Item item;
	public GameObject player;

	void Start()
	{
		Inventory playerInventory = player.GetComponent<Inventory>();

		playerInventory.AddItem(item);
	}
}
