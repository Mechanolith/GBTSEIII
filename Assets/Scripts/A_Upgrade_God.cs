using UnityEngine;
using System.Collections;

public class A_Upgrade_God : MonoBehaviour {
	public float healthUp, damageUp, laserDamageUp, shotgunDamageUp, rocketDamageUp, tempFloat;
	int tempInt;
	TextMesh healthText, damageText, laserCurText, laserNextText, shotgunCurText, shotgunNextText, rocketCurText, rocketNextText, statPointsText;

	public enum UpgradeTypes{
		Health,
		Damage,
		Laser,
		Shotgun,
		Rocket
	}

	// Use this for initialization
	void Start () {
		healthText = GameObject.Find("T_Health_Stats").GetComponent<TextMesh>();		//Grab all the text
		damageText = GameObject.Find("T_Damage_Stats").GetComponent<TextMesh>();
		laserCurText = GameObject.Find("T_Laser_Stats_Current").GetComponent<TextMesh>();
		laserNextText = GameObject.Find("T_Laser_Stats_Next").GetComponent<TextMesh>();
		shotgunCurText = GameObject.Find("T_Shotgun_Stats_Current").GetComponent<TextMesh>();
		shotgunNextText = GameObject.Find("T_Shotgun_Stats_Next").GetComponent<TextMesh>();
		rocketCurText = GameObject.Find("T_RPG_Stats_Current").GetComponent<TextMesh>();
		rocketNextText = GameObject.Find("T_RPG_Stats_Next").GetComponent<TextMesh>();
		statPointsText = GameObject.Find("T_StatPoints_Text").GetComponent<TextMesh>();

//		tempInt = PlayerPrefs.GetInt("statPoints");		//THIS BLOCK IS FOR TESTING ONLY. REMOVE ONCE DONE.
//		tempInt += 10;
//		PlayerPrefs.SetInt("statPoints", tempInt);

		UpdateStats();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnUpgrade(UpgradeTypes upType){
		switch(upType){		//Upgrades are currently additive and linear. Feel free to make the multiplicative if you desire.
			case UpgradeTypes.Health:
				tempFloat = PlayerPrefs.GetFloat("playerHealth");
				tempFloat += healthUp;
				PlayerPrefs.SetFloat("playerHealth", tempFloat);
				break;

			case UpgradeTypes.Damage:
				tempFloat = PlayerPrefs.GetFloat("playerDamage");
				tempFloat += damageUp;
				PlayerPrefs.SetFloat("playerDamage", tempFloat);
				break;

			case UpgradeTypes.Laser:
				tempFloat = PlayerPrefs.GetFloat("playerLaserDamage");
				tempFloat += laserDamageUp;
				PlayerPrefs.SetFloat("playerLaserDamage", tempFloat);
				break;

			case UpgradeTypes.Shotgun:
				tempFloat = PlayerPrefs.GetFloat("playerShotgunDamage");
				tempFloat += shotgunDamageUp;
				PlayerPrefs.SetFloat("playerShotgunDamage", tempFloat);
				break;

			case UpgradeTypes.Rocket:
				tempFloat = PlayerPrefs.GetFloat("playerRocketDamage");
				tempFloat += rocketDamageUp;
				PlayerPrefs.SetFloat("playerRocketDamage", tempFloat);
				break;

			default:
				break;
		}

		tempInt = PlayerPrefs.GetInt("statPoints");		//Take a stat point
		tempInt--;
		PlayerPrefs.SetInt("statPoints", tempInt);

		UpdateStats();
	}

	void UpdateStats(){		//Make all the text things show the right info
		statPointsText.text = "UPGRADE POINTS: " + PlayerPrefs.GetInt("statPoints");
		healthText.text = "CURRENT: " + PlayerPrefs.GetFloat("playerHealth") + "\n\nNEXT: " + (PlayerPrefs.GetFloat("playerHealth") + healthUp);
		damageText.text = "CURRENT: " + PlayerPrefs.GetFloat("playerDamage") + "\n\nNEXT: " + (PlayerPrefs.GetFloat("playerDamage") + damageUp);

		laserCurText.text = "DMG: " + PlayerPrefs.GetFloat("playerLaserDamage") + "\n\nStats";
		laserNextText.text = "NEW DMG: " + (PlayerPrefs.GetFloat("playerLaserDamage") + laserDamageUp) + "\n\nStats";

		shotgunCurText.text = "DMG: " + PlayerPrefs.GetFloat("playerShotgunDamage") + "\n\nStats";
		shotgunNextText.text = "NEW DMG: " + (PlayerPrefs.GetFloat("playerShotgunDamage") + shotgunDamageUp) + "\n\nStats";

		rocketCurText.text = "DMG: " + PlayerPrefs.GetFloat("playerRocketDamage") + "\n\nStats";
		rocketNextText.text = "NEW DMG: " + (PlayerPrefs.GetFloat("playerRocketDamage") + rocketDamageUp) + "\n\nStats";
	}
}
