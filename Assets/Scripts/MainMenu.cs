using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip startMusic;

    [SerializeField]
    private AudioClip whoosh;

    [SerializeField]
    private RectTransform loadingPanel;

    [SerializeField]
    private float slideSpeed;

    void Start()
    {
        AudioManager.instance.StopAllSfx();
        AudioManager.instance.PlayNewMusic(startMusic);
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
        startGame();
    }

	public void startGame()
	{
		SceneManager.LoadScene(1);
	}

    public void HowToPlay()
    {
        SceneManager.LoadScene(3);
    }

    public void Credits()
    {
        SceneManager.LoadScene(4);
    }

    public void Score()
    {
        SceneManager.LoadScene(5);
    }

	public void QuitGame()
    {
		Application.Quit();
	}
}
