using UnityEngine;
using System.Collections;

public class A_Stats_God : MonoBehaviour {
	public float baseKamikazeHP, baseKamikazeDmg, baseDodgeHP, baseDodgeDmg, baseShotgunHP, baseShotgunDmg;
	public float enemyHPMulti, enemyDamageMulti, HPMultiMulti, damageMultiMulti, difficultyStepTime;
	public float timer, playerHP, playerDamage;

	public enum EnemyTypes{
		Kamikaze,
		Dodger,
		Shotgunner
	}

	// Use this for initialization
	void Start () {
		enemyHPMulti = 1;
		enemyDamageMulti = 1;
		//playerHP = PlayerPrefs.GetFloat("PlayerHP");
		//playerDamage = PlayerPrefs.GetFloat("PlayerDamage");
		playerHP = 100;
		playerDamage = 10;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(timer > difficultyStepTime){
			enemyHPMulti *= HPMultiMulti;
			enemyDamageMulti *= damageMultiMulti;
			timer = 0;
		}

		if (playerHP <= 0){
			//Lose State
			print ("YOU LOSE.");
			Time.timeScale = 0;
			//Trigger End scene
		}
	}

	public void DamagePlayer(EnemyTypes dmgType){
		switch(dmgType){
			case EnemyTypes.Kamikaze:
				playerHP -= baseKamikazeDmg * enemyDamageMulti;
			break;

			case EnemyTypes.Dodger:
				playerHP -= baseDodgeDmg * enemyDamageMulti;
			break;

			case EnemyTypes.Shotgunner:
				playerHP -= baseShotgunDmg * enemyDamageMulti;
			break;

			default:
			break;
		}
	}
}
