using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    float rcsThrust = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;
       
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //check are there any keys down?
        Rotate();
        Thrust();
    }

    private void Thrust()
    {
        //ask q. about key that we have pressed
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up); //position in unity is vector 3
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // so it doesnt layer on top of each other.
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of rotation

        float rotationThisFrame = rcsThrust * Time.deltaTime; //deltaTime = frame time

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; //resume physics control of rotation.
        
    }
}

//bind our keys directly to the thrusters on the rocket.
//virtual input layout
