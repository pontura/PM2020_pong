﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Vector2 sizes = new Vector2(8, 5);

    public int score_player_1;
    public int score_player_2;
    public Text field_score_p1;
    public Text field_score_p2;

    public Player.types playerActiveType;

    void Start()
    {

    }
    public void Win(int playerID, int score)
    {
        if (playerID == 1)
        {
            score_player_1 += score;
            field_score_p1.text = score_player_1.ToString();
        }
        else
        {
            score_player_2 += score;
            field_score_p2.text = score_player_2.ToString();
        }

        if (score_player_1 > 100)
        {
            Data.player_win_ID = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        else  if (score_player_2 > 100)
        {
            Data.player_win_ID = 2;
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
