using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour
{
    [SerializeField]
	private float lowSpeed;
    [SerializeField]
    private float highSpeed;
    [SerializeField]
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
