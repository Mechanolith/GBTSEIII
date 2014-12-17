using UnityEngine;
using System.Collections;

public class P_Particle_Destruct : MonoBehaviour {
	public float destructTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		destructTime -= Time.deltaTime;

		if(destructTime < 0){
			Destroy(gameObject);
		}
	}
}
