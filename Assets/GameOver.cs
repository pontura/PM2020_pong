using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text field;
    public GameObject win_player1_image;
    public GameObject win_player2_image;

    void Start()
    {
        field.text = "Gano el player: " + Data.player_win_ID;
        if (Data.player_win_ID == 1)
        {
            win_player1_image.SetActive(true);
            win_player2_image.SetActive(false);
        } else
        {
            win_player1_image.SetActive(false);
            win_player2_image.SetActive(true);
        }
    }
    
    public void BackToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
