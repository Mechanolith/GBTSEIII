using UnityEngine;
using System.Collections;

public class A_Endgame_Logic : MonoBehaviour {
	public int pointsPerLvl;
	int upgPoints;
	float curXP, xpGained, levelXP, lastScore;
	TextMesh pointsText, xpText, xpBarText, levelUpText, statPointsText;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat("xpToLevel", 100); //PURELY FOR TESTING. REMOVE ONCE MENU IS INTEGRATED AND INITIAL SETUP IS DONE.
		lastScore = PlayerPrefs.GetFloat("currentScore");
		curXP = PlayerPrefs.GetFloat("currentXP");
		levelXP = PlayerPrefs.GetFloat("xpToLevel");
		upgPoints = PlayerPrefs.GetInt("statPoints");

		pointsText = GameObject.Find("T_Points_Number").gameObject.GetComponent<TextMesh>();
		xpText = GameObject.Find("T_XP_Text").gameObject.GetComponent<TextMesh>();
		xpBarText = GameObject.Find("T_XPBar_Text").gameObject.GetComponent<TextMesh>();
		levelUpText = GameObject.Find("T_LevelUp_Text").gameObject.GetComponent<TextMesh>();
		statPointsText = GameObject.Find("T_StatPoints_Text").gameObject.GetComponent<TextMesh>();

		xpGained = Mathf.Round(lastScore/10);

		pointsText.text = "" + lastScore;
		xpText.text = "+ " + xpGained + " XP";

		curXP += xpGained;
		PlayerPrefs.SetFloat("currentXP", curXP);
		xpBarText.text = "" + curXP + "/" + levelXP;

		if(curXP > levelXP){
			levelUpText.renderer.enabled = true;
			statPointsText.renderer.enabled = true;
			curXP -= levelXP;
			PlayerPrefs.SetFloat("currentXP", curXP);

			levelXP *= 1.5f;
			PlayerPrefs.SetFloat("xpToLevel", levelXP);

			upgPoints += pointsPerLvl;
			PlayerPrefs.SetInt("statPoints", upgPoints);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
