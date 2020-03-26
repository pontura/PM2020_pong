using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 0.1f;
    float direction_x = 1;
    float direction_y = 1;

    public Game game;

    void Update()
    {
        float _x = transform.position.x + speed * direction_x;
        float _y = transform.position.y + speed * direction_y;

        if (_x >= game.sizes.x)
        {
            _x = game.sizes.x;
            direction_x = direction_x * -1;
        }else if(_x <= -game.sizes.x)
        {
            _x = -game.sizes.x;
            direction_x = direction_x * -1;
        }
        if (_y >= game.sizes.y)
        {
            _y = game.sizes.y;
            direction_y = direction_y * -1;
        } else if (_y <= -game.sizes.y)
        {
            _y = -game.sizes.y;
            direction_y = direction_y * -1;
        }

        transform.position = new Vector2(_x, _y);
    }
}
