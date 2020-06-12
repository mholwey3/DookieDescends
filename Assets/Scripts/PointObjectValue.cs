using UnityEngine;

public class PointObjectValue : MonoBehaviour
{
    public int points;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        points = 0;
    }
}
