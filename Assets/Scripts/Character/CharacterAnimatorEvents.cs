using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorEvents : MonoBehaviour
{
	public void StartLeftAttack()
	{
		transform.parent.SendMessage("StartLeftAttack");
	}

	public void EndLeftAttack()
	{
		transform.parent.SendMessage("EndLeftAttack");
	}
}
