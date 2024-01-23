using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeData : MonoBehaviour
{
    public void RecordGameEndData()
    {
        float game_score = Random.Range(0f, 100f);
        float game_time = Random.Range(10f, 45f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("game_score", "" + game_score);
        data.Add("game_time", "" + game_time);
        BackendLogger.instance.LogToBackend("game_end", data);
    }
}
