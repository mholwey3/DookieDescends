using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField]
    private Text credits;

    [SerializeField]
    private float scrollSpeed;

	void Update ()
    {
        credits.transform.Translate(new Vector3(0, scrollSpeed * Time.deltaTime, 0));

        if (credits.transform.localPosition.y >= 550)
        {
            credits.transform.localPosition = new Vector3(0, -528, 0);
        }
	}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
