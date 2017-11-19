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

	private Animator animator;

	void Start()
	{
		animator = GetComponentInChildren<Animator>();
	}

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

		Item selectedItem = inventoryList[index];

		GameObject instance = selectedItem.prefab;
		currentLeftItem = Instantiate(instance, Vector3.zero, Quaternion.identity, leftHandTransform.transform);
		currentLeftItem.transform.localPosition = Vector3.zero;
		currentLeftItem.transform.localRotation = Quaternion.identity;

		animator.SetInteger("activeItemLeft", selectedItem.type);
	}

	public void SetRightItem(int index)
	{
		if (index >= inventoryList.Count)
			return;

		if (currentRightItem != null)
		{
			Destroy(currentRightItem);
		}

		Item selectedItem = inventoryList[index];

		GameObject instance = selectedItem.prefab;
		currentRightItem = Instantiate(instance, Vector3.zero, Quaternion.identity, leftHandTransform.transform);
		currentRightItem.transform.localPosition = Vector3.zero;
		currentRightItem.transform.localRotation = Quaternion.identity;

		animator.SetInteger("activeItemRight", selectedItem.type);
	}
}
