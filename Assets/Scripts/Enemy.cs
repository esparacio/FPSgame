using UnityEngine;
using System.Collections;

/*
	By Elena Sparacio and Patrick Lathan
	Copyright (C) 2016
	Full Credits in the README
*/ 

public class Enemy : MonoBehaviour {

	public float spawnTime = 3f;
    public GameObject Fireball;
    GameObject player;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("DetectPlayer", spawnTime, spawnTime);
		player = GameObject.Find ("Player");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DetectPlayer(){

        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - this.transform.position;
        Ray ray = new Ray(this.transform.position, rayDirection);

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.tag.Equals("Player")) {
                GameObject fireballObject = Instantiate(Fireball) as GameObject;
                fireballObject.transform.position = this.transform.position;
                fireballObject.GetComponent<Rigidbody>().velocity = Vector3.Normalize(rayDirection)*10;
            }

        }
    }
}
