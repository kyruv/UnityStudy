using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

public class BackendLogger : MonoBehaviour
{
    public static BackendLogger instance;

    // When you host, change this to your actual URL
    private const string BACKEND_ADDRESS_BASE = "http://127.0.0.1:8000/unity_post_";

    // A UUID to represent unique user session
    private string user_id;

    void Awake()
    {
        user_id = System.Guid.NewGuid().ToString();
        if (instance == null)
        {
            instance = this;
        }
    }

    public void MarkGameEnd(float game_score, float game_time)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", user_id);
        form.AddField("game_score", "" + game_score);
        form.AddField("game_time", "" + game_time);


        UnityWebRequest www = UnityWebRequest.Post(BACKEND_ADDRESS_BASE + "game_end", form);
        StartCoroutine(Post(www));
    }

    public void MarkS1End(string q1_ans, int q2_ans)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", user_id);
        form.AddField("s1_q1", q1_ans);
        form.AddField("s1_q2", "" + q2_ans);


        UnityWebRequest www = UnityWebRequest.Post(BACKEND_ADDRESS_BASE + "s1_end", form);
        StartCoroutine(Post(www));
    }

    public void MarkS2End(int q1_ans)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", user_id);
        form.AddField("s2_q1", "" + q1_ans);


        UnityWebRequest www = UnityWebRequest.Post(BACKEND_ADDRESS_BASE + "s2_end", form);
        StartCoroutine(Post(www));
    }

    IEnumerator Post(UnityWebRequest www)
    {
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Post Successful");
        }
    }
}