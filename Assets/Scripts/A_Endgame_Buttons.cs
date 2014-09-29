using UnityEngine;
using System.Collections;

public class A_Endgame_Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.white;
	}

	void OnMouseDown(){

	}
}
