using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Vector2 sizes = new Vector2(8, 5);

    public int score_player_1;
    public int score_player_2;

    void Start()
    {
        
    }
    public void Win(int playerID, int score)
    {
        if (playerID == 1)
            score_player_1 += score;
        else
            score_player_2 += score;

        if (score_player_1 > 10 || score_player_2 > 10)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");

    }
}
