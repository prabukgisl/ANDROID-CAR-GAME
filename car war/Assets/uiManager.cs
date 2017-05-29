using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {
	public Button[] buttons;
	public Text scoreText;
	int score;
	bool gameover;

	// Use this for initialization
	void Start () {
		gameover = false;
		score = 0;
		InvokeRepeating ("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "score:" + score;
	
	}
	void scoreUpdate(){
		if (gameover==false) {
			score += 1;
		}
	}
	public void gameOverActivated(){
		gameover = true;
		foreach (Button button in buttons) {

			button.gameObject.SetActive(true);
		}
	}

    public void play()
   {
		Application.LoadLevel ("level 1");
	}

	public void pause(){

		if (Time.timeScale == 1) {
			Time.timeScale = 0;

		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}
	public void Menu(){
		Application.LoadLevel("menuScript");
	}
	public void Exit(){
		Application.Quit();
	}
}
