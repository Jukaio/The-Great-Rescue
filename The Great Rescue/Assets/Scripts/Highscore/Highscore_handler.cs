using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore_handler : MonoBehaviour
{
	public GameObject inputFieldObjects;
	public GameObject highScoreBoard;

	public Text highscoreBox;
	public Text inputField;

	string playerName;
	bool buttonClicked = false;
	int score;

    public bool fromStartMenu = false;

    void Start()
    {
        
		highScoreBoard.SetActive(false);

		inputFieldObjects.SetActive(true);
		ViewScores();
    }

    void ViewScores()
    {
		highscoreBox.text = "";
		for (int i = 0; i < 10; i++)
		{
			highscoreBox.text += (i + 1).ToString() + ". - " + PlayerPrefs.GetString("highScoreName" + i.ToString()) + " - " + PlayerPrefs.GetInt("highScore" + i.ToString()) + "\n";
		}

		//highscoreBox.text =
		//	  "1. - " + PlayerPrefs.GetString("highScoreName0") + " - " + PlayerPrefs.GetInt("highScore0") + "\n"
		//	+ "2. - " + PlayerPrefs.GetString("highScoreName1") + " - " + PlayerPrefs.GetInt("highScore1") + "\n"
		//	+ "3. - " + PlayerPrefs.GetString("highScoreName2") + " - " + PlayerPrefs.GetInt("highScore2") + "\n"
		//	+ "4. - " + PlayerPrefs.GetString("highScoreName3") + " - " + PlayerPrefs.GetInt("highScore3") + "\n"
		//	+ "5. - " + PlayerPrefs.GetString("highScoreName4") + " - " + PlayerPrefs.GetInt("highScore4") + "\n"
		//	+ "6. - " + PlayerPrefs.GetString("highScoreName5") + " - " + PlayerPrefs.GetInt("highScore5") + "\n"
		//	+ "7. - " + PlayerPrefs.GetString("highScoreName6") + " - " + PlayerPrefs.GetInt("highScore6") + "\n"
		//	+ "8. - " + PlayerPrefs.GetString("highScoreName7") + " - " + PlayerPrefs.GetInt("highScore7") + "\n"
		//	+ "9. - " + PlayerPrefs.GetString("highScoreName8") + " - " + PlayerPrefs.GetInt("highScore8") + "\n"
		//	+ "10. - " + PlayerPrefs.GetString("highScoreName9") + " - " + PlayerPrefs.GetInt("highScore9");
	}

	void OnGUI()
	{
		if (!buttonClicked)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 200 / 2, Screen.height / 2 + 120, 200, 60), "Submit"))
			{
				highScoreBoard.SetActive(true);
				inputFieldObjects.SetActive(false);
				buttonClicked = true;
				playerName = inputField.text;
				SortScores(HigScore.highscore, playerName);
				ViewScores();
			}
		}
		else
		{
			//if(GUI.Button)
		}
	}

	void SortScores(int newScore, string playerName)
	{
		int index = -1;
		for(int i = 9; i >= 0; i--)
		{
			if(PlayerPrefs.GetInt("highScore" + i.ToString()) < newScore)	// finds index for score from bottom
			{
				index = i;
			}
		}

		if (index == -1) return;	// if didn't find index


		for(int i = 9; i > index; i--)		
		{
			PlayerPrefs.SetString("highScoreName" + i.ToString(), PlayerPrefs.GetString("highScoreName" + (i - 1).ToString()));	// sorts the names
			PlayerPrefs.SetInt("highScore" + i.ToString(), PlayerPrefs.GetInt("highScore" + (i - 1).ToString()));               // sorts the scores
		}
		PlayerPrefs.SetString("highScoreName" + index.ToString(), playerName);
		PlayerPrefs.SetInt("highScore" + index.ToString(), newScore);
	}
}
