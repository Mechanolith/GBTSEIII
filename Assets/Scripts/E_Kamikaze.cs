using UnityEngine;
using System.Collections;

public class E_Kamikaze : MonoBehaviour {
	public float moveSpeed,dragScale,initialDrag,countdown,deathThrowsSpeed,suicideHP, triggerDistance, explosionSize;
	public Vector3 target,lookDirection;
	public Behaviour halo;
	public AudioClip explode,beep;
	public A_Logic_God logicGod;

	// Use this for initialization
	void Start () {
		logicGod = GameObject.Find("A_Cogitator").GetComponent<A_Logic_God>();
	}
	
	// Update is called once per frame
	void Update () {
		target = logicGod.playerPosition;
		lookDirection = target - transform.position;
		transform.rotation = Quaternion.FromToRotation (Vector3.up, lookDirection);
		
		rigidbody.AddForce(transform.up * moveSpeed, ForceMode.Force);
		rigidbody.drag = rigidbody.velocity.magnitude * dragScale + initialDrag;
		
		if (lookDirection.magnitude < triggerDistance) {
			StartCoroutine(Detonate());
		}
	}

	IEnumerator Detonate(){
		//MoveSpeed -= DeathThrowsSpeed; //Maybe implement later. Speed up/slow down before death.
		
		float EndTime=Time.time + countdown;
		halo.enabled = false;
		while(Time.time < EndTime){
			halo.enabled = true;
			//AudioSource.PlayClipAtPoint(beep, transform.position);
			yield return new WaitForSeconds(0.2F);
			halo.enabled = false;
			yield return new WaitForSeconds(0.2F);
		}
		//AudioSource.PlayClipAtPoint(explode, transform.position);
		if (lookDirection.magnitude < explosionSize) {
			//Do damage if the player is within range of the explosion
		}
		Destroy (gameObject);
	}
}
