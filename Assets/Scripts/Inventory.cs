using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public GameObject leftHandTransform;
	public GameObject rightHandTransform;

	public List<Item> inventoryList;

	public GameObject currentLeftItem;
	public GameObject currentRightItem;

	void Update()
	{
		if (Input.GetKey("1"))
		{
			SetLeftItem(0);
		}
	}

	public void AddItem(Item item)
	{
		inventoryList.Add(item);
		SetLeftItem(inventoryList.Count-1);
	}

	public void SetLeftItem(int index)
	{
		if (index >= inventoryList.Count)
			return;

		if (currentLeftItem != null)
		{
			Destroy(currentLeftItem);
		}

		GameObject instance = inventoryList[index].prefab;
		currentLeftItem = Instantiate(instance, Vector3.zero, Quaternion.identity, leftHandTransform.transform);
		currentLeftItem.transform.localPosition = Vector3.zero;
		currentLeftItem.transform.localRotation = Quaternion.identity;
	}

	public void SetRightItem(int index)
	{
		if (index >= inventoryList.Count)
			return;

		if (currentRightItem != null)
		{
			Destroy(currentRightItem);
		}

		GameObject instance = inventoryList[index].prefab;
		currentRightItem = Instantiate(instance, Vector3.zero, Quaternion.identity, leftHandTransform.transform);
		currentRightItem.transform.localPosition = Vector3.zero;
		currentRightItem.transform.localRotation = Quaternion.identity;
	}
}
