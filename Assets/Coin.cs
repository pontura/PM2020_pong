using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Game game;

    private void OnTriggerEnter(Collider other)
    {
        float direction = other.gameObject.GetComponent<Ball>().direction_x;        

        if (direction > 0)
            game.Win(2, 1);
        else
            game.Win(1, 1);

        other.gameObject.GetComponent<Ball>().direction_x *= -1;
    }
}
