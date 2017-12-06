using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 5;
	public int curHealth;
	[HideInInspector] public bool respawning = false;

	void Start()
	{
		curHealth = maxHealth;
	}

	public void Update()
	{
		respawning = false;
	}

	public void TakeDamage(int amount)
	{
		curHealth -= amount;

		if (curHealth <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
