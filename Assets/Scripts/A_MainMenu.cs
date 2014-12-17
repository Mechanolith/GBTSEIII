using UnityEngine;
using System.Collections;

public class A_MainMenu : MonoBehaviour {
	public float defaultHealth, defaultDamage, defaultLaserDamage, defaultShotgunDamage, defaultRocketDamage, defaultXPToLevel;
	
	void Start () {
		if (PlayerPrefs.GetInt("firstLaunch") == 0){	//See if it's their first time
			ResetStats();								//Set defaults
			PlayerPrefs.SetInt("firstLaunch", 1);		//Make it not the first time
		}
	}

	public void ResetStats(){	//Set everything to defaults
		PlayerPrefs.SetFloat("playerHealth", defaultHealth);
		PlayerPrefs.SetFloat("playerDamage", defaultDamage);
		PlayerPrefs.SetFloat("playerLaserDamage", defaultLaserDamage);
		PlayerPrefs.SetFloat("playerShotgunDamage", defaultShotgunDamage);
		PlayerPrefs.SetFloat("playerRocketDamage", defaultRocketDamage);
		PlayerPrefs.SetFloat("currentXP", 0);
		PlayerPrefs.SetFloat("xpToLevel", defaultXPToLevel);
		PlayerPrefs.SetInt("statPoints", 0);
	}
}
