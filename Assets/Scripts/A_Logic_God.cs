using UnityEngine;
using System.Collections;

public class A_Logic_God : MonoBehaviour {
	public static A_Logic_God inst;
	public Vector3 playerPosition;

	// Use this for initialization
	void Start () {
		inst = this;
		PlayerPrefs.SetFloat("currentScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
