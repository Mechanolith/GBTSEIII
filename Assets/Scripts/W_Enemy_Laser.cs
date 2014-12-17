using UnityEngine;
using System.Collections;

public class W_Enemy_Laser : MonoBehaviour {
	public float moveSpeed;
	public A_Stats_God statsGod;
	public A_Stats_God.EnemyTypes shotType;
	public GameObject missEffect, impactEffect;
	Quaternion particleRotation;

	// Use this for initialization
	void Start () {
		statsGod = GameObject.Find("A_Cogitator").GetComponent<A_Stats_God>();
		rigidbody.velocity = transform.up * moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		particleRotation = Quaternion.Euler(transform.rotation.z+90,90,0);

		if(col.tag == "Player"){
			statsGod.DamagePlayer(shotType);
			impactEffect.particleSystem.Play();
			impactEffect.transform.parent = null;
			//Instantiate(targetHit,transform.position,particleRotation);
			Destroy(gameObject);
		}
		else if(col.tag != "Enemy"  && col.tag != "Projectile"){
			//Instantiate(targetMiss,transform.position,particleRotation);
			missEffect.particleSystem.Play();
			missEffect.transform.parent = null;
			Destroy(gameObject);
		}
	}
}
