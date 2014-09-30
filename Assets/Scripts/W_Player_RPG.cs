using UnityEngine;
using System.Collections;

public class W_Player_RPG : MonoBehaviour {
	public float RPGSpeed;
	public int RPGDamage, blastRadius;
	public GameObject particles;
	public AudioClip rpgBoom;
	
	// Use this for initialization
	void Start () {
		rigidbody.AddRelativeForce (Vector3.up * RPGSpeed, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision col){
		RaycastHit[] hits = Physics.SphereCastAll (transform.position,blastRadius,Vector3.up,0.01f);
		print ("Boom");
		
		if(hits.Length > 0){
			foreach (RaycastHit hit in hits) {
				hit.transform.SendMessage("OnHit",RPGDamage,SendMessageOptions.DontRequireReceiver);
				print ("Ouch");
			}
		}
		//AudioSource.PlayClipAtPoint(rpgBoom,transform.position);
		Destroy (gameObject);
	}
}
