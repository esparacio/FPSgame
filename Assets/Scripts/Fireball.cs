using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        Debug.Log("collided");
        if (collidedWith.tag != "enemy") {
            Destroy(this.gameObject);
            if (collidedWith.tag == "player") {
                //remove health
            }
        }
    }
}
