using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameScript : MonoBehaviour
{
    public AudioClip endClip;
    public AudioClip success;
    public AudioClip whoosh;
    public GameObject enterHighscorePanel;
    public Text scoreDisplayMain;
    public Text highscoreDisplayPopup;
    public Text enteredName;

    public RectTransform loadingPanel;

    float slideSpeed = 50f;
    int points;

    void Start()
    {
        AudioManager.instance.StopMusic();

        points = GameObject.FindGameObjectWithTag("PointObject").GetComponent<PointObjectValue>().points;
        //format these values
        scoreDisplayMain.text = "Score: " + string.Format("{0:#,###0}", points);
        highscoreDisplayPopup.text = string.Format("{0:#,###0}", points);

        if (points > PlayerPrefs.GetInt("Highscore5"))
        {
            enterHighscorePanel.SetActive(true);
            AudioManager.instance.PlaySingle(false, success);
        }
        else
            AudioManager.instance.PlaySingle(false, endClip);

        GameObject.FindGameObjectWithTag("PointObject").GetComponent<PointObjectValue>().points = 0;
    }

    public void EnterHighscore()
    {
        if (points > PlayerPrefs.GetInt("Highscore1"))
        {
            //push down lower scores ... make room for new high score
            PlayerPrefs.SetInt("Highscore5", PlayerPrefs.GetInt("Highscore4"));
            PlayerPrefs.SetInt("Highscore4", PlayerPrefs.GetInt("Highscore3"));
            PlayerPrefs.SetInt("Highscore3", PlayerPrefs.GetInt("Highscore2"));
            PlayerPrefs.SetInt("Highscore2", PlayerPrefs.GetInt("Highscore1"));

            PlayerPrefs.SetString("Name5", PlayerPrefs.GetString("Name4"));
            PlayerPrefs.SetString("Name4", PlayerPrefs.GetString("Name3"));
            PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));
            PlayerPrefs.SetString("Name2", PlayerPrefs.GetString("Name1"));

            PlayerPrefs.SetInt("Highscore1", points);
            PlayerPrefs.SetString("Name1", enteredName.text);
        }
        else if (points > PlayerPrefs.GetInt("Highscore2"))
        {
            //push down lower scores ... make room for new high score
            PlayerPrefs.SetInt("Highscore5", PlayerPrefs.GetInt("Highscore4"));
            PlayerPrefs.SetInt("Highscore4", PlayerPrefs.GetInt("Highscore3"));
            PlayerPrefs.SetInt("Highscore3", PlayerPrefs.GetInt("Highscore2"));

            PlayerPrefs.SetString("Name5", PlayerPrefs.GetString("Name4"));
            PlayerPrefs.SetString("Name4", PlayerPrefs.GetString("Name3"));
            PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));

            PlayerPrefs.SetInt("Highscore2", points);
            PlayerPrefs.SetString("Name2", enteredName.text);
        }
        else if (points > PlayerPrefs.GetInt("Highscore3"))
        {
            //push down lower scores ... make room for new high score
            PlayerPrefs.SetInt("Highscore5", PlayerPrefs.GetInt("Highscore4"));
            PlayerPrefs.SetInt("Highscore4", PlayerPrefs.GetInt("Highscore3"));

            PlayerPrefs.SetString("Name5", PlayerPrefs.GetString("Name4"));
            PlayerPrefs.SetString("Name4", PlayerPrefs.GetString("Name3"));

            PlayerPrefs.SetInt("Highscore3", points);
            PlayerPrefs.SetString("Name3", enteredName.text);
        }
        else if (points > PlayerPrefs.GetInt("Highscore4"))
        {
            //push down lower scores ... make room for new high score
            PlayerPrefs.SetInt("Highscore5", PlayerPrefs.GetInt("Highscore4"));

            PlayerPrefs.SetString("Name5", PlayerPrefs.GetString("Name4"));

            PlayerPrefs.SetInt("Highscore4", points);
            PlayerPrefs.SetString("Name4", enteredName.text);
        }
        else if (points > PlayerPrefs.GetInt("Highscore5"))
        {
            PlayerPrefs.SetInt("Highscore5", points);
            PlayerPrefs.SetString("Name5", enteredName.text);
        }

        enterHighscorePanel.SetActive(false);
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void SlideLoadingPanel()
    {
        StartCoroutine(SlideLoadingPanelCoroutine());
    }

    IEnumerator SlideLoadingPanelCoroutine()
    {
        AudioManager.instance.PlaySingle(false, whoosh);
        while (loadingPanel.offsetMax.x < 0 && loadingPanel.offsetMin.x < 0)
        {
            loadingPanel.offsetMax = new Vector2(loadingPanel.offsetMax.x + slideSpeed, loadingPanel.offsetMax.y);
            loadingPanel.offsetMin = new Vector2(loadingPanel.offsetMin.x + slideSpeed, loadingPanel.offsetMin.y);
            yield return null;
        }

        loadingPanel.offsetMax = new Vector2(0, 0);
        loadingPanel.offsetMin = new Vector2(0, 0);

        yield return new WaitForSeconds(1.0f);
        PlayAgain();
    }

    public void PlayAgain()
    {
        Application.LoadLevel(1);
    }
}
