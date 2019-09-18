using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class beginningend : MonoBehaviour {

	public Text deathtext;

	int finaldeathcount;

	public Text endtext;


	// Use this for initialization
	void Start () {
		finaldeathcount = PlayerPrefs.GetInt ("FinalDeathCountBeginning");
		deathtext.text = "Deaths: " + finaldeathcount;

		if (finaldeathcount == 0) {
			endtext.text = "Congratulations! You have mastered\nthese twenty levels. Can you do the\nsame for the intermediate stage?";
		}

		if(finaldeathcount > 0 && finaldeathcount < 6)
		{
			endtext.text = "Well done! You almost went \ndeathless! try again and I am sure \nyou will go without dying. I believe\nin you!";
		}

		if(finaldeathcount >5 && finaldeathcount < 21)
		{
			endtext.text = "Good attempt! However, you can still\nimprove. Keep trying until you \nbecome a true master of the \nbeginning sequence.";
		}

		if (finaldeathcount > 20 && finaldeathcount < 51) {
			endtext.text = "Not bad, but you still have a lot \nto learn about these stages. Try \nagain and i am sure you will do better\nthan this.";
		}

		if (finaldeathcount > 50) {
			endtext.text = "you have a lot of practice to do on \nthese levels. please try again and \ndo better next time. i am sure that \nyou can improve from this.";
		}
	}
	
	

	public void ChangeScene (string SceneToChangeTo)
	{
		SceneManager.LoadScene (SceneToChangeTo);
	}
}
