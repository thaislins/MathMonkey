using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public GameObject playerUI;
    public GameObject pauseUI;
    public GameObject instructionsUI;

	// Use this for initialization
	void Start () {
        instructionsUI.SetActive(true);
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Close() {
        instructionsUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PauseGame() {
        PlayerLife.mainAudio.Pause();
        Time.timeScale = 0;
        playerUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void ResumeGame() {
        PlayerLife.mainAudio.Play();
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
        playerUI.SetActive(true);
    }

    public void RestartGame() {
        Time.timeScale = 1.0f;
        PlayerScore.playerScore = 0;
        PlayerLife.lives = 0;
        PlayerLife.countLives = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu() {
        Time.timeScale = 1.0f;
        PlayerScore.playerScore = 0;
        PlayerLife.lives = 0;
        PlayerLife.countLives = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
