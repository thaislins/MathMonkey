using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController {

    public void AppendScore()
    {
        int score1 = PlayerPrefs.GetInt("score1");
        int score2 = PlayerPrefs.GetInt("score2");

        string player1 = PlayerPrefs.GetString("player1");
        string player2 = PlayerPrefs.GetString("player2");

        if (PlayerScore.playerScore > score1)
        {
            PlayerPrefs.SetInt("score2", score1);
            PlayerPrefs.SetInt("score3", score2);
            PlayerPrefs.SetString("player2", player1);
            PlayerPrefs.SetString("player3", player2);

            PlayerPrefs.SetInt("score1", PlayerScore.playerScore);
            PlayerPrefs.SetString("player1", PlayerPrefs.GetString("playerName"));

        }
        else if (PlayerScore.playerScore > score2)
        {
            PlayerPrefs.SetInt("score3", score2);
            PlayerPrefs.SetInt("score2", PlayerScore.playerScore);
            PlayerPrefs.SetString("player3", player2);
            PlayerPrefs.SetString("player2", PlayerPrefs.GetString("playerName"));
        }
        else if (PlayerScore.playerScore > PlayerPrefs.GetInt("score3"))
        {
            PlayerPrefs.SetInt("score3", PlayerScore.playerScore);
            PlayerPrefs.SetString("player3", PlayerPrefs.GetString("playerName"));
        }

        Debug.Log(PlayerPrefs.GetInt("score1"));
        Debug.Log(PlayerPrefs.GetInt("score3"));
        Debug.Log(PlayerPrefs.GetString("player1"));
        Debug.Log(PlayerPrefs.GetString("player2"));
    }
}
