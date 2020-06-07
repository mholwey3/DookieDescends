using UnityEngine;
using System.Collections;

public class PointObjectValue : MonoBehaviour
{
    public int points;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
