using UnityEngine;
using System.Collections;

public class Poop : MonoBehaviour
{
	public GameObject splatPrefab;
    public AudioClip splatClip;

	int birdPoints;	
	int livesLeft;

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			Destroy(this.gameObject);
		}
		else if (coll.gameObject.tag.Substring(0,3) == "Car")
		{
			int points = 0;
            if (coll.gameObject.tag == "Car")
                points = 30;
            else if (coll.gameObject.tag == "Car2")
                points = 20;
            else if (coll.gameObject.tag == "Car3")
                points = 10;
            else if (coll.gameObject.tag == "Car4")
                points = 50;

			Bird bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>();

			bird.points += points;

			GameObject splat = GameObject.Instantiate<GameObject>(splatPrefab);
			splat.transform.parent = coll.transform;
            Vector2 splatPos = coll.contacts[0].point + new Vector2(0, -0.2f);
            splat.transform.position = new Vector3(splatPos.x, splatPos.y, splat.transform.parent.position.z);
            AudioManager.instance.PlayRandomEffect(false, splatClip);

			Destroy(this.gameObject);
		}

		GameObject.FindGameObjectWithTag("PointObject").GetComponent<PointObjectValue>().points = GameObject.FindGameObjectWithTag("Bird").GetComponent<Bird>().points;
	}
}
