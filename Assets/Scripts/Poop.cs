using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Poop : MonoBehaviour
{
	[SerializeField]
	private GameObject splatPrefab;

	[SerializeField]
    private AudioClip splatClip;

	private Bird bird;
	private PointObjectValue pointsObj;

	private void Start()
	{
		bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();
		pointsObj = GameObject.FindGameObjectWithTag("PointObject").GetComponent<PointObjectValue>();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
		}
		else if (coll.gameObject.tag.Substring(0,3) == "Car")
		{
			DefaceCarWithPoop(coll);
		}
	}

	private void DefaceCarWithPoop(Collision2D coll)
	{
		GameObject goSplat = Instantiate(splatPrefab);
		Vector2 splatPos = coll.contacts[0].point + new Vector2(0, -0.2f);

		AudioManager.instance.PlayRandomEffect(false, splatClip);
		bird.points += coll.gameObject.GetComponent<Car>().points;
		goSplat.transform.parent = coll.transform;
		goSplat.transform.position = new Vector3(splatPos.x, splatPos.y, goSplat.transform.parent.position.z);

		pointsObj.points = bird.points;

		Destroy(gameObject);
	}
}
