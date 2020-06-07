using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    private float timer;

    void Update()
    {
        timer += Time.time;
    }

    public float GetTimer()
    {
        return timer;
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}
