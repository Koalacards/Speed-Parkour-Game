using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningofSequence : MonoBehaviour {

	public bool isStarted = false;

	public Text countdowntext;

	float seconds = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (first ());
	}

	IEnumerator first()
	{
		countdowntext.text = "3";
		yield return new WaitForSecondsRealtime (seconds);
		StartCoroutine (second ());
	}

	IEnumerator second()
	{
		countdowntext.text = "2";
		yield return new WaitForSecondsRealtime (seconds);
		StartCoroutine (third ());
	}

	IEnumerator third()
	{
		countdowntext.text = "1";
		yield return new WaitForSecondsRealtime (seconds);
		StartCoroutine (fourth());
	}

	IEnumerator fourth()
	{
		isStarted = true;
		countdowntext.text = "GO!";
		yield return new WaitForSecondsRealtime (seconds);
		countdowntext.text = "";
	}
		
}
