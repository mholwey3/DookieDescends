using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip gameplayMusic;

    [SerializeField]
    private AudioClip whoosh;

    [SerializeField]
    private RectTransform loadingPanel;

    [SerializeField]
    private float slideSpeed;

    void Start()
    {
        AudioManager.instance.StopAllSfx();
        AudioManager.instance.PlayNewMusic(gameplayMusic);
        StartCoroutine(SlideLoadingPanelCoroutine());
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
