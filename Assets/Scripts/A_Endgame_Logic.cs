using UnityEngine;
using System.Collections;

public class A_Endgame_Logic : MonoBehaviour {
	public int pointsPerLvl;
	int upgPoints;
	float curXP, xpGained, levelXP, lastScore;
	TextMesh pointsText, xpText, xpBarText, levelUpText, statPointsText;
	
	void Start () {		//Set up all the things
		lastScore = PlayerPrefs.GetFloat("currentScore");
		curXP = PlayerPrefs.GetFloat("currentXP");
		levelXP = PlayerPrefs.GetFloat("xpToLevel");
		upgPoints = PlayerPrefs.GetInt("statPoints");

		pointsText = GameObject.Find("T_Points_Number").gameObject.GetComponent<TextMesh>();
		xpText = GameObject.Find("T_XP_Text").gameObject.GetComponent<TextMesh>();
		xpBarText = GameObject.Find("T_XPBar_Text").gameObject.GetComponent<TextMesh>();
		levelUpText = GameObject.Find("T_LevelUp_Text").gameObject.GetComponent<TextMesh>();
		statPointsText = GameObject.Find("T_StatPoints_Text").gameObject.GetComponent<TextMesh>();

		//Work out XP
		xpGained = Mathf.Round(lastScore/10);	//score/10 is an arbitrary calculation, change as necessary for balance

		//Set up the text
		pointsText.text = "" + lastScore;
		xpText.text = "+ " + xpGained + " XP";

		curXP += xpGained;
		PlayerPrefs.SetFloat("currentXP", curXP);
		xpBarText.text = "" + curXP + "/" + levelXP;

		//Check for levelup
		if(curXP > levelXP){
			levelUpText.renderer.enabled = true;
			statPointsText.renderer.enabled = true;
			curXP -= levelXP;	//Bring current XP back down
			PlayerPrefs.SetFloat("currentXP", curXP);

			levelXP *= 1.5f;	//This determines how much XP will be needed for the next levelup
			PlayerPrefs.SetFloat("xpToLevel", levelXP);

			upgPoints += pointsPerLvl;		//Give 'em a point!
			PlayerPrefs.SetInt("statPoints", upgPoints);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
