using UnityEngine;
using System.Collections;

public class A_Stats_God : MonoBehaviour {
	public float baseKamikazeHP, baseKamikazeDmg, baseDodgeHP, baseDodgeDmg, baseShotgunHP, baseShotgunDmg;
	public float enemyHPMulti, enemyDamageMulti, HPMultiMulti, damageMultiMulti, difficultyStepTime;
	public float timer, playerHP, playerDamage;
	public float dodgerScore, kamikazeScore, shotgunnerScore, scoreMulti, scoreStep;
	public float score;

	public enum EnemyTypes{
		Kamikaze,
		Dodger,
		Shotgunner
	}
	
	void Start () {
		enemyHPMulti = 1;
		enemyDamageMulti = 1;
		scoreMulti = 1;
		playerHP = PlayerPrefs.GetFloat("playerHealth");
		playerDamage = PlayerPrefs.GetFloat("playerDamage") + PlayerPrefs.GetFloat("playerLaserDamage");
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
			//CHANGE WEAPON TYPE/BEHAVIOUR HERE
		}

		if(Input.GetKeyDown(KeyCode.Alpha2)){
			playerDamage = PlayerPrefs.GetFloat("playerDamage") + PlayerPrefs.GetFloat("playerShotgunDamage");
			//CHANGE WEAPON TYPE/BEHAVIOUR HERE
		}

		if(Input.GetKeyDown(KeyCode.Alpha3)){
			playerDamage = PlayerPrefs.GetFloat("playerDamage") + PlayerPrefs.GetFloat("playerRocketDamage");
			//CHANGE WEAPON TYPE/BEHAVIOUR HERE
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
