using UnityEngine;
using System.Collections;

public class E_Spawner : MonoBehaviour {
	public GameObject dodger, kamikaze, shotgunner;
	
	public void SpawnFoe(A_Stats_God.EnemyTypes type){
		switch (type){
		case A_Stats_God.EnemyTypes.Dodger:
			Instantiate(dodger, transform.position, transform.rotation);
			break;
		case A_Stats_God.EnemyTypes.Kamikaze:
			Instantiate(kamikaze, transform.position, transform.rotation);
			break;
		case A_Stats_God.EnemyTypes.Shotgunner:
			Instantiate(shotgunner, transform.position, transform.rotation);
			break;
		default:
			break;
		}
	}
}
