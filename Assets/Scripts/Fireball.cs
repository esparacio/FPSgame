﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fireball : MonoBehaviour {

	//This code was adapted from the unity 3d tutorial credited in the readme
	public Slider healthSlider;                                 
	public Image damageImage;                                   
	public float flashSpeed = 2f;                               
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	public bool trigger;


	// Use this for initialization
	void Start () {

		trigger = false; 
		healthSlider = GameObject.Find ("HealthSlider").GetComponent<Slider>();
		damageImage = GameObject.Find ("Damage").GetComponent<Image>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Death(){

		//healthSlider.value = newHealth;
		damageImage.color = new Color (0, 0, 0, 0.6f);

		GameObject loseObject = GameObject.Find ("Win");
		Text textObject = loseObject.GetComponent<Text>();
		textObject.text = "You lose... ";
	
		GameObject canvas = GameObject.Find ("ReplayButton");
		CanvasGroup replay = canvas.GetComponent<CanvasGroup> ();
		replay.alpha = 1;

		//stop the player from shooting
		GameObject player = GameObject.Find ("Main Camera");
		player.gameObject.SendMessage("YouDied");


	}

    void OnCollisionEnter(Collision coll) {
		
        GameObject collidedWith = coll.gameObject;

        //Ignore collisions with enemy
        if (collidedWith.tag != "enemy") {
            Destroy(this.gameObject);

            //Fireball has hit the player
            if (collidedWith.tag == "Player") {

                //Set the damage color and decrease health
                
                healthSlider.value--;

                //Death screen
                if (healthSlider.value < 1) {

					Death();
					
				} else {

                    StartCoroutine(DamageFeedback());
                    Debug.Log("Coroutine ended");


                }
            }
        }
    }


    public IEnumerator DamageFeedback() {
        //damageImage.color = flashColor;
        //yield return new WaitForSeconds(.5f);
        //damageImage.color = Color.clear;

        yield return new WaitForSeconds(flashSpeed);
        //Debug.Log("Coroutine ended");
    }

}
