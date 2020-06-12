using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
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
