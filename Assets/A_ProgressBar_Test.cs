using UnityEngine;
using System.Collections;

public class A_ProgressBar_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(0,transform.localScale.y,transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime,transform.localScale.y,transform.localScale.z);
		transform.position = new Vector3(transform.position.x + Time.deltaTime/2,transform.position.y,transform.position.z);
	}
}
