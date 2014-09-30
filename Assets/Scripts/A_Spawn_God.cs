using UnityEngine;
using System.Collections;

public class A_Spawn_God : MonoBehaviour {
	public float roll, outcome, dodgerChance, kamikazeChance;	//NOTE: Chances work such that 0 to dodgeChance = dodge, kamikazeChance to 100 = kamikaze, dodgeChance+1 to kamikazeChance-1 = shotgun
	public float timer, spawnTime;								//...if that makes sense.
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if (timer > spawnTime){
			outcome = Random.Range (0, roll);
			if (outcome < dodgerChance){
				PickSpawn(A_Stats_God.EnemyTypes.Dodger);
			}
			else if (outcome > kamikazeChance){
				PickSpawn(A_Stats_God.EnemyTypes.Kamikaze);
			}
			else{
				PickSpawn(A_Stats_God.EnemyTypes.Shotgunner);
			}
			
			timer = 0;
		}
	}
	
	void PickSpawn(A_Stats_God.EnemyTypes type){
		int index;
		
		index = Random.Range (0, transform.childCount);		//Picks a number
		
		transform.GetChild (index).GetComponent<E_Spawner>().SpawnFoe(type);	//Grabs that child and tells it to make an enemy
	}
}
