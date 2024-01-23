using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlappyBirdGameManager : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = 0;
    public GameObject obstacle;
    public float height;
    public FlappyBirdPlayer player;
    public TextMeshProUGUI text;

    private int attempt_number = 0;
    private int columns_spawned = 0;

    private bool paused = true;
    public bool can_spawn = true;

    public bool condition_mouse = true;

    void Start()
    {
        paused = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;

        // Start by telling JavaScript to load the pre_game_survey
        BackendLogger.instance.CallJSFunction("pre_game_survey");
    }

    void Update()
    {
        if (paused)
        {
            if ((condition_mouse && Input.GetMouseButtonDown(0)) || (!condition_mouse && Input.GetKeyDown(KeyCode.Space)))
            {
                paused = false;
                player.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            return;
        }

        if (time > queueTime && can_spawn)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            columns_spawned += 1;

            time = 0;
            Destroy(go, 10);
        }

        time += Time.deltaTime;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
        if (condition_mouse)
        {
            text.text = "Mouse Click Condition: " + (attempt_number + 1) + "/3";
        }
        else
        {
            text.text = "Space Bar Condition: " + (attempt_number - 2) + "/3";
        }

        paused = true;
        can_spawn = true;
        player.transform.position = new Vector3(0, -1, 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        GameObject[] pipes = GameObject.FindGameObjectsWithTag("pipe");
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }
    }

    public void GameOver()
    {
        text.text = "Game Over. Score: " + columns_spawned;
        // Game specific logic for setting up next try
        can_spawn = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("pipe");
        foreach (GameObject pipe in pipes)
        {
            pipe.GetComponent<FlappyBirdObstacle>().enabled = false;
        }


        // Log the data to the backend
        Dictionary<string, string> data = new Dictionary<string, string>
        {
            { "attempt_number", "" + attempt_number },
            { "columns_spanwed", "" + columns_spawned },
            { "num_clicks", "" + player.number_of_clicks }
        };
        BackendLogger.instance.LogToBackend("player_died", data);
        columns_spawned = 0;
        attempt_number += 1;
        player.number_of_clicks = 0;

        if (attempt_number == 3)
        {
            BackendLogger.instance.CallJSFunction("post_click_survey");
            condition_mouse = false;
        }
        else if (attempt_number == 6)
        {
            BackendLogger.instance.CallJSFunction("post_space_survey");
        }
        StartCoroutine(StartGame());
    }
}
