using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
	public float animationSmoothness = 0.1f;

	private Inventory inventory;
	private PlayerControl playerControl;
	private Animator animator;

	void Start()
	{
		inventory = GetComponent<Inventory>();
		playerControl = GetComponent<PlayerControl>();
		animator = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		float speedPercent = playerControl.curVel.magnitude / playerControl.maxSpeed;
		animator.SetFloat("speedPercent", speedPercent, animationSmoothness, Time.deltaTime);

		if (Input.GetKeyDown("x"))
		{
			animator.SetTrigger("usingLeft");
		}
	}

	public void StartLeftAttack()
	{
		GameObject leftItem = inventory.currentLeftItem;

		if (leftItem != null)
		{
			leftItem.GetComponent<BoxCollider>().enabled = true;
		}
	}

	public void EndLeftAttack()
	{
		GameObject leftItem = inventory.currentLeftItem;

		if (leftItem != null)
		{
			leftItem.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
