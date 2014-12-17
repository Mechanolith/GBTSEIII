using UnityEngine;
using System.Collections;

public class A_Upgrade_Buttons : MonoBehaviour {
	public A_Upgrade_God.UpgradeTypes upgradeType;
	public A_Upgrade_God upgradeGod;
	float tempValue;

	// Use this for initialization
	void Start () {
		upgradeGod = GameObject.Find("A_Cogitator").GetComponent<A_Upgrade_God>();
		renderer.material.color = Color.white;
	}
	
	void OnMouseOver(){
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.white;
	}

	void OnMouseDown(){
		if(PlayerPrefs.GetInt("statPoints") > 0){	//If they can afford an upgrade
			switch(upgradeType){
				case A_Upgrade_God.UpgradeTypes.Health:
					upgradeGod.OnUpgrade(A_Upgrade_God.UpgradeTypes.Health);
					break;
					
				case A_Upgrade_God.UpgradeTypes.Damage:
					upgradeGod.OnUpgrade(A_Upgrade_God.UpgradeTypes.Damage);
					break;
					
				case A_Upgrade_God.UpgradeTypes.Laser:
					upgradeGod.OnUpgrade(A_Upgrade_God.UpgradeTypes.Laser);
					break;
					
				case A_Upgrade_God.UpgradeTypes.Shotgun:
					upgradeGod.OnUpgrade(A_Upgrade_God.UpgradeTypes.Shotgun);
					break;
					
				case A_Upgrade_God.UpgradeTypes.Rocket:
					upgradeGod.OnUpgrade(A_Upgrade_God.UpgradeTypes.Rocket);
					break;
					
				default:
					break;
			}
		}
	}
}
