using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] carPrefabs;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float waitTimeLength;

    private float currentWaitTime;

    private Timer timer;

	void Start () 
	{
        SetSpawnTimer();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
	}
    
	void Update ()
	{
		currentWaitTime -= Time.deltaTime;

		if(currentWaitTime <= 0)
		{
			Instantiate(carPrefabs[Random.Range(0 , carPrefabs.Length)], spawnPoint.position, spawnPoint.rotation);

            if (timer.GetTimer() > 30f)
            {
                IncreaseDifficulty();
                timer.ResetTimer();
            }

            SetSpawnTimer();
		}
	}

    public void SetSpawnTimer()
    {
        currentWaitTime = waitTimeLength;
    }

    private void IncreaseDifficulty()
    {
        if (waitTimeLength <= 3f)
        {
            return;
        }

        waitTimeLength--;
    }
}
