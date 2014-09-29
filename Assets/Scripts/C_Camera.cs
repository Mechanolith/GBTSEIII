using UnityEngine;
using System.Collections;

public class C_Camera: MonoBehaviour {
	public Vector3 distanceVector;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distanceVector = A_Logic_God.inst.playerPosition - transform.position;
		distanceVector.z = 0;
		transform.Translate(Vector3.Normalize(distanceVector)*Time.deltaTime*distanceVector.magnitude*2);
	}
}