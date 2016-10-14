using UnityEngine;
using System.Collections;

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
        //print("detecting player");

        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - this.transform.position;
        Ray ray = new Ray(this.transform.position, rayDirection);

        if (Physics.Raycast(ray, out hit)) {
            //Debug.Log(hit.collider.ToString());
            if (hit.collider.tag.Equals("Player")) {
                GameObject fireballObject = Instantiate(Fireball) as GameObject;
                fireballObject.transform.position = this.transform.position;
                fireballObject.GetComponent<Rigidbody>().velocity = Vector3.Normalize(rayDirection)*10;
            }

        }
    }
}
