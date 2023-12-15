using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeData : MonoBehaviour
{
    // Show how Unity would call BackendLogger to record some data

    public void RecordGameEndData()
    {
        float game_score = Random.Range(0f, 100f);
        float game_time = Random.Range(10f, 45f);

        BackendLogger.instance.MarkGameEnd(game_score, game_time);
    }

    public void RecordS1EndData()
    {
        string q1 = "rand_data_" + Random.Range(0, 100);
        int q2 = Random.Range(-5, 6);

        BackendLogger.instance.MarkS1End(q1, q2);
    }

    public void RecordS2EndData()
    {
        int q1 = Random.Range(-50, 51);

        BackendLogger.instance.MarkS2End(q1);
    }
}
