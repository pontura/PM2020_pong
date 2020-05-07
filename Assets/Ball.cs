using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5;
    public float smooth = 1;
    public float direction_x = 1f;
    public float direction_y = 1f;

    public Player player1;
    public Player player2;

    public Game game;
    float _x;
    float _y;
    public AudioSource audioSource;
  
    void Update()
    {
        _x = transform.position.x + speed * direction_x * Time.deltaTime;
        _y = transform.position.y + speed * direction_y * Time.deltaTime;

        if (_x >= game.sizes.x)
        {
            game.Win(2, 10);
            Reset();
        }
        else if (_x <= -game.sizes.x)
        {
            game.Win(1, 10);
            Reset();
        }

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
        PowerupOff();
    }
   
    private void ChangeYDirection(int direction)
    {
        audioSource.Play();
        _y = game.sizes.y * direction;
        direction_y *= -1;
    }
    public void Powerup()
    {
        speed = 10;
        CancelInvoke();
        Invoke("PowerupOff", 5);       //PowerupOff(); lo llama despues de 5 segundos:
    }
    void PowerupOff()
    {
        speed = 5;
    }
}
