using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

public class BackendLogger : MonoBehaviour
{
    public static BackendLogger instance;

#if UNITY_EDITOR
    private const string BACKEND_ADDRESS_BASE = "http://127.0.0.1:8000/unity_post_";
#else
    private const string BACKEND_ADDRESS_BASE = "unity_post_";
#endif

    // A UUID to represent unique user session
    private string user_id;

    void Awake()
    {
        user_id = GetOrCreateUserId();
        if (instance == null)
        {
            instance = this;
        }
#if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = false;
#endif
        Application.ExternalCall("start_survey_one", "hello from unity!");
    }

    private string GetOrCreateUserId()
    {
        string userId = PlayerPrefs.GetString("UserId");

        // If no player ID found, generate a new one
        if (string.IsNullOrEmpty(userId))
        {
            userId = System.Guid.NewGuid().ToString();
            PlayerPrefs.SetString("UserId", userId);
            PlayerPrefs.Save();
        }

        return userId;
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
