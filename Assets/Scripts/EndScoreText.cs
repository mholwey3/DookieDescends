using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    int points;

    void Start()
    {
        
    }

    void SaveHighscore()
    {
        if (points > PlayerPrefs.GetInt("Highscore1"))
            PlayerPrefs.SetInt("Highscore1", points);
        else if (points > PlayerPrefs.GetInt("Highscore2"))
            PlayerPrefs.SetInt("Highscore2", points);
        else if (points > PlayerPrefs.GetInt("Highscore3"))
            PlayerPrefs.SetInt("Highscore3", points);
        else if (points > PlayerPrefs.GetInt("Highscore4"))
            PlayerPrefs.SetInt("Highscore4", points);
        else if (points > PlayerPrefs.GetInt("Highscore5"))
            PlayerPrefs.SetInt("Highscore5", points);
    }
}
