using UnityEngine;
using System.Collections;

public class E_Dodger : MonoBehaviour {
	public float coolDown, rateOfFire, HP;
	public float moveSpeed, range, dragScale, initialDrag;
	public float shotCount, dodgeDirection, dodgeForce;
	public GameObject shot;
	public Vector3 target,lookDirection;
	public AudioClip gunnerPew;
	public A_Logic_God logicGod;
	//public ParticleSystem PARTS;
	
	// Use this for initialization
	void Start () {
		dodgeDirection = 1;
		logicGod = GameObject.Find("A_Cogitator").GetComponent<A_Logic_God>();
	}
	
	// Update is called once per frame
	void Update () {
		
		target = logicGod.playerPosition;
		lookDirection = target - transform.position;
		transform.rotation = Quaternion.FromToRotation (Vector3.up, lookDirection);
		
		if (lookDirection.magnitude > range) {
			rigidbody.AddForce(transform.up * moveSpeed, ForceMode.Force);
			rigidbody.drag = rigidbody.velocity.magnitude * dragScale + initialDrag;
		}
		
		coolDown += Time.deltaTime;
		
		if(coolDown > rateOfFire && lookDirection.magnitude < range){
			Instantiate (shot,(transform.position+transform.up*2),transform.rotation);
			//PARTS.Play ();
			//particleSystem.enableEmission = true;
			coolDown = 0;
			//AudioSource.PlayClipAtPoint(gunnerPew, transform.position);
			shotCount++;
		}
		
		if(shotCount == 2){
			rigidbody.AddForce(transform.right * dodgeForce * dodgeDirection, ForceMode.Force);
			dodgeDirection *= -1;
			shotCount = 0;
		}
	}
}
