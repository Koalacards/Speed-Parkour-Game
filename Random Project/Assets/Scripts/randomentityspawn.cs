using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomentityspawn : MonoBehaviour {

	[SerializeField]
	public GameObject[] randomobjects;

	Vector2 minimum;
	Vector2 maximum;

	void Start () {
		minimum = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		maximum = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		InvokeRepeating ("SpawnObject", 5f, .5f);

	}


	void SpawnObject()
	{
		GameObject screenfiller = Instantiate (randomobjects [Random.Range (0, randomobjects.Length)]);
		screenfiller.transform.position = new Vector2(Random.Range(minimum.x, maximum.x), Random.Range(minimum.y, maximum.y));
	}
}
