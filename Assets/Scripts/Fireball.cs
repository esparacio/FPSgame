using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
	By Elena Sparacio and Patrick Lathan
	Copyright (C) 2016
	Full Credits in the README
*/ 

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

					//wanted to change color when damaged, but couldn't figure it out 
					//damageImage.color = Color.Lerp(flashColor, Color.clear, Time.deltaTime * 100f);
					//damageImage.color = Color.Lerp(Color.clear, flashColor, Time.deltaTime * 0.5f);



                }
            }
        }
    }



}
