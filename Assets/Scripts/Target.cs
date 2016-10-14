using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
	By Elena Sparacio and Patrick Lathan
	Copyright (C) 2016
	Full Credits in the README
*/ 


public class Target : MonoBehaviour {
	[SerializeField] GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "bullet") {
			Destroy (target);

			GameObject scoreObject = GameObject.Find ("Score");
			Text textObject = scoreObject.GetComponent<Text>();
			int score = int.Parse (textObject.text);
			score = score + 1; 
			textObject.text = score.ToString();

			checkWin ();
		} 
	}

	void checkWin(){
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("target");
		if (targets.Length <= 1) {
			
			GameObject winObject = GameObject.Find ("Win");
			Text textObject = winObject.GetComponent<Text>();
			textObject.text = "YOU WIN!";

		}
	}

}
