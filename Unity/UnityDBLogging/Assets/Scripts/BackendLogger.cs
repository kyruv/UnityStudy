using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

public class BackendLogger : MonoBehaviour
{
    public static BackendLogger instance;

#if UNITY_EDITOR
    private const string BACKEND_ADDRESS_BASE = "http://127.0.0.1:8000/unity_flappy_bird_";
#else
    private const string BACKEND_ADDRESS_BASE = "unity_flappy_bird_";
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

    // Call the backend to log some data to the database.
    public void LogToBackend(string address, Dictionary<string, string> data)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", user_id);
        foreach (KeyValuePair<string, string> entry in data)
        {
            form.AddField(entry.Key, entry.Value);
        }
        UnityWebRequest www = UnityWebRequest.Post(BACKEND_ADDRESS_BASE + address, form);
        StartCoroutine(Post(www));
    }

    // Calls a JS function that you must define. Often used to bring up
    // JS surveys mid-game.
    //
    // The JS function should be called function_name and accept at least
    // one parameter which will be the user_id. It can accept additional
    // string arguments if desired.
    public void CallJSFunction(string function_name, params string[] values)
    {
#pragma warning disable
        Application.ExternalCall(function_name, user_id, values);
#pragma warning restore

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

    // Called from JavaScript during surveys to pause unity.
    public void PauseUnity()
    {
        Time.timeScale = 0;
    }

    // Called from JavaScript after surveys to unpause unity.
    public void UnpauseUnity()
    {
        Time.timeScale = 1;
    }
}
