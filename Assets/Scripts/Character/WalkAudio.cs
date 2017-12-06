using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WalkAudio : MonoBehaviour {
    public AudioSource walk;
    public AudioSource jump;
    public AudioSource land;
    private CharacterController controller;
    bool grounded = true;
    bool previouslyGrounded = true;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>(); ;
    }

// Update is called once per frame
void Update () {
        if (controller.isGrounded)
        {
            grounded = true;
            if (previouslyGrounded == false)
                land.Play();
            previouslyGrounded = true;
        }
        else {
            if (grounded == true)
                grounded = false;
            else
                previouslyGrounded = false;
        }
        if (previouslyGrounded && (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))) {
            if (!walk.isPlaying)
                walk.Play();
        } else {
            walk.Stop();
        }

        if (Input.GetKeyDown("z")) {
            jump.Play();
        }


        	
	}

}

