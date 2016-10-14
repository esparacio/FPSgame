using UnityEngine;
using System.Collections;

/*
	By Elena Sparacio and Patrick Lathan
	Copyright (C) 2016
	Full Credits in the README
*/ 

public class RayShooter : MonoBehaviour {
	[SerializeField] GameObject Sphere;
	public bool isAlive;

	private Camera mainCamera;

	void Start () {
		isAlive = true; 
		mainCamera = GetComponent<Camera> ();
		Cursor.lockState = CursorLockMode.Locked; 
	}

	void Update () {

		if ((Input.GetMouseButtonDown (0)) && (isAlive == true)) {
			Vector3 origin = new Vector3 (mainCamera.pixelWidth / 2,
                mainCamera.pixelHeight / 2,
				0);
			Ray ray = mainCamera.ScreenPointToRay (origin);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				StartCoroutine (Shoot (hit.point));    
			}
		}
	}

	private IEnumerator Shoot(Vector3 position){
		
		GameObject bullet = Instantiate (Sphere) as GameObject;
		bullet.AddComponent<Rigidbody> ();
		bullet.tag = "bullet";
		bullet.transform.position = position;
		bullet.transform.localScale = new Vector3(0.25f,0.25f,0.25f);
		yield return new WaitForSeconds (1);
		Destroy (bullet);
	} 

	public void YouDied(){

		isAlive = false;
        Cursor.lockState = CursorLockMode.None;

    }


}
