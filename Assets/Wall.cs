using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Game game;
    public types type;
    public enum types
    {
        TOP,
        BOTTOM,
        LEFT,
        RIGHT
    }
    float offset = 0.7f;

    void Update()
    {
        if(type == types.TOP)
            transform.position = new Vector3(transform.position.x, game.sizes.y + offset);
        else if (type == types.BOTTOM)
            transform.position = new Vector3(transform.position.x, -game.sizes.y - offset);
        else if (type == types.LEFT)
            transform.position = new Vector3( -game.sizes.x - offset, transform.position.y);
        else if (type == types.RIGHT)
            transform.position = new Vector3(game.sizes.x + offset, transform.position.y);
    }
}
