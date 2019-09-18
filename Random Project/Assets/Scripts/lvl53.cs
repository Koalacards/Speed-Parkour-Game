﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvl53 : MonoBehaviour {

	private Rigidbody2D rb2d;

	[SerializeField]
	public float radiuss;

	public LayerMask ground;

	public Vector2 jumpVector;

	private bool jump = false;

	private Checkpointscript checkpoint;

	public bool isGrounded;


	[SerializeField]
	public Transform[] groundpoints;

	public int deathcount;

	public Text deathtext;

	public float clock = 10f;

	public Text timetext;

	public Text levelcomplete;

	float waittime = 3f;

	private movementscript mvm;

	public Animator anim;


	void Start () {
		rb2d = FindObjectOfType <Rigidbody2D> ();
		checkpoint = FindObjectOfType<Checkpointscript> ();
		levelcomplete.text = "";
		mvm = FindObjectOfType<movementscript> ();
		deathcount = PlayerPrefs.GetInt("Deaths52");
		anim.SetBool ("Done", false);

	}




	void Update()
	{

		if (Input.GetKey (KeyCode.Space)) {
			jump = true;
		} else {
			jump = false;
		}
		if (Input.GetKey(KeyCode.A)) {
			rb2d.velocity = new Vector3 (-6f, 0, 0);
		}
		if (Input.GetKey(KeyCode.D)) {
			rb2d.velocity = new Vector3(6f, 0, 0);
		}
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene ("Scene1");
		}



		deathtext.text = ("Deaths: " + deathcount);

		clock -= Time.deltaTime;

		timetext.text = "Time: " + clock;

		if (clock < 0) {
			AddDeath ();
		}
	}

	void FixedUpdate()
	{
		isGrounded = IsGrounded();

		if (isGrounded && jump) {
			rb2d.velocity = jumpVector;
			isGrounded = false;
		}
	}



	private bool IsGrounded()
	{
		if (rb2d.velocity.y <= 0) {

			foreach (Transform point in groundpoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, radiuss, ground);

				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						return true;
					}
				}
			}

		} 
		return false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Respawn"))
		{
			AddDeath ();
		}

		if (other.CompareTag ("Finish")) {
			anim.SetBool ("Done", true);
			StartCoroutine (EndLevel ());

		}
		if(other.CompareTag("Trigger"))
		{
			other.gameObject.SetActive(false);

		}
		if (other.CompareTag ("AddTime")) {
			other.gameObject.SetActive (false);
			clock = clock + 5;
		}

		if (other.CompareTag ("Trigger2")) {
			other.gameObject.SetActive (false);

		}
	}

	IEnumerator EndLevel()
	{
		levelcomplete.text = "Level Complete";
		Invoke ("HideText", waittime);
		clock = 3.1f;
		yield return new WaitForSecondsRealtime (waittime);
		SceneManager.LoadScene ("Scene54");
		savedeathcount ();

	}

	public void HideText()
	{
		levelcomplete.text = "";
	}

	void savedeathcount()
	{
		PlayerPrefs.SetInt ("Deaths53", deathcount);
	}

	void AddDeath()
	{
		transform.position = checkpoint.gameObject.transform.position;
		deathcount = deathcount + 1;
		clock = 10;
		rb2d.velocity = new Vector2 (0, 0);
	}
}