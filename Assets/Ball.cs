using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 0.1f;
    float direction_x = 1;
    float direction_y = 1;

    public Player player1;
    public Player player2;

    public Game game;
    float _x;
    float _y;

    void Update()
    {
        _x = transform.position.x + speed * direction_x * Time.deltaTime;
        _y = transform.position.y + speed * direction_y * Time.deltaTime;

        if (_x >= game.sizes.x)
            ChangeXDirection(1);
        else if(_x <= -game.sizes.x)
            ChangeXDirection(-1);

        if (_y >= game.sizes.y)
            ChangeYDirection(1);
        else if (_y <= -game.sizes.y)
            ChangeYDirection(-1);

        transform.position = new Vector2(_x, _y);
    }
    private void ChangeXDirection(int direction)
    {
        //cuando direction = 1 tengo que chequear sobre la posicion en y del player 1
        //cuando direction = -1 tengo que chequear sobre la posicion en y del player 2
        if (direction==1)
        {
            bool hitted = CheckCollisionTo(player1);
            if (hitted)
                print("sigue");
            else
                print("game over");
        } else
        {
            bool hitted = CheckCollisionTo(player2);
            if (hitted)
                print("sigue");
            else
                print("game over");
        }
        _x = game.sizes.x * direction;
        direction_x *= -1;
    }

    private bool CheckCollisionTo(Player player)
    {
        if (
            (_y < player.transform.position.y + (player.transform.localScale.y / 2)) 
            && 
            (_y > player.transform.position.y - (player.transform.localScale.y / 2))
            )
        {
            return true;
        }
        else
            return false;
    }
    private void ChangeYDirection(int direction)
    {
        _y = game.sizes.y * direction;
        direction_y *= -1;
    }
}
