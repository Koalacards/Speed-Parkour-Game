using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvl37 : MonoBehaviour {


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

	public GameObject r1;

	public GameObject r2;

	public GameObject r3;

	public GameObject button;

	public GameObject button2;

	public GameObject moving;

	public GameObject moving2;

	public Animator anim;

	void Start () {
		rb2d = FindObjectOfType <Rigidbody2D> ();
		checkpoint = FindObjectOfType<Checkpointscript> ();
		deathcount = PlayerPrefs.GetInt("Deaths36");
		levelcomplete.text = "";
		r1.gameObject.SetActive (false);
		button2.gameObject.SetActive (false);
		moving.gameObject.transform.position = new Vector2 (4.94f, -1.5f);
		moving2.gameObject.transform.position = new Vector2(-4.72f,-1.18f);
		anim.SetBool ("Done", false);
	}




	void Update()
	{
		if (Input.GetKey (KeyCode.Space)) {
			jump = true;
		} else {
			jump = false;
		}
		if (Input.GetKey (KeyCode.A)) {
			rb2d.velocity = new Vector3 (-7f, 0, 0);
		}
		if (Input.GetKey (KeyCode.D)) {
			rb2d.velocity = new Vector3 (7f, 0, 0);
		}
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene ("Scene21");
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

		if (other.CompareTag ("Trigger")) {
			other.gameObject.SetActive (false);
			moving.gameObject.transform.position = new Vector2 (4.94f, 0);
			button2.gameObject.SetActive (true);
			r1.gameObject.SetActive (true);
			r2.gameObject.SetActive (false);
		}
		if (other.CompareTag ("AddTime")) {
			other.gameObject.SetActive (false);
			clock = clock + 2;
		}

		if (other.CompareTag ("Trigger2")) {
			other.gameObject.SetActive (false);
			moving2.gameObject.transform.position = new Vector2 (-4.72f, 1);
			r3.gameObject.SetActive (false);
			r2.gameObject.SetActive (true);
			clock = clock + 2;
		}
	}

	IEnumerator EndLevel()
	{
		levelcomplete.text = "Level Complete";
		Invoke ("HideText", waittime);
		clock = 3.2f;
		yield return new WaitForSecondsRealtime (waittime);
		SceneManager.LoadScene ("Scene38");
		savedeathcount ();

	}

	public void HideText()
	{
		levelcomplete.text = "";
	}

	void savedeathcount()
	{
		PlayerPrefs.SetInt ("Deaths37", deathcount);
	}

	void AddDeath()
	{
		deathcount = deathcount + 1;
		clock = 10;
		rb2d.velocity = new Vector2 (0, 0);
		transform.position = checkpoint.gameObject.transform.position;
		r1.gameObject.SetActive (false);
		button2.gameObject.SetActive (false);
		moving.gameObject.transform.position = new Vector2 (4.94f, -1.5f);
		moving2.gameObject.transform.position = new Vector2(-4.72f,-1.18f);
		r2.gameObject.SetActive (true);
		r3.gameObject.SetActive (true);
		button.gameObject.SetActive (true);
	}
}