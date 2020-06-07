using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour
{
    private Bird bird;

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
    }

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag.Contains("Car"))
        {
            // is there poop on the car?
            if (other.gameObject.transform.childCount == 0) // No poop
                bird.LoseLife();

            Destroy(other.gameObject);   
        }
	}
}
