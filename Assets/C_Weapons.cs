using UnityEngine;
using System.Collections;

public class C_Weapons : MonoBehaviour {
	public  float WeaponCoolDown, RateOfFire, ShotSpawnDistance;
	public GameObject Laser;
	public AudioClip LaserPew;
	Vector3 Place;
	
	void Update () {
				
		WeaponCoolDown += Time.deltaTime;
		
		if (Input.GetKey (KeyCode.Mouse0) && WeaponCoolDown > RateOfFire)
		{
			Place = transform.position+transform.up*ShotSpawnDistance;
			Instantiate (Laser,Place,transform.rotation);
			//AudioSource.PlayClipAtPoint(LaserPew, transform.position);
            //A_LogicalGameLogic.inst.Shots += 2;
            WeaponCoolDown = 0;
		}
	}

	void MakeProjectile(){
		Instantiate (Laser,Place,transform.rotation);
	}
}
