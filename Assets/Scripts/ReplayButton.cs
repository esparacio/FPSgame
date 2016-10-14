using UnityEngine;
using System.Collections;

public class ReplayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown(){
		transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
	}

	public void OnMouseUp(){
		transform.localScale = Vector3.one;
		print ("Replay!");
	}
}
