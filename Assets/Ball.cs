using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5;
    public float smooth = 1;
    public float direction_x = 1f;
    float direction_y = 1f;

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
    private void Reset()
    {
        int rand = Random.Range(0, 100);
        if (rand > 50)
            direction_x = 1;
        else
            direction_x = -1;
        rand = Random.Range(0, 100);
        if (rand > 50)
            direction_y = 1;
        else
            direction_y = -1;

        _x = _y = 0;
        transform.position = Vector3.zero;
    }
    private void ChangeXDirection(int direction)
    {
        //cuando direction = 1 tengo que chequear sobre la posicion en y del player 1
        //cuando direction = -1 tengo que chequear sobre la posicion en y del player 2
        _x = game.sizes.x * direction;
        direction_x *= -1;

        if (direction==1)
        {
            bool hitted = CheckCollisionTo(player1);
            if (hitted == false)
            {
                Reset();
                game.Win(2, 1);
            }
        } else
        {
            bool hitted = CheckCollisionTo(player2);
            if (!hitted)
            {
                Reset();
                game.Win(1, 1);
            }
        }
        
    }
    private bool CheckCollisionTo(Player player)
    {
        float mid_height = (player.transform.localScale.y / 2);     // 2

        float center = player.transform.position.y;                 // 5
        float max_top = center + mid_height;                        // 7       
        float max_bottom = center - mid_height;                     // 3

        if (
            ( _y < max_top ) 
            && 
            ( _y > max_bottom )
            )
        {
            direction_y += (_y - center) * smooth;
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
