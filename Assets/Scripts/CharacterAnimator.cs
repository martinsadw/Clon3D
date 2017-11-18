using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
	public float animationSmoothness = 0.1f;

	public PlayerControl playerControl;
	public Animator animator;

	void Start()
	{
		playerControl = GetComponent<PlayerControl>();
		animator = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		float speedPercent = playerControl.curVel.magnitude / playerControl.maxSpeed;
		Debug.Log(speedPercent);
		animator.SetFloat("speedPercent", speedPercent, animationSmoothness, Time.deltaTime);
	}
}
