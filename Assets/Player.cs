using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float angleDistortion = 1;
    public float speed = 0.8f;
    public Game game;
    public types type;
    public enum types
    {
        PLAYER1,
        PLAYER2
    }
    float offset = 0.7f;
    public Animation anim;

    void Update()
    {
        float player_y = transform.position.y;
        if (type == types.PLAYER1)
        {
            if (Input.GetKey(KeyCode.W) && player_y <= game.sizes.y - offset)
            {
                Move(1);
            }
            if (Input.GetKey(KeyCode.S) && player_y >= -game.sizes.y + offset)
            {
                Move(-1);
            }
        }
        if (type == types.PLAYER2)
        {
            if (Input.GetKey(KeyCode.UpArrow) && player_y <= game.sizes.y - offset)
            {
                Move(1);
            }
            if (Input.GetKey(KeyCode.DownArrow) && player_y >= -game.sizes.y + offset)
            {
                Move(-1);
            }
        }
    }
    void Move(int direction)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball == null)
            return;

        //choco con la pelota:
        game.playerActiveType = type;
        anim.Play();

        float center = transform.position.y; 
        ball.direction_y += (ball.transform.position.y - center) * angleDistortion;
        other.gameObject.GetComponent<Ball>().direction_x *= -1;
    }


}