using UnityEngine;
using System.Collections;

public class C_Weapons : MonoBehaviour {
	public  float WeaponCoolDown, RateOfFire, ShotSpawnDistance;
	public GameObject Laser, RPG, Shotgun;
	public AudioClip LaserPew;
	Vector3 Place;

	void Update () {
				
		WeaponCoolDown += Time.deltaTime;
		
		if (Input.GetKey (KeyCode.Mouse0) && WeaponCoolDown > RateOfFire) //this shit is for the laser shootings. 
		{
			Place = transform.position+transform.up*ShotSpawnDistance;
			Instantiate (Laser,Place,transform.rotation);
			//AudioSource.PlayClipAtPoint(LaserPew, transform.position);
            //A_LogicalGameLogic.inst.Shots += 2;
            WeaponCoolDown = 0;
		}

		if (Input.GetKey (KeyCode.E) && WeaponCoolDown > RateOfFire) //Do the RPG shit
		{
			Place = transform.position+transform.up*ShotSpawnDistance;
			Instantiate (RPG,Place,transform.rotation);
																			//A_LogicalGameLogic.inst.Shots += 2;
			WeaponCoolDown = 0;
		}

		if (Input.GetKey (KeyCode.Mouse1) && WeaponCoolDown > RateOfFire) //This shit is for shotgun shootings
		{
			Place = transform.position+transform.up*ShotSpawnDistance;
			Instantiate (Shotgun,Place,transform.rotation);
			//A_LogicalGameLogic.inst.Shots += 2;
			WeaponCoolDown = 0;
		}

	}

	void MakeProjectile(){
		Instantiate (Laser,Place,transform.rotation);
	}

		

	
}
