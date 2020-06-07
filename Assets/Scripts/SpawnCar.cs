using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour
{
	public float currentWaitTime;
	public float waitTimeLength;
	public GameObject[] carPrefabs;
	public Transform spawnPoint;
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

            if (timer.GetTimer() > 30)//increase frequency of spawning
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
            return;

        waitTimeLength--;
    }
}
