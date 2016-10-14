using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Replay() {
        SceneManager.LoadScene("scene_0");
    }
}
