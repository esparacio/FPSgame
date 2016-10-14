using UnityEngine;
using System.Collections;

/*
	By Elena Sparacio and Patrick Lathan
	Copyright (C) 2016
	Full Credits in the README
*/ 

public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;
	public float vertSpeed;
	public float jumpSpeed = 100f;
	private CharacterController charController;

	// Use this for initialization
	void Start () {
		charController = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		if (charController.isGrounded) {
			if (Input.GetButtonDown ("Jump")) 
				vertSpeed = jumpSpeed;
			else 
				vertSpeed = 0;
		}
		else{
			vertSpeed += gravity;
		}
		Vector3 movement = new Vector3(deltaX, vertSpeed, deltaZ); 
		movement = Vector3.ClampMagnitude (movement, speed);

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		charController.Move (movement);
	
	}


}
