using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float spawnTime = 3f;
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


		RaycastHit hit = new RaycastHit ();
		Vector3 rayDirection = player.transform.position - this.transform.position;

		if (hit.transform == player.transform) {
			print ("player seen");
		} else {
			
		}
	}
}
