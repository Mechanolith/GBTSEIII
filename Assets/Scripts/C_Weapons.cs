using UnityEngine;
using System.Collections;

public class C_Weapons : MonoBehaviour {
	public  float coolDown, laserCoolDown, shotgunCoolDown, RPGCoolDown, ShotSpawnDistance;
	public GameObject Laser, RPG;
	public AudioClip LaserPew;
	public A_Stats_God statsGod;
	Vector3 Place;
	public int shotNumber;
	public float shotRadius;
	public GameObject buckshot;
	float angleStep, currentAngle, shotPosX, shotPosY;
	Vector3 shotPosition;
	Quaternion shotRotation;

	void Start(){
		statsGod = GameObject.Find("A_Cogitator").GetComponent<A_Stats_God>();
	}

	void Update () {
		coolDown -= Time.deltaTime;
		
		if (Input.GetKey (KeyCode.Mouse0) && coolDown < 0){
			switch(statsGod.weaponType){
				case A_Stats_God.WeaponTypes.Laser:
					FireLaser();
					break;
				case A_Stats_God.WeaponTypes.Shotgun:
					FireShotgun();
					break;
				case A_Stats_God.WeaponTypes.RPG:
					FireRPG();
					break;
				default:
					break;
			}
		}
	}

	void FireLaser(){
		Place = transform.position+transform.up*ShotSpawnDistance;
		Instantiate (Laser,Place,transform.rotation);
		//AudioSource.PlayClipAtPoint(LaserPew, transform.position);
		//A_LogicalGameLogic.inst.Shots += 2;
		coolDown = laserCoolDown;
	}

	void FireShotgun(){
		angleStep = 180/(shotNumber+1);					//Find how much space there is between each shot
		currentAngle = -transform.eulerAngles.z + 270;	//Set the leftmost point of the arc
		print ("Initial Angle = " + currentAngle);
		
		for(int i = 0; i < shotNumber; i++){
			currentAngle += angleStep;		//Move to the next shot trajectory
			print ("Shot " + i + " = " + currentAngle);
			shotPosX = (shotRadius * Mathf.Sin(currentAngle * Mathf.Deg2Rad)) + transform.position.x;		//Find the position to spawn it at
			shotPosY = (shotRadius * Mathf.Cos(currentAngle * Mathf.Deg2Rad)) + transform.position.y;
			print ("Shot " + i + " Ang = " + currentAngle * Mathf.Deg2Rad);
			print ("Shot " + i + " X = " + shotPosX + " Y = " + shotPosY);
			shotPosition = new Vector3(shotPosX,shotPosY,0);
			shotRotation = Quaternion.Euler(0,0,-currentAngle);		//Find the angle to spawn it at
			Instantiate(buckshot, shotPosition, shotRotation);		//Spawn it at the right position and angle
		}
		
		coolDown = shotgunCoolDown;
	}

	void FireRPG(){
		Place = transform.position+transform.up*ShotSpawnDistance;
		Instantiate (RPG,Place,transform.rotation);
		//A_LogicalGameLogic.inst.Shots += 2;
		coolDown = RPGCoolDown;
	}
}
