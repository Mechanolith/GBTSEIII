using UnityEngine;
using System.Collections;

public class A_Stats_God : MonoBehaviour {
	public float baseKamikazeHP, baseKamikazeDmg, baseDodgeHP, baseDodgeDmg, baseShotgunHP, baseShotgunDmg;
	public float enemyHPMulti, enemyDamageMulti, HPMultiMulti, damageMultiMulti, difficultyStepTime;
	public float timer, playerHP, playerDamage;
	public float dodgerScore, kamikazeScore, shotgunnerScore, scoreMulti, scoreStep;
	public float score;
	public WeaponTypes weaponType;

	public enum EnemyTypes{
		Kamikaze,
		Dodger,
		Shotgunner
	}

	public enum WeaponTypes{
		Laser,
		Shotgun,
		RPG
	}
	
	void Start () {
		enemyHPMulti = 1;
		enemyDamageMulti = 1;
		scoreMulti = 1;
		playerHP = PlayerPrefs.GetFloat("playerHealth");
		playerDamage = PlayerPrefs.GetFloat("playerDamage") + PlayerPrefs.GetFloat("playerLaserDamage");
		weaponType = WeaponTypes.Laser;
	}

	void Update () {
		timer += Time.deltaTime;

		//Scaling Difficulty
		if(timer > difficultyStepTime){
			enemyHPMulti *= HPMultiMulti;	//Increase health/damage multiplier by a given amount (multimulti)
			enemyDamageMulti *= damageMultiMulti;
			scoreMulti += scoreStep;
			timer = 0;
		}

		//Weapon Changes
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			playerDamage = PlayerPrefs.GetFloat("playerDamage") + PlayerPrefs.GetFloat("playerLaserDamage");
			weaponType = WeaponTypes.Laser;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2)){
			playerDamage = PlayerPrefs.GetFloat("playerDamage") + PlayerPrefs.GetFloat("playerShotgunDamage");
			weaponType = WeaponTypes.Shotgun;
		}

		if(Input.GetKeyDown(KeyCode.Alpha3)){
			playerDamage = PlayerPrefs.GetFloat("playerDamage") + PlayerPrefs.GetFloat("playerRocketDamage");
			weaponType = WeaponTypes.RPG;
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

		//Lose State
		if (playerHP <= 0){
			print ("YOU LOSE, DWEEBLORD.");
			PlayerPrefs.SetFloat("currentScore",score);
			Application.LoadLevel("EndGame");
            //Trigger End scene
        }
	}

	public void DodgerKill(){
		score += dodgerScore * scoreMulti;
		score = Mathf.Round(score);
	}

	public void KamikazeKill(){
		score += kamikazeScore * scoreMulti;
		score = Mathf.Round(score);
    }

	public void ShotgunnerKill(){
		score += shotgunnerScore * scoreMulti;
		score = Mathf.Round(score);
    }
}
