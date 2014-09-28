using UnityEngine;
using System.Collections;

public class W_Enemy_Laser : MonoBehaviour {
	public float moveSpeed;
	public A_Stats_God statsGod;
	public A_Stats_God.EnemyTypes shotType;

	// Use this for initialization
	void Start () {
		statsGod = GameObject.Find("A_Cogitator").GetComponent<A_Stats_God>();
		rigidbody.velocity = transform.up * moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			statsGod.DamagePlayer(shotType);
			Destroy(gameObject);
		}

		if(col.tag != "Enemy"  && col.tag != "Projectile"){
			Destroy(gameObject);
		}
	}
}
