using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdPlayer : MonoBehaviour
{

    FlappyBirdGameManager gameManager;
    public int number_of_clicks = 0;

    public float velocity = 2.4f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("ObstacleSpawner").GetComponent<FlappyBirdGameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }

    void Update()
    {
        if (gameManager.can_spawn && ((gameManager.condition_mouse && Input.GetMouseButtonDown(0)) || (!gameManager.condition_mouse && Input.GetKeyDown(KeyCode.Space))))
        {
            rb.velocity = Vector2.up * velocity;
            number_of_clicks++;
        }
    }
}

