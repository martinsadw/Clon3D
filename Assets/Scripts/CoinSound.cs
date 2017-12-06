using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public AudioSource coinPickup;

    private void OnDestroy()
    {
        coinPickup.Play();
    }
}
