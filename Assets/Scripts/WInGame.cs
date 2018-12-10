using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {

    public GameObject character;
    PlayerController playerController;
    public GameObject playerUI;
    public GameObject winUI;
    public AudioClip winSound;
    public Text scoreboard1;
    public Text scoreboard2;
    public Text scoreboard3;
    public GameObject scoreBoardUI;
    public GameObject winGameUI;
    ScoreController scoreController;
    // Use this for initialization
	void Start () {
        playerController = character.GetComponent<PlayerController>();
        scoreController = new ScoreController();
	}

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            StartCoroutine("WalkAway");
        }
    }

    void SetScore() {
        scoreboard1.text = PlayerPrefs.GetString("player1") + ": " + PlayerPrefs.GetInt("score1");
        scoreboard2.text = PlayerPrefs.GetString("player2") + ": " + PlayerPrefs.GetInt("score2");
        scoreboard3.text = PlayerPrefs.GetString("player3") + ": " + PlayerPrefs.GetInt("score3");
    }

    IEnumerator WalkAway() {
        playerController.myAnim.SetTrigger("Win");
        yield return new WaitForSeconds(1.5f);
        character.gameObject.SetActive(false);
        playerUI.SetActive(false);
        winUI.SetActive(true);
        PlayerLife.mainAudio.Stop();
        AudioSource.PlayClipAtPoint(winSound, transform.position, 1f);
        scoreController.AppendScore();
        SetScore();
    }

    public void ShowScoreBoard() {
        winGameUI.SetActive(false);
        scoreBoardUI.SetActive(true);
    }

    public void BackToWinGameUI() {
        scoreBoardUI.SetActive(false);
        winGameUI.SetActive(true);
    }

    public void GoToNextLevel() {
        PlayerLife.mainAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
