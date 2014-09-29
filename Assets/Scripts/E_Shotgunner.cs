using UnityEngine;
using System.Collections;

public class E_Shotgunner : MonoBehaviour {
	public float moveSpeed, dragScale, initialDrag, maxCircleDistance, circleSpeed, directionTime, rateOfFire;
	float coolDown, circleTimer, HP;
	int circleDirection;
	Vector3 target, lookDirection;
	public A_Logic_God logicGod;
	public A_Stats_God statsGod;
	public E_Shotgunner_Weapon gunScript;

	// Use this for initialization
	void Start () {
		logicGod = GameObject.Find("A_Cogitator").GetComponent<A_Logic_God>();
		statsGod = GameObject.Find("A_Cogitator").GetComponent<A_Stats_God>();
		gunScript = gameObject.GetComponent<E_Shotgunner_Weapon>();
		
		HP = statsGod.baseShotgunHP * statsGod.enemyHPMulti;
		//damage = statsGod.baseShotgunDmg * statsGod.enemyDamageMulti;

		circleDirection = 1;
	}
	
	// Update is called once per frame
	void Update () {
		coolDown += Time.deltaTime;

		target = logicGod.playerPosition;
		lookDirection = target - transform.position;
		transform.rotation = Quaternion.FromToRotation (Vector3.up, lookDirection);

		if (lookDirection.magnitude < maxCircleDistance){
			rigidbody.AddForce(transform.right * circleSpeed * circleDirection, ForceMode.Force);
			rigidbody.drag = rigidbody.velocity.magnitude * dragScale + initialDrag;
			circleTimer += Time.deltaTime;

			if(circleTimer > directionTime){
				circleDirection *= -1;
				circleTimer = 0;
			}

			if(coolDown > rateOfFire){
				gunScript.OnFire();
				coolDown = 0;
			}
		}
		else{
			rigidbody.AddForce(transform.up * moveSpeed, ForceMode.Force);
			rigidbody.drag = rigidbody.velocity.magnitude * dragScale + initialDrag;
		}
	}

	void TakeDamage(){
		HP -= statsGod.playerDamage;
		
		if (HP <= 0){
			statsGod.ShotgunnerKill();
			Destroy(gameObject);
		}
	}
}
