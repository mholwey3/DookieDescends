using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreManager : MonoBehaviour
{
    [SerializeField]
    private Text[] _texts_Highscores;

    [SerializeField]
    private Text[] _texts_Names;

    void Start()
    {
        PopulateTextFields();
    }

    private void PopulateTextFields()
    {
        for (int i = 0; i < 5; i++)
        {
            string sHighscoreNum = (i + 1).ToString();

            if (PlayerPrefs.GetString("Name" + sHighscoreNum).Equals(""))
            {
                _texts_Names[i].text = sHighscoreNum + ". High score " + sHighscoreNum;
            }
            else
            {
                _texts_Names[i].text = sHighscoreNum + ". " + PlayerPrefs.GetString("Name" + sHighscoreNum);
            }

            _texts_Highscores[i].text = string.Format("{0:#,###0}", PlayerPrefs.GetInt("Highscore" + sHighscoreNum));
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
