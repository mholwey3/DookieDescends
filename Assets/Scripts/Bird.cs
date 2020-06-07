using UnityEngine;
using System.Diagnostics;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
	[SerializeField]
	private GameObject prefab_Poop;

	[SerializeField]
	private Transform transform_BirdEnd;

	[SerializeField]
	private Text text_Points;

	[SerializeField]
	private Text text_Lives;

	[HideInInspector]
	public int points;

	private int lives;

	[HideInInspector]
	public bool pMeterFull = false;

	[SerializeField]
	private static int PointsTotal;

	[SerializeField]
	private AudioClip[] audioClips_Farts;

    private Animator animator;

	void Start () 
	{
		lives = 3;
		animator = this.gameObject.GetComponent<Animator>();
	}

	void Update ()
	{
		text_Lives.text = "Lives: " + lives.ToString();
        text_Points.text = "Score: " + points.ToString();

		if(animator.GetBool("isPooping"))
		{
			animator.SetBool ("isPooping", false);
		}

        //This takes care of clicking, pressing the space bar, or tapping a touch screen in order to poop
		if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && pMeterFull)
		{
			animator.SetBool("isPooping", true);

            GameObject.Find("ImageFill").GetComponent<PoopMeter>().ResetBar();
			pMeterFull = false;
		
			Instantiate(prefab_Poop, transform_BirdEnd.position, transform_BirdEnd.rotation);
            AudioManager.instance.PlayRandomEffect(false, audioClips_Farts);
		}

        if (lives <= 0)
		{
            EndGame();
		}
	}

	public void LoseLife()
	{
		lives--;
	}

	public void SavePoints()
	{
		PointsTotal += points;
		//Saves the overall coin count in memory
		if (PlayerPrefs.GetInt ("Coins") == null)
        {
			PlayerPrefs.SetInt ("PointsTotal", PointsTotal);
		}
        else
        {
			PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("PointsTotal") + PointsTotal);
		}
	}

    void EndGame()
    {
        SceneManager.LoadScene(2);
    }
}
