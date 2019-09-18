using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManagement : MonoBehaviour {

	int done;

	void Start()
	{
		done = PlayerPrefs.GetInt ("Done");
	}
	public void ChangeScene(string ScenetoChangeTo)
	{
		if (done == 1) {
			SceneManager.LoadScene (ScenetoChangeTo);
		}
	}
}
