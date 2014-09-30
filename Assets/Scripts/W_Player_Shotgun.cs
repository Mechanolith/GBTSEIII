using UnityEngine;
using System.Collections;

public class W_Player_Shotgun : MonoBehaviour {
	public int shotNumber;
	public float shotRadius;
	public GameObject shot;
	GameObject pellet;
	float angleStep, currentAngle, shotPosX, shotPosY;
	Vector3 shotPosition;
	Quaternion shotRotation;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnFire(){
		angleStep = 180/(shotNumber+1);					//Find how much space there is between each shot
		currentAngle = -transform.eulerAngles.z + 270;	//Set the rightmost point of the arc
		
		for(int i = 0; i < shotNumber; i++){
			currentAngle += angleStep;		//Move to the next shot trajectory
			shotPosX = (shotRadius * Mathf.Sin(currentAngle * Mathf.Deg2Rad)) + transform.position.x;		//Find the position to spawn it at
			shotPosY = (shotRadius * Mathf.Cos(currentAngle * Mathf.Deg2Rad)) + transform.position.y;
			shotPosition = new Vector3(shotPosX,shotPosY,0);
			shotRotation = Quaternion.Euler(0,0,-currentAngle);		//Find the angle to spawn it at
			pellet = Instantiate(shot, shotPosition, shotRotation) as GameObject;		//Spawn it at the right position and angle

		}
	}
	
}