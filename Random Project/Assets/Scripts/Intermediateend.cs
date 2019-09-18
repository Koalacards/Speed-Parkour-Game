using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intermediateend : MonoBehaviour {

	public Text deathtext;

	int finaldeathcount;

	public Text endtext;


	// Use this for initialization
	void Start () {
		finaldeathcount = PlayerPrefs.GetInt ("Deaths40");
		deathtext.text = "Deaths: " + finaldeathcount;

		if (finaldeathcount == 0) {
			endtext.text = "Congratulations! You are becoming very \ngood at this game! However, the advanced\n levels areeven more enraging than\n these ones. care to give them a try?";
		}

		if(finaldeathcount > 0 && finaldeathcount < 6)
		{
			endtext.text = "That was a great attempt! you are very\nclose to mastering these intermediate\nlevels. give them another try and i am \nsure that you will get them!";
		}

		if(finaldeathcount >5 && finaldeathcount < 21)
		{
			endtext.text = "That was a solid attempt! These levels\nare pretty tricky, and you are getting\nclose to mastery level. Try a few more \ntimes, you can do it!";
		}

		if (finaldeathcount > 20 && finaldeathcount < 51) {
			endtext.text = "This was a good try, but I know you can do \nbetter.  try again and im sure you will \nimprove! all it will take is a couple of \nminutes of practice!";
		}

		if (finaldeathcount > 50) {
			endtext.text = "please try again. you can probably shave\noff a big chunk of these deaths on the \nnext try with just a little practice. \nthese levels arent too bad!";
		}
	}



	public void ChangeScene (string SceneToChangeTo)
	{
		SceneManager.LoadScene (SceneToChangeTo);
	}
}
