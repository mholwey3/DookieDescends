using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreScript : MonoBehaviour
{
    public Text highscore1;
    public Text highscore2;
    public Text highscore3;
    public Text highscore4;
    public Text highscore5;

    public Text name1;
    public Text name2;
    public Text name3;
    public Text name4;
    public Text name5;

    void Start()
    {
        if (PlayerPrefs.GetString("Name1").Equals(""))
            name1.text = "1. High score 1";
        else
            name1.text = "1. " + PlayerPrefs.GetString("Name1");

        if (PlayerPrefs.GetString("Name2").Equals(""))
            name2.text = "2. High score 2";
        else
            name2.text = "2. " + PlayerPrefs.GetString("Name2");

        if (PlayerPrefs.GetString("Name3").Equals(""))
            name3.text = "3. High score 3";
        else
            name3.text = "3. " + PlayerPrefs.GetString("Name3");

        if (PlayerPrefs.GetString("Name4").Equals(""))
            name4.text = "4. High score 4";
        else
            name4.text = "4. " + PlayerPrefs.GetString("Name4");

        if (PlayerPrefs.GetString("Name5").Equals(""))
            name5.text = "5. High score 5";
        else
            name5.text = "5. " + PlayerPrefs.GetString("Name5");

        highscore1.text = string.Format("{0:#,###0}", PlayerPrefs.GetInt("Highscore1"));
        highscore2.text = string.Format("{0:#,###0}", PlayerPrefs.GetInt("Highscore2"));
        highscore3.text = string.Format("{0:#,###0}", PlayerPrefs.GetInt("Highscore3"));
        highscore4.text = string.Format("{0:#,###0}", PlayerPrefs.GetInt("Highscore4"));
        highscore5.text = string.Format("{0:#,###0}", PlayerPrefs.GetInt("Highscore5"));
    }

    public void GoToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
