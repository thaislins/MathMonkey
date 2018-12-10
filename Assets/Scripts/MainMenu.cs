using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenuObj;
	public GameObject optionsMenuObj;
	public GameObject instructionsMenuObj;
    public GameObject nameCanvasUI;
    public GameObject availableLevels;
    public InputField namePlayerInput;

    private void Start() {
        if (!PlayerPrefs.HasKey("score1")) {
            PlayerPrefs.SetInt("score1", 0);
            PlayerPrefs.SetInt("score2", 0);
            PlayerPrefs.SetInt("score3", 0);
        } 

        if(!PlayerPrefs.HasKey("player1")) {
            PlayerPrefs.SetString("player1", "Monkey");
            PlayerPrefs.SetString("player2", "Monkey");
            PlayerPrefs.SetString("player3", "Monkey");
        }
    }

    public void PlayGame() {
        PlayerPrefs.SetString("playerName", namePlayerInput.text);
        Debug.Log(PlayerPrefs.GetString("playerName"));
        SceneManager.LoadScene("Level 1");
        PlayerScore.playerScore = 0;
    }

    public void PressPlay() {
        if (PlayerPrefs.HasKey("playerName") && PlayerPrefs.GetString("playerName") != "") {
            ShowAvailableLevels();
        } else {
            EnterName();
        }
    }

    public void ShowAvailableLevels() {
        Debug.Log(PlayerPrefs.GetString("playerName"));
        instructionsMenuObj.SetActive(false);
        mainMenuObj.SetActive(false);
        nameCanvasUI.SetActive(false);
        availableLevels.SetActive(true);
    }

    public void GoToLevel1() {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToLevel2() {
        SceneManager.LoadScene("Level 2");
    }

    public void EnterName() {
        availableLevels.SetActive(false);
        instructionsMenuObj.SetActive(false);
        mainMenuObj.SetActive(false);
        nameCanvasUI.SetActive(true);
    }

    public void QuitGame() {
        PlayerPrefs.SetString("playerName", "");
        Application.Quit();
		Debug.Log("Quit");
	}

	public void OptionsMenu() {
		mainMenuObj.SetActive(false);
		optionsMenuObj.SetActive(true);
	}

	public void InstructionsMenu() {
		mainMenuObj.SetActive(false);
		instructionsMenuObj.SetActive(true);
	}

	public void Back() {
		optionsMenuObj.SetActive(false);
		instructionsMenuObj.SetActive(false);
		mainMenuObj.SetActive(true);
	}
}
