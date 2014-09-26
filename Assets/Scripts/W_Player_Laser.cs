using UnityEngine;
using System.Collections;

public class W_Player_Laser : MonoBehaviour {
	public float moveSpeed, damage;


	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.up * moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Enemy"){
			//Make the bad guy take damage
		}

		if(col.tag != "Player"  && col.tag != "Projectile"){
			Destroy(gameObject);
		}
	}
}
