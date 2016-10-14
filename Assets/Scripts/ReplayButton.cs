using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
	By Elena Sparacio and Patrick Lathan
	Copyright (C) 2016
	Full Credits in the README
*/ 

public class ReplayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Restart scene when Replay is clicked!
    public void Replay() {
        SceneManager.LoadScene("scene_0");
    }
}
