using UnityEngine;
using System.Collections;

public class A_Endgame_Buttons : MonoBehaviour {
	public ButtonTypes buttonType;

	public enum ButtonTypes{
		Start,
		Menu,
		Upgrades,
		Highscores,
		Achievements,
		Reset
	}

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.white;
	}

	void OnMouseDown(){
		switch(buttonType){
		case ButtonTypes.Start:
			Application.LoadLevel("Default");	//Default is the game level because reasons
			break;

		case ButtonTypes.Menu:
			Application.LoadLevel("Main Menu");
			break;

		case ButtonTypes.Upgrades:
			Application.LoadLevel("Upgrades");
			break;

		case ButtonTypes.Highscores:
			print ("Not a thing yet.");
			break;

		case ButtonTypes.Achievements:
			print ("Not a thing yet.");
			break;

		case ButtonTypes.Reset:
			A_MainMenu menuScript = GameObject.Find("A_Cogitator").GetComponent<A_MainMenu>();
			TextMesh resetText = GameObject.Find("T_Reset_Text").GetComponent<TextMesh>();
			menuScript.ResetStats();
			resetText.renderer.enabled = true;
			break;

		default:
			break;
		}
	}
}
