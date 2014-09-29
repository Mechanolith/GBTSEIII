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

	// Use this for initialization
	void Start () {
		enemyHPMulti = 1;
		enemyDamageMulti = 1;
		scoreMulti = 1;
		//playerHP = PlayerPrefs.GetFloat("PlayerHP");
		//playerDamage = PlayerPrefs.GetFloat("PlayerDamage");
		playerHP = 100;
		playerDamage = 100;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(timer > difficultyStepTime){
			enemyHPMulti *= HPMultiMulti;
			enemyDamageMulti *= damageMultiMulti;
			scoreMulti += scoreStep;
			timer = 0;
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

		if (playerHP <= 0){
			//Lose State
			print ("YOU LOSE.");
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
