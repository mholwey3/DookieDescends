using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{
    [SerializeField]
	private float lowSpeed;

    [SerializeField]
    private float highSpeed;

	[SerializeField]
	public int points;

    private float randomSpeed;

	void Awake ()
	{
        randomSpeed = Random.Range(lowSpeed, highSpeed);
	}
	
	void Update ()
	{
        transform.position = new Vector3(transform.position.x - (randomSpeed * Time.deltaTime), transform.position.y, transform.position.z);
	}  
}
