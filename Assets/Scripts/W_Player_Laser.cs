using UnityEngine;
using System.Collections;

public class W_Player_Laser : MonoBehaviour {
	public float moveSpeed, damage;
	public GameObject targetHit, targetMiss, missEffect, impactEffect;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.up * moveSpeed;
//		missEffect.particleSystem.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		//	Setting the rotation of the impact partical effect
		//		(Should be opposite to the bullet direction
//		particleRotation.eulerAngles = transform.eulerAngles;
		print (transform.eulerAngles);

//		missEffect.SetActive(true);


		if(col.tag == "Enemy"){
			//Instantiate(targetHit,transform.position,particleRotation);
			impactEffect.particleSystem.Play();
			impactEffect.transform.parent = null;
			col.SendMessage("TakeDamage");
			Destroy(gameObject);
		}
		else if(col.tag != "Player"  && col.tag != "Projectile"){
			//Instantiate(targetMiss,transform.position,particleRotation);
			missEffect.particleSystem.Play();
			missEffect.transform.parent = null;
			Destroy(gameObject);
		}
	}
}
