using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
	public float speed;
    public AudioClip gameplayMusic;
    public AudioClip whoosh;
    public RectTransform loadingPanel;
    float slideSpeed = 50f;

    void Start()
    {
        AudioManager.instance.StopAllSfx();
        AudioManager.instance.PlayNewMusic(gameplayMusic);
        StartCoroutine(SlideLoadingPanelCoroutine());
    }

	void Update ()
	{
		transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
	}

    IEnumerator SlideLoadingPanelCoroutine()
    {
        AudioManager.instance.PlaySingle(false, whoosh);
        while (loadingPanel.offsetMax.x < 800 && loadingPanel.offsetMin.x < 800)
        {
            loadingPanel.offsetMax = new Vector2(loadingPanel.offsetMax.x + slideSpeed, loadingPanel.offsetMax.y);
            loadingPanel.offsetMin = new Vector2(loadingPanel.offsetMin.x + slideSpeed, loadingPanel.offsetMin.y);
            yield return null;
        }

        loadingPanel.gameObject.SetActive(false);
    }
}
